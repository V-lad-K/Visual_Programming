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
    
    public partial class додаткова_інформація_про_товар
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public додаткова_інформація_про_товар()
        {
            this.замовлення_особи_товару = new HashSet<замовлення_особи_товару>();
        }
    
        public Nullable<int> номер_документу { get; set; }
        public string операція { get; set; }
        public int id { get; set; }
        public string UCR { get; set; }
        public Nullable<System.DateTime> DCR { get; set; }
        public string ULC { get; set; }
        public Nullable<System.DateTime> DLC { get; set; }
    
        public virtual Товар Товар { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<замовлення_особи_товару> замовлення_особи_товару { get; set; }
    }
}
