using System.ComponentModel.DataAnnotations;

namespace MVCDEMO.Models {
    public class Doanvien {
        [Key]
        public string id { get; set; }
        public string fullname { get; set; }

        public string cdid { get; set; }

        public Chidoan chidoan {get;set;}

    }
}
//dotnet-aspnet-codegenerator controller -name DoanviensController -m Doanvien -dc ApplicationDBContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite
