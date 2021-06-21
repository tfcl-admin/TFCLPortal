using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFCLPortal.FilesUploads.Dto;
using TFCLPortal.FileTypes.Dto;

namespace TFCLPortal.Web.Models.UploadFiles
{
    public class FileUploadModel
    {
        public List<FilesUploadListDto> filesUploads { get; set; }
        public List<FileTypeListDto> fileTypes { get; set; }
        public List<GuarantorCoApplicant> GuarantorCoApplicants{ get; set; }
    }

    public class GuarantorCoApplicant
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
