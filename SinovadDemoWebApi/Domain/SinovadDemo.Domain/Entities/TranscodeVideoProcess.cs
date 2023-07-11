using SinovadDemo.Domain.Common;

namespace SinovadDemo.Domain.Entities;

public partial class TranscodeVideoProcess : BaseAuditableEntity
{
    public int Id { get; set; }

    public string Guid { get; set; } = null!;

    public int TranscodeAudioVideoProcessId { get; set; }

    public int? TranscodeSubtitlesProcessId { get; set; }

    public string WorkingDirectoryPath { get; set; } = null!;

    public int AccountServerId { get; set; }
}
