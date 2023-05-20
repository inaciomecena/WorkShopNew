using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class product_bc : GxSilentTrn, IGxSilentTrn
   {
      public product_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public product_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow056( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey056( ) ;
         standaloneModal( ) ;
         AddRow056( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z12ProductId = A12ProductId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_050( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls056( ) ;
            }
            else
            {
               CheckExtendedTable056( ) ;
               if ( AnyError == 0 )
               {
                  ZM056( 5) ;
                  ZM056( 6) ;
                  ZM056( 7) ;
                  ZM056( 8) ;
               }
               CloseExtendedTableCursors056( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12052( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11052( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM056( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z13ProductName = A13ProductName;
            Z26ProductDescription = A26ProductDescription;
            Z27ProductPrice = A27ProductPrice;
            Z6CategoryId = A6CategoryId;
            Z10SellerId = A10SellerId;
            Z14ProductCountryID = A14ProductCountryID;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z7CategoryName = A7CategoryName;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z18SellerName = A18SellerName;
            Z8CountryId = A8CountryId;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z39ProductCountryName = A39ProductCountryName;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z9CountryName = A9CountryName;
         }
         if ( GX_JID == -3 )
         {
            Z12ProductId = A12ProductId;
            Z13ProductName = A13ProductName;
            Z26ProductDescription = A26ProductDescription;
            Z27ProductPrice = A27ProductPrice;
            Z28ProductPhoto = A28ProductPhoto;
            Z40000ProductPhoto_GXI = A40000ProductPhoto_GXI;
            Z6CategoryId = A6CategoryId;
            Z10SellerId = A10SellerId;
            Z14ProductCountryID = A14ProductCountryID;
            Z39ProductCountryName = A39ProductCountryName;
            Z7CategoryName = A7CategoryName;
            Z18SellerName = A18SellerName;
            Z19SellerPhoto = A19SellerPhoto;
            Z40001SellerPhoto_GXI = A40001SellerPhoto_GXI;
            Z8CountryId = A8CountryId;
            Z9CountryName = A9CountryName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load056( )
      {
         /* Using cursor BC00058 */
         pr_default.execute(6, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound6 = 1;
            A13ProductName = BC00058_A13ProductName[0];
            A26ProductDescription = BC00058_A26ProductDescription[0];
            A27ProductPrice = BC00058_A27ProductPrice[0];
            A40000ProductPhoto_GXI = BC00058_A40000ProductPhoto_GXI[0];
            A39ProductCountryName = BC00058_A39ProductCountryName[0];
            A7CategoryName = BC00058_A7CategoryName[0];
            A18SellerName = BC00058_A18SellerName[0];
            A40001SellerPhoto_GXI = BC00058_A40001SellerPhoto_GXI[0];
            A9CountryName = BC00058_A9CountryName[0];
            A6CategoryId = BC00058_A6CategoryId[0];
            A10SellerId = BC00058_A10SellerId[0];
            A14ProductCountryID = BC00058_A14ProductCountryID[0];
            A8CountryId = BC00058_A8CountryId[0];
            A28ProductPhoto = BC00058_A28ProductPhoto[0];
            A19SellerPhoto = BC00058_A19SellerPhoto[0];
            ZM056( -3) ;
         }
         pr_default.close(6);
         OnLoadActions056( ) ;
      }

      protected void OnLoadActions056( )
      {
      }

      protected void CheckExtendedTable056( )
      {
         nIsDirty_6 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00059 */
         pr_default.execute(7, new Object[] {A13ProductName, A12ProductId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Product Name"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(7);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A13ProductName)) )
         {
            GX_msglist.addItem("Their name cannot be empty", 1, "");
            AnyError = 1;
         }
         if ( (Convert.ToDecimal(0)==A27ProductPrice) )
         {
            GX_msglist.addItem("Their price cannot be empty", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00056 */
         pr_default.execute(4, new Object[] {A14ProductCountryID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country Product'.", "ForeignKeyNotFound", 1, "PRODUCTCOUNTRYID");
            AnyError = 1;
         }
         A39ProductCountryName = BC00056_A39ProductCountryName[0];
         pr_default.close(4);
         /* Using cursor BC00054 */
         pr_default.execute(2, new Object[] {A6CategoryId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
         }
         A7CategoryName = BC00054_A7CategoryName[0];
         pr_default.close(2);
         /* Using cursor BC00055 */
         pr_default.execute(3, new Object[] {A10SellerId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Seller'.", "ForeignKeyNotFound", 1, "SELLERID");
            AnyError = 1;
         }
         A18SellerName = BC00055_A18SellerName[0];
         A40001SellerPhoto_GXI = BC00055_A40001SellerPhoto_GXI[0];
         A8CountryId = BC00055_A8CountryId[0];
         A19SellerPhoto = BC00055_A19SellerPhoto[0];
         pr_default.close(3);
         /* Using cursor BC00057 */
         pr_default.execute(5, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A9CountryName = BC00057_A9CountryName[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors056( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey056( )
      {
         /* Using cursor BC000510 */
         pr_default.execute(8, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00053 */
         pr_default.execute(1, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM056( 3) ;
            RcdFound6 = 1;
            A12ProductId = BC00053_A12ProductId[0];
            A13ProductName = BC00053_A13ProductName[0];
            A26ProductDescription = BC00053_A26ProductDescription[0];
            A27ProductPrice = BC00053_A27ProductPrice[0];
            A40000ProductPhoto_GXI = BC00053_A40000ProductPhoto_GXI[0];
            A6CategoryId = BC00053_A6CategoryId[0];
            A10SellerId = BC00053_A10SellerId[0];
            A14ProductCountryID = BC00053_A14ProductCountryID[0];
            A28ProductPhoto = BC00053_A28ProductPhoto[0];
            Z12ProductId = A12ProductId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load056( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey056( ) ;
            }
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey056( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode6;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey056( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_050( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency056( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00052 */
            pr_default.execute(0, new Object[] {A12ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z13ProductName, BC00052_A13ProductName[0]) != 0 ) || ( StringUtil.StrCmp(Z26ProductDescription, BC00052_A26ProductDescription[0]) != 0 ) || ( Z27ProductPrice != BC00052_A27ProductPrice[0] ) || ( Z6CategoryId != BC00052_A6CategoryId[0] ) || ( Z10SellerId != BC00052_A10SellerId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z14ProductCountryID != BC00052_A14ProductCountryID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Product"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert056( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable056( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM056( 0) ;
            CheckOptimisticConcurrency056( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm056( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert056( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000511 */
                     pr_default.execute(9, new Object[] {A13ProductName, A26ProductDescription, A27ProductPrice, A28ProductPhoto, A40000ProductPhoto_GXI, A6CategoryId, A10SellerId, A14ProductCountryID});
                     A12ProductId = BC000511_A12ProductId[0];
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Product");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load056( ) ;
            }
            EndLevel056( ) ;
         }
         CloseExtendedTableCursors056( ) ;
      }

      protected void Update056( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable056( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency056( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm056( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate056( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000512 */
                     pr_default.execute(10, new Object[] {A13ProductName, A26ProductDescription, A27ProductPrice, A6CategoryId, A10SellerId, A14ProductCountryID, A12ProductId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate056( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel056( ) ;
         }
         CloseExtendedTableCursors056( ) ;
      }

      protected void DeferredUpdate056( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000513 */
            pr_default.execute(11, new Object[] {A28ProductPhoto, A40000ProductPhoto_GXI, A12ProductId});
            pr_default.close(11);
            dsDefault.SmartCacheProvider.SetUpdated("Product");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency056( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls056( ) ;
            AfterConfirm056( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete056( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000514 */
                  pr_default.execute(12, new Object[] {A12ProductId});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("Product");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel056( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls056( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000515 */
            pr_default.execute(13, new Object[] {A14ProductCountryID});
            A39ProductCountryName = BC000515_A39ProductCountryName[0];
            pr_default.close(13);
            /* Using cursor BC000516 */
            pr_default.execute(14, new Object[] {A6CategoryId});
            A7CategoryName = BC000516_A7CategoryName[0];
            pr_default.close(14);
            /* Using cursor BC000517 */
            pr_default.execute(15, new Object[] {A10SellerId});
            A18SellerName = BC000517_A18SellerName[0];
            A40001SellerPhoto_GXI = BC000517_A40001SellerPhoto_GXI[0];
            A8CountryId = BC000517_A8CountryId[0];
            A19SellerPhoto = BC000517_A19SellerPhoto[0];
            pr_default.close(15);
            /* Using cursor BC000518 */
            pr_default.execute(16, new Object[] {A8CountryId});
            A9CountryName = BC000518_A9CountryName[0];
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000519 */
            pr_default.execute(17, new Object[] {A12ProductId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ShoppingCartProduct"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC000520 */
            pr_default.execute(18, new Object[] {A12ProductId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel056( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete056( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart056( )
      {
         /* Scan By routine */
         /* Using cursor BC000521 */
         pr_default.execute(19, new Object[] {A12ProductId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound6 = 1;
            A12ProductId = BC000521_A12ProductId[0];
            A13ProductName = BC000521_A13ProductName[0];
            A26ProductDescription = BC000521_A26ProductDescription[0];
            A27ProductPrice = BC000521_A27ProductPrice[0];
            A40000ProductPhoto_GXI = BC000521_A40000ProductPhoto_GXI[0];
            A39ProductCountryName = BC000521_A39ProductCountryName[0];
            A7CategoryName = BC000521_A7CategoryName[0];
            A18SellerName = BC000521_A18SellerName[0];
            A40001SellerPhoto_GXI = BC000521_A40001SellerPhoto_GXI[0];
            A9CountryName = BC000521_A9CountryName[0];
            A6CategoryId = BC000521_A6CategoryId[0];
            A10SellerId = BC000521_A10SellerId[0];
            A14ProductCountryID = BC000521_A14ProductCountryID[0];
            A8CountryId = BC000521_A8CountryId[0];
            A28ProductPhoto = BC000521_A28ProductPhoto[0];
            A19SellerPhoto = BC000521_A19SellerPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext056( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound6 = 0;
         ScanKeyLoad056( ) ;
      }

      protected void ScanKeyLoad056( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound6 = 1;
            A12ProductId = BC000521_A12ProductId[0];
            A13ProductName = BC000521_A13ProductName[0];
            A26ProductDescription = BC000521_A26ProductDescription[0];
            A27ProductPrice = BC000521_A27ProductPrice[0];
            A40000ProductPhoto_GXI = BC000521_A40000ProductPhoto_GXI[0];
            A39ProductCountryName = BC000521_A39ProductCountryName[0];
            A7CategoryName = BC000521_A7CategoryName[0];
            A18SellerName = BC000521_A18SellerName[0];
            A40001SellerPhoto_GXI = BC000521_A40001SellerPhoto_GXI[0];
            A9CountryName = BC000521_A9CountryName[0];
            A6CategoryId = BC000521_A6CategoryId[0];
            A10SellerId = BC000521_A10SellerId[0];
            A14ProductCountryID = BC000521_A14ProductCountryID[0];
            A8CountryId = BC000521_A8CountryId[0];
            A28ProductPhoto = BC000521_A28ProductPhoto[0];
            A19SellerPhoto = BC000521_A19SellerPhoto[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd056( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm056( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert056( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate056( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete056( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete056( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate056( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes056( )
      {
      }

      protected void send_integrity_lvl_hashes056( )
      {
      }

      protected void AddRow056( )
      {
         VarsToRow6( bcProduct) ;
      }

      protected void ReadRow056( )
      {
         RowToVars6( bcProduct, 1) ;
      }

      protected void InitializeNonKey056( )
      {
         A13ProductName = "";
         A26ProductDescription = "";
         A27ProductPrice = 0;
         A28ProductPhoto = "";
         A40000ProductPhoto_GXI = "";
         A14ProductCountryID = 0;
         A39ProductCountryName = "";
         A6CategoryId = 0;
         A7CategoryName = "";
         A10SellerId = 0;
         A18SellerName = "";
         A19SellerPhoto = "";
         A40001SellerPhoto_GXI = "";
         A8CountryId = 0;
         A9CountryName = "";
         Z13ProductName = "";
         Z26ProductDescription = "";
         Z27ProductPrice = 0;
         Z6CategoryId = 0;
         Z10SellerId = 0;
         Z14ProductCountryID = 0;
      }

      protected void InitAll056( )
      {
         A12ProductId = 0;
         InitializeNonKey056( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow6( SdtProduct obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Productname = A13ProductName;
         obj6.gxTpr_Productdescription = A26ProductDescription;
         obj6.gxTpr_Productprice = A27ProductPrice;
         obj6.gxTpr_Productphoto = A28ProductPhoto;
         obj6.gxTpr_Productphoto_gxi = A40000ProductPhoto_GXI;
         obj6.gxTpr_Productcountryid = A14ProductCountryID;
         obj6.gxTpr_Productcountryname = A39ProductCountryName;
         obj6.gxTpr_Categoryid = A6CategoryId;
         obj6.gxTpr_Categoryname = A7CategoryName;
         obj6.gxTpr_Sellerid = A10SellerId;
         obj6.gxTpr_Sellername = A18SellerName;
         obj6.gxTpr_Sellerphoto = A19SellerPhoto;
         obj6.gxTpr_Sellerphoto_gxi = A40001SellerPhoto_GXI;
         obj6.gxTpr_Countryid = A8CountryId;
         obj6.gxTpr_Countryname = A9CountryName;
         obj6.gxTpr_Productid = A12ProductId;
         obj6.gxTpr_Productid_Z = Z12ProductId;
         obj6.gxTpr_Productname_Z = Z13ProductName;
         obj6.gxTpr_Productdescription_Z = Z26ProductDescription;
         obj6.gxTpr_Productprice_Z = Z27ProductPrice;
         obj6.gxTpr_Productcountryid_Z = Z14ProductCountryID;
         obj6.gxTpr_Productcountryname_Z = Z39ProductCountryName;
         obj6.gxTpr_Categoryid_Z = Z6CategoryId;
         obj6.gxTpr_Categoryname_Z = Z7CategoryName;
         obj6.gxTpr_Sellerid_Z = Z10SellerId;
         obj6.gxTpr_Sellername_Z = Z18SellerName;
         obj6.gxTpr_Countryid_Z = Z8CountryId;
         obj6.gxTpr_Countryname_Z = Z9CountryName;
         obj6.gxTpr_Productphoto_gxi_Z = Z40000ProductPhoto_GXI;
         obj6.gxTpr_Sellerphoto_gxi_Z = Z40001SellerPhoto_GXI;
         obj6.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow6( SdtProduct obj6 )
      {
         obj6.gxTpr_Productid = A12ProductId;
         return  ;
      }

      public void RowToVars6( SdtProduct obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A13ProductName = obj6.gxTpr_Productname;
         A26ProductDescription = obj6.gxTpr_Productdescription;
         A27ProductPrice = obj6.gxTpr_Productprice;
         A28ProductPhoto = obj6.gxTpr_Productphoto;
         A40000ProductPhoto_GXI = obj6.gxTpr_Productphoto_gxi;
         A14ProductCountryID = obj6.gxTpr_Productcountryid;
         A39ProductCountryName = obj6.gxTpr_Productcountryname;
         A6CategoryId = obj6.gxTpr_Categoryid;
         A7CategoryName = obj6.gxTpr_Categoryname;
         A10SellerId = obj6.gxTpr_Sellerid;
         A18SellerName = obj6.gxTpr_Sellername;
         A19SellerPhoto = obj6.gxTpr_Sellerphoto;
         A40001SellerPhoto_GXI = obj6.gxTpr_Sellerphoto_gxi;
         A8CountryId = obj6.gxTpr_Countryid;
         A9CountryName = obj6.gxTpr_Countryname;
         A12ProductId = obj6.gxTpr_Productid;
         Z12ProductId = obj6.gxTpr_Productid_Z;
         Z13ProductName = obj6.gxTpr_Productname_Z;
         Z26ProductDescription = obj6.gxTpr_Productdescription_Z;
         Z27ProductPrice = obj6.gxTpr_Productprice_Z;
         Z14ProductCountryID = obj6.gxTpr_Productcountryid_Z;
         Z39ProductCountryName = obj6.gxTpr_Productcountryname_Z;
         Z6CategoryId = obj6.gxTpr_Categoryid_Z;
         Z7CategoryName = obj6.gxTpr_Categoryname_Z;
         Z10SellerId = obj6.gxTpr_Sellerid_Z;
         Z18SellerName = obj6.gxTpr_Sellername_Z;
         Z8CountryId = obj6.gxTpr_Countryid_Z;
         Z9CountryName = obj6.gxTpr_Countryname_Z;
         Z40000ProductPhoto_GXI = obj6.gxTpr_Productphoto_gxi_Z;
         Z40001SellerPhoto_GXI = obj6.gxTpr_Sellerphoto_gxi_Z;
         Gx_mode = obj6.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A12ProductId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey056( ) ;
         ScanKeyStart056( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z12ProductId = A12ProductId;
         }
         ZM056( -3) ;
         OnLoadActions056( ) ;
         AddRow056( ) ;
         ScanKeyEnd056( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars6( bcProduct, 0) ;
         ScanKeyStart056( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z12ProductId = A12ProductId;
         }
         ZM056( -3) ;
         OnLoadActions056( ) ;
         AddRow056( ) ;
         ScanKeyEnd056( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey056( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert056( ) ;
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A12ProductId != Z12ProductId )
               {
                  A12ProductId = Z12ProductId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update056( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A12ProductId != Z12ProductId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert056( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert056( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars6( bcProduct, 1) ;
         SaveImpl( ) ;
         VarsToRow6( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars6( bcProduct, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert056( ) ;
         AfterTrn( ) ;
         VarsToRow6( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdtProduct auxBC = new SdtProduct(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A12ProductId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProduct);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars6( bcProduct, 1) ;
         UpdateImpl( ) ;
         VarsToRow6( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars6( bcProduct, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert056( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow6( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcProduct, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey056( ) ;
         if ( RcdFound6 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A12ProductId != Z12ProductId )
            {
               A12ProductId = Z12ProductId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A12ProductId != Z12ProductId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(13);
         pr_default.close(16);
         context.RollbackDataStores("product_bc",pr_default);
         VarsToRow6( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcProduct.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProduct.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProduct )
         {
            bcProduct = (SdtProduct)(sdt);
            if ( StringUtil.StrCmp(bcProduct.gxTpr_Mode, "") == 0 )
            {
               bcProduct.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow6( bcProduct) ;
            }
            else
            {
               RowToVars6( bcProduct, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProduct.gxTpr_Mode, "") == 0 )
            {
               bcProduct.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars6( bcProduct, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtProduct Product_BC
      {
         get {
            return bcProduct ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(13);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z13ProductName = "";
         A13ProductName = "";
         Z26ProductDescription = "";
         A26ProductDescription = "";
         Z7CategoryName = "";
         A7CategoryName = "";
         Z18SellerName = "";
         A18SellerName = "";
         Z39ProductCountryName = "";
         A39ProductCountryName = "";
         Z9CountryName = "";
         A9CountryName = "";
         Z28ProductPhoto = "";
         A28ProductPhoto = "";
         Z40000ProductPhoto_GXI = "";
         A40000ProductPhoto_GXI = "";
         Z19SellerPhoto = "";
         A19SellerPhoto = "";
         Z40001SellerPhoto_GXI = "";
         A40001SellerPhoto_GXI = "";
         BC00058_A12ProductId = new short[1] ;
         BC00058_A13ProductName = new string[] {""} ;
         BC00058_A26ProductDescription = new string[] {""} ;
         BC00058_A27ProductPrice = new decimal[1] ;
         BC00058_A40000ProductPhoto_GXI = new string[] {""} ;
         BC00058_A39ProductCountryName = new string[] {""} ;
         BC00058_A7CategoryName = new string[] {""} ;
         BC00058_A18SellerName = new string[] {""} ;
         BC00058_A40001SellerPhoto_GXI = new string[] {""} ;
         BC00058_A9CountryName = new string[] {""} ;
         BC00058_A6CategoryId = new short[1] ;
         BC00058_A10SellerId = new short[1] ;
         BC00058_A14ProductCountryID = new short[1] ;
         BC00058_A8CountryId = new short[1] ;
         BC00058_A28ProductPhoto = new string[] {""} ;
         BC00058_A19SellerPhoto = new string[] {""} ;
         BC00059_A13ProductName = new string[] {""} ;
         BC00056_A39ProductCountryName = new string[] {""} ;
         BC00054_A7CategoryName = new string[] {""} ;
         BC00055_A18SellerName = new string[] {""} ;
         BC00055_A40001SellerPhoto_GXI = new string[] {""} ;
         BC00055_A8CountryId = new short[1] ;
         BC00055_A19SellerPhoto = new string[] {""} ;
         BC00057_A9CountryName = new string[] {""} ;
         BC000510_A12ProductId = new short[1] ;
         BC00053_A12ProductId = new short[1] ;
         BC00053_A13ProductName = new string[] {""} ;
         BC00053_A26ProductDescription = new string[] {""} ;
         BC00053_A27ProductPrice = new decimal[1] ;
         BC00053_A40000ProductPhoto_GXI = new string[] {""} ;
         BC00053_A6CategoryId = new short[1] ;
         BC00053_A10SellerId = new short[1] ;
         BC00053_A14ProductCountryID = new short[1] ;
         BC00053_A28ProductPhoto = new string[] {""} ;
         sMode6 = "";
         BC00052_A12ProductId = new short[1] ;
         BC00052_A13ProductName = new string[] {""} ;
         BC00052_A26ProductDescription = new string[] {""} ;
         BC00052_A27ProductPrice = new decimal[1] ;
         BC00052_A40000ProductPhoto_GXI = new string[] {""} ;
         BC00052_A6CategoryId = new short[1] ;
         BC00052_A10SellerId = new short[1] ;
         BC00052_A14ProductCountryID = new short[1] ;
         BC00052_A28ProductPhoto = new string[] {""} ;
         BC000511_A12ProductId = new short[1] ;
         BC000515_A39ProductCountryName = new string[] {""} ;
         BC000516_A7CategoryName = new string[] {""} ;
         BC000517_A18SellerName = new string[] {""} ;
         BC000517_A40001SellerPhoto_GXI = new string[] {""} ;
         BC000517_A8CountryId = new short[1] ;
         BC000517_A19SellerPhoto = new string[] {""} ;
         BC000518_A9CountryName = new string[] {""} ;
         BC000519_A16ShoppingCartId = new short[1] ;
         BC000519_A12ProductId = new short[1] ;
         BC000520_A15PromotionId = new short[1] ;
         BC000520_A12ProductId = new short[1] ;
         BC000521_A12ProductId = new short[1] ;
         BC000521_A13ProductName = new string[] {""} ;
         BC000521_A26ProductDescription = new string[] {""} ;
         BC000521_A27ProductPrice = new decimal[1] ;
         BC000521_A40000ProductPhoto_GXI = new string[] {""} ;
         BC000521_A39ProductCountryName = new string[] {""} ;
         BC000521_A7CategoryName = new string[] {""} ;
         BC000521_A18SellerName = new string[] {""} ;
         BC000521_A40001SellerPhoto_GXI = new string[] {""} ;
         BC000521_A9CountryName = new string[] {""} ;
         BC000521_A6CategoryId = new short[1] ;
         BC000521_A10SellerId = new short[1] ;
         BC000521_A14ProductCountryID = new short[1] ;
         BC000521_A8CountryId = new short[1] ;
         BC000521_A28ProductPhoto = new string[] {""} ;
         BC000521_A19SellerPhoto = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.product_bc__default(),
            new Object[][] {
                new Object[] {
               BC00052_A12ProductId, BC00052_A13ProductName, BC00052_A26ProductDescription, BC00052_A27ProductPrice, BC00052_A40000ProductPhoto_GXI, BC00052_A6CategoryId, BC00052_A10SellerId, BC00052_A14ProductCountryID, BC00052_A28ProductPhoto
               }
               , new Object[] {
               BC00053_A12ProductId, BC00053_A13ProductName, BC00053_A26ProductDescription, BC00053_A27ProductPrice, BC00053_A40000ProductPhoto_GXI, BC00053_A6CategoryId, BC00053_A10SellerId, BC00053_A14ProductCountryID, BC00053_A28ProductPhoto
               }
               , new Object[] {
               BC00054_A7CategoryName
               }
               , new Object[] {
               BC00055_A18SellerName, BC00055_A40001SellerPhoto_GXI, BC00055_A8CountryId, BC00055_A19SellerPhoto
               }
               , new Object[] {
               BC00056_A39ProductCountryName
               }
               , new Object[] {
               BC00057_A9CountryName
               }
               , new Object[] {
               BC00058_A12ProductId, BC00058_A13ProductName, BC00058_A26ProductDescription, BC00058_A27ProductPrice, BC00058_A40000ProductPhoto_GXI, BC00058_A39ProductCountryName, BC00058_A7CategoryName, BC00058_A18SellerName, BC00058_A40001SellerPhoto_GXI, BC00058_A9CountryName,
               BC00058_A6CategoryId, BC00058_A10SellerId, BC00058_A14ProductCountryID, BC00058_A8CountryId, BC00058_A28ProductPhoto, BC00058_A19SellerPhoto
               }
               , new Object[] {
               BC00059_A13ProductName
               }
               , new Object[] {
               BC000510_A12ProductId
               }
               , new Object[] {
               BC000511_A12ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000515_A39ProductCountryName
               }
               , new Object[] {
               BC000516_A7CategoryName
               }
               , new Object[] {
               BC000517_A18SellerName, BC000517_A40001SellerPhoto_GXI, BC000517_A8CountryId, BC000517_A19SellerPhoto
               }
               , new Object[] {
               BC000518_A9CountryName
               }
               , new Object[] {
               BC000519_A16ShoppingCartId, BC000519_A12ProductId
               }
               , new Object[] {
               BC000520_A15PromotionId, BC000520_A12ProductId
               }
               , new Object[] {
               BC000521_A12ProductId, BC000521_A13ProductName, BC000521_A26ProductDescription, BC000521_A27ProductPrice, BC000521_A40000ProductPhoto_GXI, BC000521_A39ProductCountryName, BC000521_A7CategoryName, BC000521_A18SellerName, BC000521_A40001SellerPhoto_GXI, BC000521_A9CountryName,
               BC000521_A6CategoryId, BC000521_A10SellerId, BC000521_A14ProductCountryID, BC000521_A8CountryId, BC000521_A28ProductPhoto, BC000521_A19SellerPhoto
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12052 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z12ProductId ;
      private short A12ProductId ;
      private short GX_JID ;
      private short Z6CategoryId ;
      private short A6CategoryId ;
      private short Z10SellerId ;
      private short A10SellerId ;
      private short Z14ProductCountryID ;
      private short A14ProductCountryID ;
      private short Z8CountryId ;
      private short A8CountryId ;
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private int trnEnded ;
      private decimal Z27ProductPrice ;
      private decimal A27ProductPrice ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z13ProductName ;
      private string A13ProductName ;
      private string Z26ProductDescription ;
      private string A26ProductDescription ;
      private string Z7CategoryName ;
      private string A7CategoryName ;
      private string Z18SellerName ;
      private string A18SellerName ;
      private string Z39ProductCountryName ;
      private string A39ProductCountryName ;
      private string Z9CountryName ;
      private string A9CountryName ;
      private string sMode6 ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z40000ProductPhoto_GXI ;
      private string A40000ProductPhoto_GXI ;
      private string Z40001SellerPhoto_GXI ;
      private string A40001SellerPhoto_GXI ;
      private string Z28ProductPhoto ;
      private string A28ProductPhoto ;
      private string Z19SellerPhoto ;
      private string A19SellerPhoto ;
      private SdtProduct bcProduct ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00058_A12ProductId ;
      private string[] BC00058_A13ProductName ;
      private string[] BC00058_A26ProductDescription ;
      private decimal[] BC00058_A27ProductPrice ;
      private string[] BC00058_A40000ProductPhoto_GXI ;
      private string[] BC00058_A39ProductCountryName ;
      private string[] BC00058_A7CategoryName ;
      private string[] BC00058_A18SellerName ;
      private string[] BC00058_A40001SellerPhoto_GXI ;
      private string[] BC00058_A9CountryName ;
      private short[] BC00058_A6CategoryId ;
      private short[] BC00058_A10SellerId ;
      private short[] BC00058_A14ProductCountryID ;
      private short[] BC00058_A8CountryId ;
      private string[] BC00058_A28ProductPhoto ;
      private string[] BC00058_A19SellerPhoto ;
      private string[] BC00059_A13ProductName ;
      private string[] BC00056_A39ProductCountryName ;
      private string[] BC00054_A7CategoryName ;
      private string[] BC00055_A18SellerName ;
      private string[] BC00055_A40001SellerPhoto_GXI ;
      private short[] BC00055_A8CountryId ;
      private string[] BC00055_A19SellerPhoto ;
      private string[] BC00057_A9CountryName ;
      private short[] BC000510_A12ProductId ;
      private short[] BC00053_A12ProductId ;
      private string[] BC00053_A13ProductName ;
      private string[] BC00053_A26ProductDescription ;
      private decimal[] BC00053_A27ProductPrice ;
      private string[] BC00053_A40000ProductPhoto_GXI ;
      private short[] BC00053_A6CategoryId ;
      private short[] BC00053_A10SellerId ;
      private short[] BC00053_A14ProductCountryID ;
      private string[] BC00053_A28ProductPhoto ;
      private short[] BC00052_A12ProductId ;
      private string[] BC00052_A13ProductName ;
      private string[] BC00052_A26ProductDescription ;
      private decimal[] BC00052_A27ProductPrice ;
      private string[] BC00052_A40000ProductPhoto_GXI ;
      private short[] BC00052_A6CategoryId ;
      private short[] BC00052_A10SellerId ;
      private short[] BC00052_A14ProductCountryID ;
      private string[] BC00052_A28ProductPhoto ;
      private short[] BC000511_A12ProductId ;
      private string[] BC000515_A39ProductCountryName ;
      private string[] BC000516_A7CategoryName ;
      private string[] BC000517_A18SellerName ;
      private string[] BC000517_A40001SellerPhoto_GXI ;
      private short[] BC000517_A8CountryId ;
      private string[] BC000517_A19SellerPhoto ;
      private string[] BC000518_A9CountryName ;
      private short[] BC000519_A16ShoppingCartId ;
      private short[] BC000519_A12ProductId ;
      private short[] BC000520_A15PromotionId ;
      private short[] BC000520_A12ProductId ;
      private short[] BC000521_A12ProductId ;
      private string[] BC000521_A13ProductName ;
      private string[] BC000521_A26ProductDescription ;
      private decimal[] BC000521_A27ProductPrice ;
      private string[] BC000521_A40000ProductPhoto_GXI ;
      private string[] BC000521_A39ProductCountryName ;
      private string[] BC000521_A7CategoryName ;
      private string[] BC000521_A18SellerName ;
      private string[] BC000521_A40001SellerPhoto_GXI ;
      private string[] BC000521_A9CountryName ;
      private short[] BC000521_A6CategoryId ;
      private short[] BC000521_A10SellerId ;
      private short[] BC000521_A14ProductCountryID ;
      private short[] BC000521_A8CountryId ;
      private string[] BC000521_A28ProductPhoto ;
      private string[] BC000521_A19SellerPhoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class product_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00058;
          prmBC00058 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00059;
          prmBC00059 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00056;
          prmBC00056 = new Object[] {
          new ParDef("@ProductCountryID",GXType.Int16,4,0)
          };
          Object[] prmBC00054;
          prmBC00054 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmBC00055;
          prmBC00055 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmBC00057;
          prmBC00057 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000510;
          prmBC000510 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00053;
          prmBC00053 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00052;
          prmBC00052 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000511;
          prmBC000511 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductDescription",GXType.NChar,50,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,8,2) ,
          new ParDef("@ProductPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Product", Fld="ProductPhoto"} ,
          new ParDef("@CategoryId",GXType.Int16,4,0) ,
          new ParDef("@SellerId",GXType.Int16,4,0) ,
          new ParDef("@ProductCountryID",GXType.Int16,4,0)
          };
          Object[] prmBC000512;
          prmBC000512 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductDescription",GXType.NChar,50,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,8,2) ,
          new ParDef("@CategoryId",GXType.Int16,4,0) ,
          new ParDef("@SellerId",GXType.Int16,4,0) ,
          new ParDef("@ProductCountryID",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000513;
          prmBC000513 = new Object[] {
          new ParDef("@ProductPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Product", Fld="ProductPhoto"} ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000514;
          prmBC000514 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000515;
          prmBC000515 = new Object[] {
          new ParDef("@ProductCountryID",GXType.Int16,4,0)
          };
          Object[] prmBC000516;
          prmBC000516 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmBC000517;
          prmBC000517 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmBC000518;
          prmBC000518 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000519;
          prmBC000519 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000520;
          prmBC000520 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000521;
          prmBC000521 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00052", "SELECT [ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductPhoto_GXI], [CategoryId], [SellerId], [ProductCountryID] AS ProductCountryID, [ProductPhoto] FROM [Product] WITH (UPDLOCK) WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00053", "SELECT [ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductPhoto_GXI], [CategoryId], [SellerId], [ProductCountryID] AS ProductCountryID, [ProductPhoto] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00054", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00055", "SELECT [SellerName], [SellerPhoto_GXI], [CountryId], [SellerPhoto] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00056", "SELECT [CountryName] AS ProductCountryName FROM [Country] WHERE [CountryId] = @ProductCountryID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00057", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00058", "SELECT TM1.[ProductId], TM1.[ProductName], TM1.[ProductDescription], TM1.[ProductPrice], TM1.[ProductPhoto_GXI], T2.[CountryName] AS ProductCountryName, T3.[CategoryName], T4.[SellerName], T4.[SellerPhoto_GXI], T5.[CountryName], TM1.[CategoryId], TM1.[SellerId], TM1.[ProductCountryID] AS ProductCountryID, T4.[CountryId], TM1.[ProductPhoto], T4.[SellerPhoto] FROM (((([Product] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[ProductCountryID]) INNER JOIN [Category] T3 ON T3.[CategoryId] = TM1.[CategoryId]) INNER JOIN [Seller] T4 ON T4.[SellerId] = TM1.[SellerId]) INNER JOIN [Country] T5 ON T5.[CountryId] = T4.[CountryId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00058,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00059", "SELECT [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName) AND (Not ( [ProductId] = @ProductId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000510", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000510,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000511", "INSERT INTO [Product]([ProductName], [ProductDescription], [ProductPrice], [ProductPhoto], [ProductPhoto_GXI], [CategoryId], [SellerId], [ProductCountryID]) VALUES(@ProductName, @ProductDescription, @ProductPrice, @ProductPhoto, @ProductPhoto_GXI, @CategoryId, @SellerId, @ProductCountryID); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC000511)
             ,new CursorDef("BC000512", "UPDATE [Product] SET [ProductName]=@ProductName, [ProductDescription]=@ProductDescription, [ProductPrice]=@ProductPrice, [CategoryId]=@CategoryId, [SellerId]=@SellerId, [ProductCountryID]=@ProductCountryID  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000512)
             ,new CursorDef("BC000513", "UPDATE [Product] SET [ProductPhoto]=@ProductPhoto, [ProductPhoto_GXI]=@ProductPhoto_GXI  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000513)
             ,new CursorDef("BC000514", "DELETE FROM [Product]  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000514)
             ,new CursorDef("BC000515", "SELECT [CountryName] AS ProductCountryName FROM [Country] WHERE [CountryId] = @ProductCountryID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000515,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000516", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000516,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000517", "SELECT [SellerName], [SellerPhoto_GXI], [CountryId], [SellerPhoto] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000517,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000518", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000518,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000519", "SELECT TOP 1 [ShoppingCartId], [ProductId] FROM [ShoppingCartProduct] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000519,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000520", "SELECT TOP 1 [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000520,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000521", "SELECT TM1.[ProductId], TM1.[ProductName], TM1.[ProductDescription], TM1.[ProductPrice], TM1.[ProductPhoto_GXI], T2.[CountryName] AS ProductCountryName, T3.[CategoryName], T4.[SellerName], T4.[SellerPhoto_GXI], T5.[CountryName], TM1.[CategoryId], TM1.[SellerId], TM1.[ProductCountryID] AS ProductCountryID, T4.[CountryId], TM1.[ProductPhoto], T4.[SellerPhoto] FROM (((([Product] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[ProductCountryID]) INNER JOIN [Category] T3 ON T3.[CategoryId] = TM1.[CategoryId]) INNER JOIN [Seller] T4 ON T4.[SellerId] = TM1.[SellerId]) INNER JOIN [Country] T5 ON T5.[CountryId] = T4.[CountryId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000521,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(9));
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(9));
                return;
       }
    }

 }

}
