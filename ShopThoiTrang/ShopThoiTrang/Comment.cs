//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopThoiTrang
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int CommentID { get; set; }
        public string CommentContent { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual User User { get; set; }
    }
}
