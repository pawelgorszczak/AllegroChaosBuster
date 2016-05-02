using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using allegroWebApi.pl.allegro.webapi;
using System.Data.Entity.Migrations;
using allegroWebApi;

namespace allegroWebApi.Class.MyIncomingPayments
{
    class DataBaseOperations : Interfaces.IDataBaseOperations<UserIncomingPaymentStruct[], MyIncomingPaymentsTable>
    {
        AllegroChaosBusterDBContext myDB;
        public void ConnectionOpen()
        {
            myDB = new AllegroChaosBusterDBContext();
            myDB.Database.Connection.Open();
        }
        public void ConnectionClose()
        {
            myDB = new AllegroChaosBusterDBContext();
            myDB.Database.Connection.Close();
        }
        public void SaveDataToDataBase(UserIncomingPaymentStruct[] myIncomingPaymentStruct)
        {
            myDB = new AllegroChaosBusterDBContext();
            myDB.Database.Connection.Open();
            myDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT AllegroChaosBuster.dbo.MyIncomingPaymentsTable ON");
            MyIncomingPaymentsTable newRowIncPay;
            PayTransDatailsTable newRowPayTrDet;

            for (int i = 0; i < myIncomingPaymentStruct.Length; i++)
            {
                newRowIncPay = new MyIncomingPaymentsTable();
                newRowIncPay.PayTransID = myIncomingPaymentStruct[i].paytransid;
                newRowIncPay.ItemID = myIncomingPaymentStruct[i].paytransitid;
                newRowIncPay.PayTransBuyerID = myIncomingPaymentStruct[i].paytransbuyerid;
                newRowIncPay.PayTransType = myIncomingPaymentStruct[i].paytranstype;
                newRowIncPay.PayTransStatus = myIncomingPaymentStruct[i].paytransstatus;
                newRowIncPay.PayTransAmount = myIncomingPaymentStruct[i].paytransamount;
                newRowIncPay.PayTransCreateDate = myIncomingPaymentStruct[i].paytranscreatedate;
                newRowIncPay.PayTransRecvDate = myIncomingPaymentStruct[i].paytransrecvdate;
                newRowIncPay.PayTransPrice = myIncomingPaymentStruct[i].paytransprice;
                newRowIncPay.PayTransCount = myIncomingPaymentStruct[i].paytranscount;
                newRowIncPay.PayTransPostageAmount = myIncomingPaymentStruct[i].paytranspostageamount;
                newRowIncPay.PayTransIncomplete = myIncomingPaymentStruct[i].paytransincomplete;
                newRowIncPay.PayTransMainId = Convert.ToInt32(myIncomingPaymentStruct[i].paytransmainid);

                myDB.MyIncomingPaymentsTables.AddOrUpdate(newRowIncPay);
                myDB.SaveChanges();
                if (myIncomingPaymentStruct[i].paytransitid == 0)
                {
                    for (int j = 0; j < myIncomingPaymentStruct[i].paytransdetails.Length; j++)
                    {
                        newRowPayTrDet = new PayTransDatailsTable();
                        newRowPayTrDet.itemID = myIncomingPaymentStruct[i].paytransdetails[j].paytransdetailsitid;
                        newRowPayTrDet.payTransID = myIncomingPaymentStruct[i].paytransid;
                        newRowPayTrDet.payTransDetailsPrice = myIncomingPaymentStruct[i].paytransdetails[j].paytransdetailsprice;
                        newRowPayTrDet.payTransDetailsCount = myIncomingPaymentStruct[i].paytransdetails[j].paytransdetailscount;
                        if (myDB.PayTransDatailsTables.Where(o => o.itemID == newRowPayTrDet.itemID).Any(o => o.payTransID == newRowPayTrDet.payTransID) && myDB.PayTransDatailsTables.Where(o => o.payTransID == newRowPayTrDet.payTransID).Any(o => o.itemID == newRowPayTrDet.itemID))
                        {
                            if (myDB.PayTransDatailsTables.Where(o => o.payTransID == newRowPayTrDet.payTransID && o.itemID == newRowPayTrDet.itemID).Any(o => o.payTransDetailsPrice == newRowPayTrDet.payTransDetailsPrice))
                            {
                                if (myDB.PayTransDatailsTables.Where(o => o.payTransID == newRowPayTrDet.payTransID && o.itemID == newRowPayTrDet.itemID && o.payTransDetailsPrice == newRowPayTrDet.payTransDetailsPrice).Any(o => o.payTransDetailsCount != newRowPayTrDet.payTransDetailsCount))
                                {
                                    myDB.PayTransDatailsTables.Where(o => o.payTransID == newRowPayTrDet.payTransID && o.itemID == newRowPayTrDet.itemID).ToList().ForEach(x => x.payTransDetailsCount = newRowPayTrDet.payTransDetailsCount);
                                    myDB.SaveChanges();
                                }
                            }
                            else
                            {
                                if (myDB.PayTransDatailsTables.Where(o => o.payTransID == newRowPayTrDet.payTransID && o.itemID == newRowPayTrDet.itemID && o.payTransDetailsCount == newRowPayTrDet.payTransDetailsCount).Any(o => o.payTransDetailsCount != newRowPayTrDet.payTransDetailsCount))
                                {
                                    myDB.PayTransDatailsTables.Where(o => o.payTransID == newRowPayTrDet.payTransID && o.itemID == newRowPayTrDet.itemID).ToList().ForEach(x => x.payTransDetailsPrice = newRowPayTrDet.payTransDetailsPrice);
                                    myDB.SaveChanges();
                                }
                                else
                                {
                                    myDB.PayTransDatailsTables.Where(o => o.payTransID == newRowPayTrDet.payTransID && o.itemID == newRowPayTrDet.itemID).ToList().ForEach(x => x.payTransDetailsCount = newRowPayTrDet.payTransDetailsCount);
                                    myDB.PayTransDatailsTables.Where(o => o.payTransID == newRowPayTrDet.payTransID && o.itemID == newRowPayTrDet.itemID).ToList().ForEach(x => x.payTransDetailsPrice = newRowPayTrDet.payTransDetailsPrice);
                                    myDB.SaveChanges();
                                }
                            }

                        }
                        else
                        {
                            myDB.PayTransDatailsTables.AddOrUpdate(newRowPayTrDet);
                            myDB.SaveChanges();
                        }
                    }
                }
            }
            myDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT AllegroChaosBuster.dbo.MyIncomingPaymentsTable OFF");
            myDB.Database.Connection.Close();
        }
        //public IEnumerable<MyIncomingPaymentsTable> GetData()
        //{

        //}
        public IEnumerable<MyIncomingPaymentsTable> GetDataFromDataBase()
        {
            //
            // Summary:
            //     This function returns all MyIncomingPayementsTables which are not connected
            //     with table CathegoryOfMyIncomingPaymentsTables by a foreignKey value 

            AllegroChaosBusterDBContext myDB = new AllegroChaosBusterDBContext();
            return
                (
                from m in myDB.MyIncomingPaymentsTables
                join c in myDB.CategoryOfMyIncomingPaymentsTables
                    on m.PayTransID equals c.PayTransactionID into mc
                from c in mc.DefaultIfEmpty()
                where c == null
                select m
                );
        }
        public IEnumerable<MyIncomingPaymentsTable> GetDataFromDataBaseWithDeclaredCategory(string category)
        {
            //
            // Summary:
            //     This function returns all MyIncomingPayementsTables which are connected
            //     with table CathegoryOfMyIncomingPaymentsTables by a foreignKey value = inserted category
            AllegroChaosBusterDBContext myDB = new AllegroChaosBusterDBContext();
            return
                (
                from m in myDB.MyIncomingPaymentsTables
                join c in myDB.CategoryOfMyIncomingPaymentsTables
                    on m.PayTransID equals c.PayTransactionID into mc
                from c in mc
                where c.Category == category
                select m
                );
        }
        public IEnumerable<PayTransDatailsTable> GetPayTransDetailsForSpecyfiedID(long payTransId)
        {
            AllegroChaosBusterDBContext myDB = new AllegroChaosBusterDBContext();
            return
                (
                from p in myDB.PayTransDatailsTables
                where p.payTransID == payTransId
                select p
                );
        }
    }
}
