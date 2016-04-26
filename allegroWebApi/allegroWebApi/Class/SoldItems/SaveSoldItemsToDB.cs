using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using allegroWebApi.pl.allegro.webapi;
using System.Data.Sql;
using System.Data.Entity.Migrations;





namespace allegroWebApi.Class.SoldItems
{
    class SaveSoldItemsToDB
    {        
        public SaveSoldItemsToDB(SoldItemStruct[] soldItemList)
        {
            AllegroChaosBusterDBContext myDB = new AllegroChaosBusterDBContext();
            SoldItemsTable addRow;
            //newRow.ItemID     
            myDB.Database.Connection.Open();
            myDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT AllegroChaosBuster.dbo.SoldItemsTable ON");
            for (int i = 0; i < soldItemList.Length; i++)
            {     
                          
                addRow = new SoldItemsTable();
                addRow.ItemID = soldItemList[i].itemid;
                addRow.ItemTitle = soldItemList[i].itemtitle;
                addRow.ItemThumbnailUrl = soldItemList[i].itemthumbnailurl;
                addRow.ItemPriceType = soldItemList[i].itemprice[0].pricetype;
                addRow.ItemPriceValue = soldItemList[i].itemprice[0].pricevalue;
                addRow.ItemSoldQuantity = soldItemList[i].itemsoldquantity;
                addRow.ItemQuantityType = soldItemList[i].itemquantitytype;
                addRow.ItemStartTime = soldItemList[i].itemstarttime;
                addRow.ItemEndTime = soldItemList[i].itemendtime;
                addRow.ItemEndTimeLeft = soldItemList[i].itemendtimeleft;
                addRow.ItemBiddersCounter = soldItemList[i].itembidderscounter;
                addRow.ItemCategoryId = soldItemList[i].itemcategoryid;
                addRow.ItemWtchersCounter = soldItemList[i].itemwatcherscounter;
                addRow.ItemViewsCounter = soldItemList[i].itemviewscounter;
                addRow.ItemNote = soldItemList[i].itemnote;
                addRow.ItemPayInfo = soldItemList[i].itempayuinfo;
                myDB.SoldItemsTables.AddOrUpdate(addRow);    
                myDB.SaveChanges();      
            }
            myDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT AllegroChaosBuster.dbo.SoldItemsTable OFF");
            myDB.Database.Connection.Close();









        }
    }
}
