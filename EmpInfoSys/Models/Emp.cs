//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmpInfoSys.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.Web.Mvc;
    
    public partial class Emp
    {
        [DisplayName("社員ID")]
        [Required(ErrorMessage = "{0}は必須です")]
        public int EmpId { get; set; }

        [DisplayName("名前")]
        [Required(ErrorMessage = "{0}は必須です")]
        public string Name { get; set; }

        [DisplayName("誕生日")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0}は必須です")]
        public System.DateTime BirthDay { get; set; }

        public string ReturnDateForDisplay
        {
            get
            {
                return this.BirthDay.ToString("d");
            }
        }

        [DisplayName("部門ID")]
        [Required(ErrorMessage = "{0}は必須です")]
        public int? DeptId { get; set; }
    
        public virtual Dept Dept { get; set; }
        public IEnumerable<SelectListItem> DeptItems;
    }
}
