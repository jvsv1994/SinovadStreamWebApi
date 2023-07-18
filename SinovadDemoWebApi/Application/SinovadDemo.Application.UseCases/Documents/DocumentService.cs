using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Transversal.Common;
using System.Net;

namespace SinovadDemo.Application.UseCases.Documents
{
    public class DocumentService : IDocumentService
    {
        private IUnitOfWork _unitOfWork;

        private IConfiguration _configuration;


        private readonly SharedService _sharedService;

        public DocumentService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork= unitOfWork;
            _configuration= configuration;
        }

        public Response<object> UploadAvatarProfile(DocumentDto document)
        {
            var response = new Response<object>();
            try
            {
                var myConfig = _configuration.Get<MyConfig>();
                var ftpUrl = "ftp://"+ myConfig.FtpSettings.Server + ":"+myConfig.FtpSettings.Port;
                var folderPath = "/avatars/" + Guid.NewGuid();
                WebRequest requestCreateFolder = WebRequest.Create(ftpUrl + folderPath);
                requestCreateFolder.Method = WebRequestMethods.Ftp.MakeDirectory;
                requestCreateFolder.Credentials = new NetworkCredential(myConfig.FtpSettings.User, myConfig.FtpSettings.Password);
                byte[] bytes;
                using (var res = (FtpWebResponse)requestCreateFolder.GetResponse())
                {
                    var filePath = folderPath + "/" + document.File.FileName;
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl + filePath);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(myConfig.FtpSettings.User, myConfig.FtpSettings.Password);
                    request.ContentLength = document.File.Length;
                    using (var stream = new MemoryStream())
                    {
                        document.File.CopyTo(stream);
                        bytes = stream.ToArray();
                        using (Stream requestStream = request.GetRequestStream())
                        {
                            requestStream.Write(bytes, 0, (int)stream.Length);
                            var profile = _unitOfWork.Profiles.Get(document.ProfileId);
                            profile.AvatarPath = filePath;
                            _unitOfWork.Profiles.Update(profile);
                            _unitOfWork.Save();
                        }
                    }
                }
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Stream GetAvatarProfile(int profileId)
        {
            var profile =  _unitOfWork.Profiles.Get(profileId);

            var myConfig = _configuration.Get<MyConfig>();
            var ftpUrl = "ftp://" + myConfig.FtpSettings.Server + ":" + myConfig.FtpSettings.Port;
            var filePath = profile.AvatarPath;

            FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(ftpUrl + filePath);
            downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            downloadRequest.Credentials = new NetworkCredential(myConfig.FtpSettings.User, myConfig.FtpSettings.Password);
            FtpWebResponse downloadResponse = (FtpWebResponse)downloadRequest.GetResponse();
            Stream sourceStream = downloadResponse.GetResponseStream();
            return sourceStream;
        }



    }
}
