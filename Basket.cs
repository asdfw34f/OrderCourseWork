//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    using System;
    using System.Collections.Generic;
    
    public partial class Basket
    {
        public int id { get; set; }
        public Nullable<int> id_client { get; set; }
        public Nullable<int> id_product { get; set; }
        public string Status { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }
}
