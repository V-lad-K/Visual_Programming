//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Windows_Corse
{
    using System;
    using System.Collections.Generic;
    
    public partial class Товар
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Товар()
        {
            this.відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику = new HashSet<відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику>();
        }
    
        public string код { get; set; }
        public string категорія_продукту { get; set; }
        public string ім_я { get; set; }
        public string одиниця { get; set; }
        public Nullable<System.DateTime> термін_придатності { get; set; }
        public Nullable<double> ціна_закупки { get; set; }
        public Nullable<double> ціна_продажу { get; set; }
        public Nullable<int> на_складі { get; set; }
        public int id { get; set; }
        public string UCR { get; set; }
        public Nullable<System.DateTime> DCR { get; set; }
        public string ULC { get; set; }
        public Nullable<System.DateTime> DLC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику> відслідкування_оплати_товару_покупцям_або_виплата_товару_посчальнику { get; set; }
        public virtual додаткова_інформація_про_товар додаткова_інформація_про_товар { get; set; }
    }
}
