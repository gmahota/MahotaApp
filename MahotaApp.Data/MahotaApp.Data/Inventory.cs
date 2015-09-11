using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahotaApp.Data
{
    #region Data Model For Iventory of Tooling Equipment - font: http://www.databaseanswers.org/data_models/inventory_of_tooling_equipment/index.htm
    public class Locations
    {
        [Key]
        public string location_Code { get; set; }
        
        [StringLength(50)]
        public string location_Name { get; set; }

        public virtual ICollection<Equipment_Iventory> list_Equipment_Iventory { get; set; }
    }

    public class Ref_Tooling_Types
    {
        [Key]
        public string tooling_Type_Code { get; set; }

        [StringLength(50)]
        public string tooling_Type_Description { get; set; }

        public virtual ICollection<Equipment_Iventory> list_Equipment_Iventory { get; set; }
    }

    public class Equipment_Iventory
    {        
        [Key]
        public string equipment_ID { get; set; }

        public string location_Code { get; set; }
        public string tooling_Type_Code { get; set; }

        [StringLength(50)]
        public string asset_Number { get; set; }

        [StringLength(50)]
        public string serial_Number { get; set; }
        
        [StringLength(50)]
        public string tooling_Name { get; set; }
        
        public double qty { get; set; }
        public DateTime? issue_Date { get; set; }
        public bool damaged_YN { get; set; }
        public bool embossed_YN { get; set; }

        [StringLength(50)]
        public string embossed_Name { get; set; }
        
        public bool in_Use_YN { get; set; }

        [StringLength(50)]
        public string in_Use_Where { get; set; }
        public DateTime? expired_Date { get; set; }
        public bool expired_YN { get; set; }

        [StringLength(250)]
        public string other_Detais { get; set; }


        [ForeignKey("location_Code")]
        public virtual Locations location { get; set; }

        [ForeignKey("tooling_Type_Code")]
        public virtual Ref_Tooling_Types tooling_Types { get; set; }
    }
    #endregion

    #region Iventory and Sales fonte: http://www.databaseanswers.org/data_models/inventory_and_sales/index.htm

    public class Daily_Iventory_Levels
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        
        public DateTime date_of_Iventory { get; set; }

        public Guid product_ID { get; set; }

        public string level { get; set; }

        [ForeignKey("product_ID")]
        public virtual Products Product { get; set; }
    }

    public class Product_Types
    {
        [Key]
        [StringLength(50)]
        public string product_Type_Code { get; set; }
        
        [StringLength(50)]
        public string parent_Product_Type_Code { get; set; }
        
        [ForeignKey("parent_Product_Type_Code")]
        public virtual Product_Types product_Type { get; set; }

        public virtual ICollection<Product_Types> list_Product_Types { get; set; }
        public virtual ICollection<Products> list_Products { get; set; }
    }

    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid product_ID { get; set; }
        
        [StringLength(50)]
        public string product_Type_Code { get; set; }
        
        [StringLength(100)]
        public string product_Name { get; set; }

        public double unit_Price { get; set; }

        [StringLength(250)]
        public string product_Description { get; set; }
        
        [StringLength(50)]
        public string reorder_Level { get; set; }

        public double redorder_Quantity { get; set; }

        public string other_Details { get; set; }

        [ForeignKey("product_Type_Code")]
        public virtual Product_Types product_Type { get; set; }

        public virtual ICollection<Daily_Iventory_Levels> list_Daily_Iventory_Levels { get; set; }
        public virtual ICollection<Orders_Items> list_Orders_Items { get; set; }
    }

    public class Orders_Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid order_Item_ID { get; set; }

        public Guid order_ID { get; set; }

        public Guid product_ID { get; set; }

        public double product_Quantity { get; set; }

        public double product_Vat { get; set; }

        public double product_Price { get; set; }

        public double product_Discount { get; set; }

        [ForeignKey("product_ID")]
        public virtual Products product { get; set; }

        [ForeignKey("order_ID")]
        public virtual Orders order { get; set; }
    }

    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid order_ID { get; set; }

        public Guid customer_ID { get; set; }

        public DateTime date_of_Order { get; set; }

        [StringLength(250)]
        public string order_Details { get; set; }

        public double order_TotalPrice { get; set; }

        public double order_TotalVat { get; set; }

        public double order_TotalDiscount { get; set; }

        [ForeignKey("customer_ID")]
        public virtual Customers customer { get; set; }

        public virtual ICollection<Orders_Items> list_Orders_Items { get; set; }

    }

    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid customer_ID { get; set; }

        [StringLength(150)]
        public string customer_Name { get; set; }
        
        [StringLength(250)]
        public string customer_Details { get; set; }

        public virtual ICollection<Orders> list_Orders { get; set; }

    }
        
    #endregion


}
