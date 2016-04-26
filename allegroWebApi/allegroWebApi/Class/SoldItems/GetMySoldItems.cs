using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using allegroWebApi.pl.allegro.webapi;

namespace allegroWebApi.Class.SoldItems
{
    class GetMySoldItems
    {
        private AllegroWebApiService service { get; set; }
        //private SortOptionsStruct sortOpiton { get; set; }
        private SoldItemStruct[] soldItemList;
        private int soldItemsCounter;

        public GetMySoldItems(string sessionHandle)
        {
            service = new AllegroWebApiService();
            soldItemsCounter = service.doGetMySoldItems(sessionHandle, null, null, null, 0, null, 0, 0, out soldItemList);            
        }
        public SoldItemStruct[] ReturnSoldItemList()
        {
            return soldItemList;
        }
        public int ReturnsoldItemsCounter()
        {
            return soldItemsCounter;
        }
    }
}
