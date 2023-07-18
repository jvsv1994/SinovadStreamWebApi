using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IDocumentService {

        Response<object> UploadAvatarProfile(DocumentDto document);
        Stream GetAvatarProfile(int profileId);

    }

}
