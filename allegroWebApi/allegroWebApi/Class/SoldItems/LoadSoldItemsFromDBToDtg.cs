using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Data.Sql;
using System.Data.Entity.Migrations;
using System.Globalization;

namespace allegroWebApi.Class.SoldItems
{
    class LoadSoldItemsFromDBToDtg
    {
        private DataGrid dtgSoldItems { get; set;}

        public LoadSoldItemsFromDBToDtg(DataGrid dtgSoldItems)
        {
            this.dtgSoldItems = dtgSoldItems;
            ShowSoldItems();
        }

        private void ShowSoldItems()
        {
            AllegroChaosBusterDBContext myDB = new AllegroChaosBusterDBContext();
            myDB.Database.Connection.Open();
            var items = myDB.SoldItemsTables.ToList();
            dtgSoldItems.Items.Clear();
            foreach(var i in items)
            {
                dtgSoldItems.Items.Add(new
                {
                    ItemID = i.ItemID,
                    ItemTitle = i.ItemTitle,
                    ItemEndTimeLeft = i.ItemEndTimeLeft + "("+UnixTimeStampToDateTime((Convert.ToDouble(i.ItemEndTime)))+")",
                    ItemSoldQuantity = i.ItemSoldQuantity,
                    ItemSoldQuantityType = ItemQuantityTypeToStr(Convert.ToInt32(i.ItemQuantityType)),
                    ItemBiddersCounter = i.ItemBiddersCounter,
                    PriceType = ItemPriceTypeToString(Convert.ToInt32(i.ItemPriceType)),
                    PriceValue = Math.Round((double)i.ItemPriceValue,2).ToString("0.00", CultureInfo.InvariantCulture) + " zł",
                    ImageUrl = i.ItemThumbnailUrl


                }); 
            }
            myDB.Database.Connection.Close();
        }
        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        private string ItemPriceTypeToString(int ItemPriceTypeInt)
        {
            string ItemPriceTypeString = "";
            if (ItemPriceTypeInt == 1)
                ItemPriceTypeString = "Kup Teraz!";
            else if (ItemPriceTypeInt == 2)
                ItemPriceTypeString = "Aktualna cena w licytacji";
            else if (ItemPriceTypeInt == 3)
                ItemPriceTypeString = "Cena wywyoławcza w licytacji";
            else
                ItemPriceTypeString = "Cena minimalna w licytacji";

            return ItemPriceTypeString;
        }
        private string ItemQuantityTypeToStr(int itemQuantityTypeInt)
        {
            string itemQuantityString ="";
            if (itemQuantityTypeInt == 1)
                itemQuantityString = "Sztuk: ";
            else if (itemQuantityTypeInt == 2)
                itemQuantityString = "Kompletów: ";
            else
                itemQuantityString = "Par: ";

            return itemQuantityString;
        }
    }
}
