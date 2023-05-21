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
   public class shoppingcart_bc : GxSilentTrn, IGxSilentTrn
   {
      public shoppingcart_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public shoppingcart_bc( IGxContext context )
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
         ReadRow069( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey069( ) ;
         standaloneModal( ) ;
         AddRow069( ) ;
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
            E11062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z16ShoppingCartId = A16ShoppingCartId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls069( ) ;
            }
            else
            {
               CheckExtendedTable069( ) ;
               if ( AnyError == 0 )
               {
                  ZM069( 8) ;
                  ZM069( 9) ;
                  ZM069( 10) ;
               }
               CloseExtendedTableCursors069( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode9 = Gx_mode;
            CONFIRM_0610( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode9;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode9;
         }
      }

      protected void CONFIRM_0610( )
      {
         s34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
         n34ShoppingCartFinalPrice = false;
         nGXsfl_10_idx = 0;
         while ( nGXsfl_10_idx < bcShoppingCart.gxTpr_Product.Count )
         {
            ReadRow0610( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound10 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_10 != 0 ) )
            {
               GetKey0610( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound10 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0610( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0610( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0610( 12) ;
                           ZM0610( 13) ;
                        }
                        CloseExtendedTableCursors0610( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                        O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
                        n34ShoppingCartFinalPrice = false;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound10 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0610( ) ;
                        Load0610( ) ;
                        BeforeValidate0610( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0610( ) ;
                           O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
                           n34ShoppingCartFinalPrice = false;
                        }
                     }
                     else
                     {
                        if ( nIsMod_10 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0610( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0610( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0610( 12) ;
                                 ZM0610( 13) ;
                              }
                              CloseExtendedTableCursors0610( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                              O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
                              n34ShoppingCartFinalPrice = false;
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow10( ((SdtShoppingCart_Product)bcShoppingCart.gxTpr_Product.Item(nGXsfl_10_idx))) ;
            }
         }
         O34ShoppingCartFinalPrice = s34ShoppingCartFinalPrice;
         n34ShoppingCartFinalPrice = false;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12062( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.PopUp(formatLink("ashoppingcartdetail.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A16ShoppingCartId,4,0))}, new string[] {"ShoppingCartId"}) , new Object[] {"A16ShoppingCartId"});
         /*  Sending Event outputs  */
      }

      protected void ZM069( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z33ShoppingCartDate = A33ShoppingCartDate;
            Z11CustomerId = A11CustomerId;
            Z38ShoppingCartDateDelivery = A38ShoppingCartDateDelivery;
            Z34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z20CustomerName = A20CustomerName;
            Z21CustomerAddress = A21CustomerAddress;
            Z23CustomerPhone = A23CustomerPhone;
            Z8CountryId = A8CountryId;
            Z38ShoppingCartDateDelivery = A38ShoppingCartDateDelivery;
            Z34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z9CountryName = A9CountryName;
            Z38ShoppingCartDateDelivery = A38ShoppingCartDateDelivery;
            Z34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z38ShoppingCartDateDelivery = A38ShoppingCartDateDelivery;
            Z34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
         }
         if ( GX_JID == -7 )
         {
            Z16ShoppingCartId = A16ShoppingCartId;
            Z33ShoppingCartDate = A33ShoppingCartDate;
            Z11CustomerId = A11CustomerId;
            Z34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
            Z20CustomerName = A20CustomerName;
            Z21CustomerAddress = A21CustomerAddress;
            Z23CustomerPhone = A23CustomerPhone;
            Z8CountryId = A8CountryId;
            Z9CountryName = A9CountryName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A33ShoppingCartDate) && ( Gx_BScreen == 0 ) )
         {
            A33ShoppingCartDate = DateTimeUtil.Today( context);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            A38ShoppingCartDateDelivery = DateTimeUtil.DAdd(A33ShoppingCartDate,+((int)(5)));
         }
      }

      protected void Load069( )
      {
         /* Using cursor BC000613 */
         pr_default.execute(9, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound9 = 1;
            A33ShoppingCartDate = BC000613_A33ShoppingCartDate[0];
            A20CustomerName = BC000613_A20CustomerName[0];
            A9CountryName = BC000613_A9CountryName[0];
            A21CustomerAddress = BC000613_A21CustomerAddress[0];
            A23CustomerPhone = BC000613_A23CustomerPhone[0];
            A11CustomerId = BC000613_A11CustomerId[0];
            A8CountryId = BC000613_A8CountryId[0];
            A34ShoppingCartFinalPrice = BC000613_A34ShoppingCartFinalPrice[0];
            n34ShoppingCartFinalPrice = BC000613_n34ShoppingCartFinalPrice[0];
            ZM069( -7) ;
         }
         pr_default.close(9);
         OnLoadActions069( ) ;
      }

      protected void OnLoadActions069( )
      {
         O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
         n34ShoppingCartFinalPrice = false;
         A38ShoppingCartDateDelivery = DateTimeUtil.DAdd(A33ShoppingCartDate,+((int)(5)));
      }

      protected void CheckExtendedTable069( )
      {
         nIsDirty_9 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000611 */
         pr_default.execute(8, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A34ShoppingCartFinalPrice = BC000611_A34ShoppingCartFinalPrice[0];
            n34ShoppingCartFinalPrice = BC000611_n34ShoppingCartFinalPrice[0];
         }
         else
         {
            nIsDirty_9 = 1;
            A34ShoppingCartFinalPrice = 0;
            n34ShoppingCartFinalPrice = false;
         }
         pr_default.close(8);
         if ( ! ( (DateTime.MinValue==A33ShoppingCartDate) || ( DateTimeUtil.ResetTime ( A33ShoppingCartDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Shopping Cart Date fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         nIsDirty_9 = 1;
         A38ShoppingCartDateDelivery = DateTimeUtil.DAdd(A33ShoppingCartDate,+((int)(5)));
         /* Using cursor BC00068 */
         pr_default.execute(6, new Object[] {A11CustomerId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
         }
         A20CustomerName = BC00068_A20CustomerName[0];
         A21CustomerAddress = BC00068_A21CustomerAddress[0];
         A23CustomerPhone = BC00068_A23CustomerPhone[0];
         A8CountryId = BC00068_A8CountryId[0];
         pr_default.close(6);
         /* Using cursor BC00069 */
         pr_default.execute(7, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A9CountryName = BC00069_A9CountryName[0];
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors069( )
      {
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey069( )
      {
         /* Using cursor BC000614 */
         pr_default.execute(10, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00067 */
         pr_default.execute(5, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM069( 7) ;
            RcdFound9 = 1;
            A16ShoppingCartId = BC00067_A16ShoppingCartId[0];
            A33ShoppingCartDate = BC00067_A33ShoppingCartDate[0];
            A11CustomerId = BC00067_A11CustomerId[0];
            Z16ShoppingCartId = A16ShoppingCartId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load069( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey069( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey069( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey069( ) ;
         if ( RcdFound9 == 0 )
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
         CONFIRM_060( ) ;
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

      protected void CheckOptimisticConcurrency069( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00066 */
            pr_default.execute(4, new Object[] {A16ShoppingCartId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCart"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( DateTimeUtil.ResetTime ( Z33ShoppingCartDate ) != DateTimeUtil.ResetTime ( BC00066_A33ShoppingCartDate[0] ) ) || ( Z11CustomerId != BC00066_A11CustomerId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ShoppingCart"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert069( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM069( 0) ;
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000615 */
                     pr_default.execute(11, new Object[] {A33ShoppingCartDate, A11CustomerId});
                     A16ShoppingCartId = BC000615_A16ShoppingCartId[0];
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel069( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load069( ) ;
            }
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void Update069( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000616 */
                     pr_default.execute(12, new Object[] {A33ShoppingCartDate, A11CustomerId, A16ShoppingCartId});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCart"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate069( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel069( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void DeferredUpdate069( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls069( ) ;
            AfterConfirm069( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete069( ) ;
               if ( AnyError == 0 )
               {
                  A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
                  n34ShoppingCartFinalPrice = false;
                  ScanKeyStart0610( ) ;
                  while ( RcdFound10 != 0 )
                  {
                     getByPrimaryKey0610( ) ;
                     Delete0610( ) ;
                     ScanKeyNext0610( ) ;
                     O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
                     n34ShoppingCartFinalPrice = false;
                  }
                  ScanKeyEnd0610( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000617 */
                     pr_default.execute(13, new Object[] {A16ShoppingCartId});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCart");
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
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel069( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls069( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000619 */
            pr_default.execute(14, new Object[] {A16ShoppingCartId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A34ShoppingCartFinalPrice = BC000619_A34ShoppingCartFinalPrice[0];
               n34ShoppingCartFinalPrice = BC000619_n34ShoppingCartFinalPrice[0];
            }
            else
            {
               A34ShoppingCartFinalPrice = 0;
               n34ShoppingCartFinalPrice = false;
            }
            pr_default.close(14);
            A38ShoppingCartDateDelivery = DateTimeUtil.DAdd(A33ShoppingCartDate,+((int)(5)));
            /* Using cursor BC000620 */
            pr_default.execute(15, new Object[] {A11CustomerId});
            A20CustomerName = BC000620_A20CustomerName[0];
            A21CustomerAddress = BC000620_A21CustomerAddress[0];
            A23CustomerPhone = BC000620_A23CustomerPhone[0];
            A8CountryId = BC000620_A8CountryId[0];
            pr_default.close(15);
            /* Using cursor BC000621 */
            pr_default.execute(16, new Object[] {A8CountryId});
            A9CountryName = BC000621_A9CountryName[0];
            pr_default.close(16);
         }
      }

      protected void ProcessNestedLevel0610( )
      {
         s34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
         n34ShoppingCartFinalPrice = false;
         nGXsfl_10_idx = 0;
         while ( nGXsfl_10_idx < bcShoppingCart.gxTpr_Product.Count )
         {
            ReadRow0610( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound10 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_10 != 0 ) )
            {
               standaloneNotModal0610( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0610( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0610( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0610( ) ;
                  }
               }
               O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
               n34ShoppingCartFinalPrice = false;
            }
            KeyVarsToRow10( ((SdtShoppingCart_Product)bcShoppingCart.gxTpr_Product.Item(nGXsfl_10_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_10_idx = 0;
            while ( nGXsfl_10_idx < bcShoppingCart.gxTpr_Product.Count )
            {
               ReadRow0610( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound10 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcShoppingCart.gxTpr_Product.RemoveElement(nGXsfl_10_idx);
                  nGXsfl_10_idx = (int)(nGXsfl_10_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0610( ) ;
                  VarsToRow10( ((SdtShoppingCart_Product)bcShoppingCart.gxTpr_Product.Item(nGXsfl_10_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0610( ) ;
         if ( AnyError != 0 )
         {
            O34ShoppingCartFinalPrice = s34ShoppingCartFinalPrice;
            n34ShoppingCartFinalPrice = false;
         }
         nRcdExists_10 = 0;
         nIsMod_10 = 0;
         Gxremove10 = 0;
      }

      protected void ProcessLevel069( )
      {
         /* Save parent mode. */
         sMode9 = Gx_mode;
         ProcessNestedLevel0610( ) ;
         if ( AnyError != 0 )
         {
            O34ShoppingCartFinalPrice = s34ShoppingCartFinalPrice;
            n34ShoppingCartFinalPrice = false;
         }
         /* Restore parent mode. */
         Gx_mode = sMode9;
         /* ' Update level parameters */
      }

      protected void EndLevel069( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete069( ) ;
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

      public void ScanKeyStart069( )
      {
         /* Scan By routine */
         /* Using cursor BC000623 */
         pr_default.execute(17, new Object[] {A16ShoppingCartId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound9 = 1;
            A16ShoppingCartId = BC000623_A16ShoppingCartId[0];
            A33ShoppingCartDate = BC000623_A33ShoppingCartDate[0];
            A20CustomerName = BC000623_A20CustomerName[0];
            A9CountryName = BC000623_A9CountryName[0];
            A21CustomerAddress = BC000623_A21CustomerAddress[0];
            A23CustomerPhone = BC000623_A23CustomerPhone[0];
            A11CustomerId = BC000623_A11CustomerId[0];
            A8CountryId = BC000623_A8CountryId[0];
            A34ShoppingCartFinalPrice = BC000623_A34ShoppingCartFinalPrice[0];
            n34ShoppingCartFinalPrice = BC000623_n34ShoppingCartFinalPrice[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext069( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound9 = 0;
         ScanKeyLoad069( ) ;
      }

      protected void ScanKeyLoad069( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound9 = 1;
            A16ShoppingCartId = BC000623_A16ShoppingCartId[0];
            A33ShoppingCartDate = BC000623_A33ShoppingCartDate[0];
            A20CustomerName = BC000623_A20CustomerName[0];
            A9CountryName = BC000623_A9CountryName[0];
            A21CustomerAddress = BC000623_A21CustomerAddress[0];
            A23CustomerPhone = BC000623_A23CustomerPhone[0];
            A11CustomerId = BC000623_A11CustomerId[0];
            A8CountryId = BC000623_A8CountryId[0];
            A34ShoppingCartFinalPrice = BC000623_A34ShoppingCartFinalPrice[0];
            n34ShoppingCartFinalPrice = BC000623_n34ShoppingCartFinalPrice[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd069( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm069( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert069( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate069( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete069( )
      {
         /* Before Delete Rules */
         if ( DateTimeUtil.ResetTime ( A33ShoppingCartDate ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
         {
            GX_msglist.addItem("Não é possível excluir o carrinho de hoje", 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeComplete069( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate069( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes069( )
      {
      }

      protected void ZM0610( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z36QtyProduct = A36QtyProduct;
            Z35TotalProduct = A35TotalProduct;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z13ProductName = A13ProductName;
            Z27ProductPrice = A27ProductPrice;
            Z6CategoryId = A6CategoryId;
            Z35TotalProduct = A35TotalProduct;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z7CategoryName = A7CategoryName;
            Z35TotalProduct = A35TotalProduct;
         }
         if ( GX_JID == -11 )
         {
            Z16ShoppingCartId = A16ShoppingCartId;
            Z36QtyProduct = A36QtyProduct;
            Z12ProductId = A12ProductId;
            Z13ProductName = A13ProductName;
            Z27ProductPrice = A27ProductPrice;
            Z6CategoryId = A6CategoryId;
            Z7CategoryName = A7CategoryName;
         }
      }

      protected void standaloneNotModal0610( )
      {
      }

      protected void standaloneModal0610( )
      {
      }

      protected void Load0610( )
      {
         /* Using cursor BC000624 */
         pr_default.execute(18, new Object[] {A16ShoppingCartId, A12ProductId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound10 = 1;
            A13ProductName = BC000624_A13ProductName[0];
            A27ProductPrice = BC000624_A27ProductPrice[0];
            A36QtyProduct = BC000624_A36QtyProduct[0];
            A7CategoryName = BC000624_A7CategoryName[0];
            A6CategoryId = BC000624_A6CategoryId[0];
            ZM0610( -11) ;
         }
         pr_default.close(18);
         OnLoadActions0610( ) ;
      }

      protected void OnLoadActions0610( )
      {
         if ( StringUtil.StrCmp(A7CategoryName, "Entretenimiento") == 0 )
         {
            A35TotalProduct = (decimal)((A27ProductPrice*0.9m)*A36QtyProduct);
         }
         else
         {
            if ( StringUtil.StrCmp(A7CategoryName, "Joyería") == 0 )
            {
               A35TotalProduct = (decimal)((A27ProductPrice*1.05m)*A36QtyProduct);
            }
            else
            {
               A35TotalProduct = (decimal)(A27ProductPrice*A36QtyProduct);
            }
         }
         O35TotalProduct = A35TotalProduct;
         if ( IsIns( )  )
         {
            A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice+A35TotalProduct);
            n34ShoppingCartFinalPrice = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice+A35TotalProduct-O35TotalProduct);
               n34ShoppingCartFinalPrice = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice-O35TotalProduct);
                  n34ShoppingCartFinalPrice = false;
               }
            }
         }
      }

      protected void CheckExtendedTable0610( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         standaloneModal0610( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
         }
         A13ProductName = BC00064_A13ProductName[0];
         A27ProductPrice = BC00064_A27ProductPrice[0];
         A6CategoryId = BC00064_A6CategoryId[0];
         pr_default.close(2);
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {A6CategoryId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
         }
         A7CategoryName = BC00065_A7CategoryName[0];
         pr_default.close(3);
         if ( StringUtil.StrCmp(A7CategoryName, "Entretenimiento") == 0 )
         {
            nIsDirty_10 = 1;
            A35TotalProduct = (decimal)((A27ProductPrice*0.9m)*A36QtyProduct);
         }
         else
         {
            if ( StringUtil.StrCmp(A7CategoryName, "Joyería") == 0 )
            {
               nIsDirty_10 = 1;
               A35TotalProduct = (decimal)((A27ProductPrice*1.05m)*A36QtyProduct);
            }
            else
            {
               nIsDirty_10 = 1;
               A35TotalProduct = (decimal)(A27ProductPrice*A36QtyProduct);
            }
         }
         if ( IsIns( )  )
         {
            nIsDirty_10 = 1;
            A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice+A35TotalProduct);
            n34ShoppingCartFinalPrice = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_10 = 1;
               A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice+A35TotalProduct-O35TotalProduct);
               n34ShoppingCartFinalPrice = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_10 = 1;
                  A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice-O35TotalProduct);
                  n34ShoppingCartFinalPrice = false;
               }
            }
         }
      }

      protected void CloseExtendedTableCursors0610( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0610( )
      {
      }

      protected void GetKey0610( )
      {
         /* Using cursor BC000625 */
         pr_default.execute(19, new Object[] {A16ShoppingCartId, A12ProductId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey0610( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {A16ShoppingCartId, A12ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0610( 11) ;
            RcdFound10 = 1;
            InitializeNonKey0610( ) ;
            A36QtyProduct = BC00063_A36QtyProduct[0];
            A12ProductId = BC00063_A12ProductId[0];
            Z16ShoppingCartId = A16ShoppingCartId;
            Z12ProductId = A12ProductId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0610( ) ;
            Load0610( ) ;
            Gx_mode = sMode10;
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0610( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0610( ) ;
            Gx_mode = sMode10;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0610( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0610( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {A16ShoppingCartId, A12ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCartProduct"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z36QtyProduct != BC00062_A36QtyProduct[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ShoppingCartProduct"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0610( )
      {
         BeforeValidate0610( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0610( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0610( 0) ;
            CheckOptimisticConcurrency0610( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0610( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0610( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000626 */
                     pr_default.execute(20, new Object[] {A16ShoppingCartId, A36QtyProduct, A12ProductId});
                     pr_default.close(20);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCartProduct");
                     if ( (pr_default.getStatus(20) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load0610( ) ;
            }
            EndLevel0610( ) ;
         }
         CloseExtendedTableCursors0610( ) ;
      }

      protected void Update0610( )
      {
         BeforeValidate0610( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0610( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0610( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0610( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0610( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000627 */
                     pr_default.execute(21, new Object[] {A36QtyProduct, A16ShoppingCartId, A12ProductId});
                     pr_default.close(21);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCartProduct");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCartProduct"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0610( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0610( ) ;
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
            EndLevel0610( ) ;
         }
         CloseExtendedTableCursors0610( ) ;
      }

      protected void DeferredUpdate0610( )
      {
      }

      protected void Delete0610( )
      {
         Gx_mode = "DLT";
         BeforeValidate0610( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0610( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0610( ) ;
            AfterConfirm0610( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0610( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000628 */
                  pr_default.execute(22, new Object[] {A16ShoppingCartId, A12ProductId});
                  pr_default.close(22);
                  dsDefault.SmartCacheProvider.SetUpdated("ShoppingCartProduct");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0610( ) ;
         Gx_mode = sMode10;
      }

      protected void OnDeleteControls0610( )
      {
         standaloneModal0610( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000629 */
            pr_default.execute(23, new Object[] {A12ProductId});
            A13ProductName = BC000629_A13ProductName[0];
            A27ProductPrice = BC000629_A27ProductPrice[0];
            A6CategoryId = BC000629_A6CategoryId[0];
            pr_default.close(23);
            /* Using cursor BC000630 */
            pr_default.execute(24, new Object[] {A6CategoryId});
            A7CategoryName = BC000630_A7CategoryName[0];
            pr_default.close(24);
            if ( StringUtil.StrCmp(A7CategoryName, "Entretenimiento") == 0 )
            {
               A35TotalProduct = (decimal)((A27ProductPrice*0.9m)*A36QtyProduct);
            }
            else
            {
               if ( StringUtil.StrCmp(A7CategoryName, "Joyería") == 0 )
               {
                  A35TotalProduct = (decimal)((A27ProductPrice*1.05m)*A36QtyProduct);
               }
               else
               {
                  A35TotalProduct = (decimal)(A27ProductPrice*A36QtyProduct);
               }
            }
            if ( IsIns( )  )
            {
               A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice+A35TotalProduct);
               n34ShoppingCartFinalPrice = false;
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice+A35TotalProduct-O35TotalProduct);
                  n34ShoppingCartFinalPrice = false;
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice-O35TotalProduct);
                     n34ShoppingCartFinalPrice = false;
                  }
               }
            }
         }
      }

      protected void EndLevel0610( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0610( )
      {
         /* Scan By routine */
         /* Using cursor BC000631 */
         pr_default.execute(25, new Object[] {A16ShoppingCartId});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound10 = 1;
            A13ProductName = BC000631_A13ProductName[0];
            A27ProductPrice = BC000631_A27ProductPrice[0];
            A36QtyProduct = BC000631_A36QtyProduct[0];
            A7CategoryName = BC000631_A7CategoryName[0];
            A12ProductId = BC000631_A12ProductId[0];
            A6CategoryId = BC000631_A6CategoryId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0610( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound10 = 0;
         ScanKeyLoad0610( ) ;
      }

      protected void ScanKeyLoad0610( )
      {
         sMode10 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound10 = 1;
            A13ProductName = BC000631_A13ProductName[0];
            A27ProductPrice = BC000631_A27ProductPrice[0];
            A36QtyProduct = BC000631_A36QtyProduct[0];
            A7CategoryName = BC000631_A7CategoryName[0];
            A12ProductId = BC000631_A12ProductId[0];
            A6CategoryId = BC000631_A6CategoryId[0];
         }
         Gx_mode = sMode10;
      }

      protected void ScanKeyEnd0610( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm0610( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0610( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0610( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0610( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0610( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0610( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0610( )
      {
      }

      protected void send_integrity_lvl_hashes0610( )
      {
      }

      protected void send_integrity_lvl_hashes069( )
      {
      }

      protected void AddRow069( )
      {
         VarsToRow9( bcShoppingCart) ;
      }

      protected void ReadRow069( )
      {
         RowToVars9( bcShoppingCart, 1) ;
      }

      protected void AddRow0610( )
      {
         SdtShoppingCart_Product obj10;
         obj10 = new SdtShoppingCart_Product(context);
         VarsToRow10( obj10) ;
         bcShoppingCart.gxTpr_Product.Add(obj10, 0);
         obj10.gxTpr_Mode = "UPD";
         obj10.gxTpr_Modified = 0;
      }

      protected void ReadRow0610( )
      {
         nGXsfl_10_idx = (int)(nGXsfl_10_idx+1);
         RowToVars10( ((SdtShoppingCart_Product)bcShoppingCart.gxTpr_Product.Item(nGXsfl_10_idx)), 1) ;
      }

      protected void InitializeNonKey069( )
      {
         A38ShoppingCartDateDelivery = DateTime.MinValue;
         A11CustomerId = 0;
         A20CustomerName = "";
         A8CountryId = 0;
         A9CountryName = "";
         A21CustomerAddress = "";
         A23CustomerPhone = "";
         A34ShoppingCartFinalPrice = 0;
         n34ShoppingCartFinalPrice = false;
         A33ShoppingCartDate = DateTimeUtil.Today( context);
         O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
         n34ShoppingCartFinalPrice = false;
         Z33ShoppingCartDate = DateTime.MinValue;
         Z11CustomerId = 0;
      }

      protected void InitAll069( )
      {
         A16ShoppingCartId = 0;
         InitializeNonKey069( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A33ShoppingCartDate = i33ShoppingCartDate;
      }

      protected void InitializeNonKey0610( )
      {
         A35TotalProduct = 0;
         A13ProductName = "";
         A27ProductPrice = 0;
         A36QtyProduct = 0;
         A6CategoryId = 0;
         A7CategoryName = "";
         O35TotalProduct = A35TotalProduct;
         Z36QtyProduct = 0;
      }

      protected void InitAll0610( )
      {
         A12ProductId = 0;
         InitializeNonKey0610( ) ;
      }

      protected void StandaloneModalInsert0610( )
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

      public void VarsToRow9( SdtShoppingCart obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Shoppingcartdatedelivery = A38ShoppingCartDateDelivery;
         obj9.gxTpr_Customerid = A11CustomerId;
         obj9.gxTpr_Customername = A20CustomerName;
         obj9.gxTpr_Countryid = A8CountryId;
         obj9.gxTpr_Countryname = A9CountryName;
         obj9.gxTpr_Customeraddress = A21CustomerAddress;
         obj9.gxTpr_Customerphone = A23CustomerPhone;
         obj9.gxTpr_Shoppingcartfinalprice = A34ShoppingCartFinalPrice;
         obj9.gxTpr_Shoppingcartdate = A33ShoppingCartDate;
         obj9.gxTpr_Shoppingcartid = A16ShoppingCartId;
         obj9.gxTpr_Shoppingcartid_Z = Z16ShoppingCartId;
         obj9.gxTpr_Shoppingcartdate_Z = Z33ShoppingCartDate;
         obj9.gxTpr_Shoppingcartdatedelivery_Z = Z38ShoppingCartDateDelivery;
         obj9.gxTpr_Customerid_Z = Z11CustomerId;
         obj9.gxTpr_Customername_Z = Z20CustomerName;
         obj9.gxTpr_Countryid_Z = Z8CountryId;
         obj9.gxTpr_Countryname_Z = Z9CountryName;
         obj9.gxTpr_Customeraddress_Z = Z21CustomerAddress;
         obj9.gxTpr_Customerphone_Z = Z23CustomerPhone;
         obj9.gxTpr_Shoppingcartfinalprice_Z = Z34ShoppingCartFinalPrice;
         obj9.gxTpr_Shoppingcartfinalprice_N = (short)(Convert.ToInt16(n34ShoppingCartFinalPrice));
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( SdtShoppingCart obj9 )
      {
         obj9.gxTpr_Shoppingcartid = A16ShoppingCartId;
         return  ;
      }

      public void RowToVars9( SdtShoppingCart obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A38ShoppingCartDateDelivery = obj9.gxTpr_Shoppingcartdatedelivery;
         A11CustomerId = obj9.gxTpr_Customerid;
         A20CustomerName = obj9.gxTpr_Customername;
         A8CountryId = obj9.gxTpr_Countryid;
         A9CountryName = obj9.gxTpr_Countryname;
         A21CustomerAddress = obj9.gxTpr_Customeraddress;
         A23CustomerPhone = obj9.gxTpr_Customerphone;
         A34ShoppingCartFinalPrice = obj9.gxTpr_Shoppingcartfinalprice;
         n34ShoppingCartFinalPrice = false;
         A33ShoppingCartDate = obj9.gxTpr_Shoppingcartdate;
         A16ShoppingCartId = obj9.gxTpr_Shoppingcartid;
         Z16ShoppingCartId = obj9.gxTpr_Shoppingcartid_Z;
         Z33ShoppingCartDate = obj9.gxTpr_Shoppingcartdate_Z;
         Z38ShoppingCartDateDelivery = obj9.gxTpr_Shoppingcartdatedelivery_Z;
         Z11CustomerId = obj9.gxTpr_Customerid_Z;
         Z20CustomerName = obj9.gxTpr_Customername_Z;
         Z8CountryId = obj9.gxTpr_Countryid_Z;
         Z9CountryName = obj9.gxTpr_Countryname_Z;
         Z21CustomerAddress = obj9.gxTpr_Customeraddress_Z;
         Z23CustomerPhone = obj9.gxTpr_Customerphone_Z;
         Z34ShoppingCartFinalPrice = obj9.gxTpr_Shoppingcartfinalprice_Z;
         O34ShoppingCartFinalPrice = obj9.gxTpr_Shoppingcartfinalprice_Z;
         n34ShoppingCartFinalPrice = (bool)(Convert.ToBoolean(obj9.gxTpr_Shoppingcartfinalprice_N));
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow10( SdtShoppingCart_Product obj10 )
      {
         obj10.gxTpr_Mode = Gx_mode;
         obj10.gxTpr_Totalproduct = A35TotalProduct;
         obj10.gxTpr_Productname = A13ProductName;
         obj10.gxTpr_Productprice = A27ProductPrice;
         obj10.gxTpr_Qtyproduct = A36QtyProduct;
         obj10.gxTpr_Categoryid = A6CategoryId;
         obj10.gxTpr_Categoryname = A7CategoryName;
         obj10.gxTpr_Productid = A12ProductId;
         obj10.gxTpr_Productid_Z = Z12ProductId;
         obj10.gxTpr_Productname_Z = Z13ProductName;
         obj10.gxTpr_Productprice_Z = Z27ProductPrice;
         obj10.gxTpr_Qtyproduct_Z = Z36QtyProduct;
         obj10.gxTpr_Totalproduct_Z = Z35TotalProduct;
         obj10.gxTpr_Categoryid_Z = Z6CategoryId;
         obj10.gxTpr_Categoryname_Z = Z7CategoryName;
         obj10.gxTpr_Modified = nIsMod_10;
         return  ;
      }

      public void KeyVarsToRow10( SdtShoppingCart_Product obj10 )
      {
         obj10.gxTpr_Productid = A12ProductId;
         return  ;
      }

      public void RowToVars10( SdtShoppingCart_Product obj10 ,
                               int forceLoad )
      {
         Gx_mode = obj10.gxTpr_Mode;
         A35TotalProduct = obj10.gxTpr_Totalproduct;
         A13ProductName = obj10.gxTpr_Productname;
         A27ProductPrice = obj10.gxTpr_Productprice;
         A36QtyProduct = obj10.gxTpr_Qtyproduct;
         A6CategoryId = obj10.gxTpr_Categoryid;
         A7CategoryName = obj10.gxTpr_Categoryname;
         A12ProductId = obj10.gxTpr_Productid;
         Z12ProductId = obj10.gxTpr_Productid_Z;
         Z13ProductName = obj10.gxTpr_Productname_Z;
         Z27ProductPrice = obj10.gxTpr_Productprice_Z;
         Z36QtyProduct = obj10.gxTpr_Qtyproduct_Z;
         Z35TotalProduct = obj10.gxTpr_Totalproduct_Z;
         O35TotalProduct = obj10.gxTpr_Totalproduct_Z;
         Z6CategoryId = obj10.gxTpr_Categoryid_Z;
         Z7CategoryName = obj10.gxTpr_Categoryname_Z;
         nIsMod_10 = obj10.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A16ShoppingCartId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey069( ) ;
         ScanKeyStart069( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z16ShoppingCartId = A16ShoppingCartId;
         }
         ZM069( -7) ;
         OnLoadActions069( ) ;
         AddRow069( ) ;
         bcShoppingCart.gxTpr_Product.ClearCollection();
         if ( RcdFound9 == 1 )
         {
            ScanKeyStart0610( ) ;
            nGXsfl_10_idx = 1;
            while ( RcdFound10 != 0 )
            {
               O35TotalProduct = A35TotalProduct;
               Z16ShoppingCartId = A16ShoppingCartId;
               Z12ProductId = A12ProductId;
               ZM0610( -11) ;
               OnLoadActions0610( ) ;
               nRcdExists_10 = 1;
               nIsMod_10 = 0;
               Z35TotalProduct = A35TotalProduct;
               AddRow0610( ) ;
               nGXsfl_10_idx = (int)(nGXsfl_10_idx+1);
               ScanKeyNext0610( ) ;
            }
            ScanKeyEnd0610( ) ;
         }
         ScanKeyEnd069( ) ;
         if ( RcdFound9 == 0 )
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
         RowToVars9( bcShoppingCart, 0) ;
         ScanKeyStart069( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z16ShoppingCartId = A16ShoppingCartId;
         }
         ZM069( -7) ;
         OnLoadActions069( ) ;
         AddRow069( ) ;
         bcShoppingCart.gxTpr_Product.ClearCollection();
         if ( RcdFound9 == 1 )
         {
            ScanKeyStart0610( ) ;
            nGXsfl_10_idx = 1;
            while ( RcdFound10 != 0 )
            {
               O35TotalProduct = A35TotalProduct;
               Z16ShoppingCartId = A16ShoppingCartId;
               Z12ProductId = A12ProductId;
               ZM0610( -11) ;
               OnLoadActions0610( ) ;
               nRcdExists_10 = 1;
               nIsMod_10 = 0;
               Z35TotalProduct = A35TotalProduct;
               AddRow0610( ) ;
               nGXsfl_10_idx = (int)(nGXsfl_10_idx+1);
               ScanKeyNext0610( ) ;
            }
            ScanKeyEnd0610( ) ;
         }
         ScanKeyEnd069( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey069( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
            n34ShoppingCartFinalPrice = false;
            Insert069( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A16ShoppingCartId != Z16ShoppingCartId )
               {
                  A16ShoppingCartId = Z16ShoppingCartId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
                  n34ShoppingCartFinalPrice = false;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
                  n34ShoppingCartFinalPrice = false;
                  Update069( ) ;
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
                  if ( A16ShoppingCartId != Z16ShoppingCartId )
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
                        A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
                        n34ShoppingCartFinalPrice = false;
                        Insert069( ) ;
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
                        A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
                        n34ShoppingCartFinalPrice = false;
                        Insert069( ) ;
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
         RowToVars9( bcShoppingCart, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcShoppingCart) ;
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
         RowToVars9( bcShoppingCart, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
         n34ShoppingCartFinalPrice = false;
         Insert069( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcShoppingCart) ;
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
            SdtShoppingCart auxBC = new SdtShoppingCart(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A16ShoppingCartId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcShoppingCart);
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
         RowToVars9( bcShoppingCart, 1) ;
         UpdateImpl( ) ;
         VarsToRow9( bcShoppingCart) ;
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
         RowToVars9( bcShoppingCart, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert069( ) ;
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
         VarsToRow9( bcShoppingCart) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcShoppingCart, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey069( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A16ShoppingCartId != Z16ShoppingCartId )
            {
               A16ShoppingCartId = Z16ShoppingCartId;
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
            if ( A16ShoppingCartId != Z16ShoppingCartId )
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
         pr_default.close(5);
         pr_default.close(1);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(14);
         pr_default.close(23);
         pr_default.close(24);
         context.RollbackDataStores("shoppingcart_bc",pr_default);
         VarsToRow9( bcShoppingCart) ;
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
         Gx_mode = bcShoppingCart.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcShoppingCart.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcShoppingCart )
         {
            bcShoppingCart = (SdtShoppingCart)(sdt);
            if ( StringUtil.StrCmp(bcShoppingCart.gxTpr_Mode, "") == 0 )
            {
               bcShoppingCart.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcShoppingCart) ;
            }
            else
            {
               RowToVars9( bcShoppingCart, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcShoppingCart.gxTpr_Mode, "") == 0 )
            {
               bcShoppingCart.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcShoppingCart, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtShoppingCart ShoppingCart_BC
      {
         get {
            return bcShoppingCart ;
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
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(5);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode9 = "";
         Z33ShoppingCartDate = DateTime.MinValue;
         A33ShoppingCartDate = DateTime.MinValue;
         Z38ShoppingCartDateDelivery = DateTime.MinValue;
         A38ShoppingCartDateDelivery = DateTime.MinValue;
         Z20CustomerName = "";
         A20CustomerName = "";
         Z21CustomerAddress = "";
         A21CustomerAddress = "";
         Z23CustomerPhone = "";
         A23CustomerPhone = "";
         Z9CountryName = "";
         A9CountryName = "";
         BC000613_A16ShoppingCartId = new short[1] ;
         BC000613_A33ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         BC000613_A20CustomerName = new string[] {""} ;
         BC000613_A9CountryName = new string[] {""} ;
         BC000613_A21CustomerAddress = new string[] {""} ;
         BC000613_A23CustomerPhone = new string[] {""} ;
         BC000613_A11CustomerId = new short[1] ;
         BC000613_A8CountryId = new short[1] ;
         BC000613_A34ShoppingCartFinalPrice = new decimal[1] ;
         BC000613_n34ShoppingCartFinalPrice = new bool[] {false} ;
         BC000611_A34ShoppingCartFinalPrice = new decimal[1] ;
         BC000611_n34ShoppingCartFinalPrice = new bool[] {false} ;
         BC00068_A20CustomerName = new string[] {""} ;
         BC00068_A21CustomerAddress = new string[] {""} ;
         BC00068_A23CustomerPhone = new string[] {""} ;
         BC00068_A8CountryId = new short[1] ;
         BC00069_A9CountryName = new string[] {""} ;
         BC000614_A16ShoppingCartId = new short[1] ;
         BC00067_A16ShoppingCartId = new short[1] ;
         BC00067_A33ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         BC00067_A11CustomerId = new short[1] ;
         BC00066_A16ShoppingCartId = new short[1] ;
         BC00066_A33ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         BC00066_A11CustomerId = new short[1] ;
         BC000615_A16ShoppingCartId = new short[1] ;
         BC000619_A34ShoppingCartFinalPrice = new decimal[1] ;
         BC000619_n34ShoppingCartFinalPrice = new bool[] {false} ;
         BC000620_A20CustomerName = new string[] {""} ;
         BC000620_A21CustomerAddress = new string[] {""} ;
         BC000620_A23CustomerPhone = new string[] {""} ;
         BC000620_A8CountryId = new short[1] ;
         BC000621_A9CountryName = new string[] {""} ;
         BC000623_A16ShoppingCartId = new short[1] ;
         BC000623_A33ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         BC000623_A20CustomerName = new string[] {""} ;
         BC000623_A9CountryName = new string[] {""} ;
         BC000623_A21CustomerAddress = new string[] {""} ;
         BC000623_A23CustomerPhone = new string[] {""} ;
         BC000623_A11CustomerId = new short[1] ;
         BC000623_A8CountryId = new short[1] ;
         BC000623_A34ShoppingCartFinalPrice = new decimal[1] ;
         BC000623_n34ShoppingCartFinalPrice = new bool[] {false} ;
         Z13ProductName = "";
         A13ProductName = "";
         Z7CategoryName = "";
         A7CategoryName = "";
         BC000624_A16ShoppingCartId = new short[1] ;
         BC000624_A13ProductName = new string[] {""} ;
         BC000624_A27ProductPrice = new decimal[1] ;
         BC000624_A36QtyProduct = new short[1] ;
         BC000624_A7CategoryName = new string[] {""} ;
         BC000624_A12ProductId = new short[1] ;
         BC000624_A6CategoryId = new short[1] ;
         BC00064_A13ProductName = new string[] {""} ;
         BC00064_A27ProductPrice = new decimal[1] ;
         BC00064_A6CategoryId = new short[1] ;
         BC00065_A7CategoryName = new string[] {""} ;
         BC000625_A16ShoppingCartId = new short[1] ;
         BC000625_A12ProductId = new short[1] ;
         BC00063_A16ShoppingCartId = new short[1] ;
         BC00063_A36QtyProduct = new short[1] ;
         BC00063_A12ProductId = new short[1] ;
         sMode10 = "";
         BC00062_A16ShoppingCartId = new short[1] ;
         BC00062_A36QtyProduct = new short[1] ;
         BC00062_A12ProductId = new short[1] ;
         BC000629_A13ProductName = new string[] {""} ;
         BC000629_A27ProductPrice = new decimal[1] ;
         BC000629_A6CategoryId = new short[1] ;
         BC000630_A7CategoryName = new string[] {""} ;
         BC000631_A16ShoppingCartId = new short[1] ;
         BC000631_A13ProductName = new string[] {""} ;
         BC000631_A27ProductPrice = new decimal[1] ;
         BC000631_A36QtyProduct = new short[1] ;
         BC000631_A7CategoryName = new string[] {""} ;
         BC000631_A12ProductId = new short[1] ;
         BC000631_A6CategoryId = new short[1] ;
         i33ShoppingCartDate = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.shoppingcart_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A16ShoppingCartId, BC00062_A36QtyProduct, BC00062_A12ProductId
               }
               , new Object[] {
               BC00063_A16ShoppingCartId, BC00063_A36QtyProduct, BC00063_A12ProductId
               }
               , new Object[] {
               BC00064_A13ProductName, BC00064_A27ProductPrice, BC00064_A6CategoryId
               }
               , new Object[] {
               BC00065_A7CategoryName
               }
               , new Object[] {
               BC00066_A16ShoppingCartId, BC00066_A33ShoppingCartDate, BC00066_A11CustomerId
               }
               , new Object[] {
               BC00067_A16ShoppingCartId, BC00067_A33ShoppingCartDate, BC00067_A11CustomerId
               }
               , new Object[] {
               BC00068_A20CustomerName, BC00068_A21CustomerAddress, BC00068_A23CustomerPhone, BC00068_A8CountryId
               }
               , new Object[] {
               BC00069_A9CountryName
               }
               , new Object[] {
               BC000611_A34ShoppingCartFinalPrice, BC000611_n34ShoppingCartFinalPrice
               }
               , new Object[] {
               BC000613_A16ShoppingCartId, BC000613_A33ShoppingCartDate, BC000613_A20CustomerName, BC000613_A9CountryName, BC000613_A21CustomerAddress, BC000613_A23CustomerPhone, BC000613_A11CustomerId, BC000613_A8CountryId, BC000613_A34ShoppingCartFinalPrice, BC000613_n34ShoppingCartFinalPrice
               }
               , new Object[] {
               BC000614_A16ShoppingCartId
               }
               , new Object[] {
               BC000615_A16ShoppingCartId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000619_A34ShoppingCartFinalPrice, BC000619_n34ShoppingCartFinalPrice
               }
               , new Object[] {
               BC000620_A20CustomerName, BC000620_A21CustomerAddress, BC000620_A23CustomerPhone, BC000620_A8CountryId
               }
               , new Object[] {
               BC000621_A9CountryName
               }
               , new Object[] {
               BC000623_A16ShoppingCartId, BC000623_A33ShoppingCartDate, BC000623_A20CustomerName, BC000623_A9CountryName, BC000623_A21CustomerAddress, BC000623_A23CustomerPhone, BC000623_A11CustomerId, BC000623_A8CountryId, BC000623_A34ShoppingCartFinalPrice, BC000623_n34ShoppingCartFinalPrice
               }
               , new Object[] {
               BC000624_A16ShoppingCartId, BC000624_A13ProductName, BC000624_A27ProductPrice, BC000624_A36QtyProduct, BC000624_A7CategoryName, BC000624_A12ProductId, BC000624_A6CategoryId
               }
               , new Object[] {
               BC000625_A16ShoppingCartId, BC000625_A12ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000629_A13ProductName, BC000629_A27ProductPrice, BC000629_A6CategoryId
               }
               , new Object[] {
               BC000630_A7CategoryName
               }
               , new Object[] {
               BC000631_A16ShoppingCartId, BC000631_A13ProductName, BC000631_A27ProductPrice, BC000631_A36QtyProduct, BC000631_A7CategoryName, BC000631_A12ProductId, BC000631_A6CategoryId
               }
            }
         );
         Z33ShoppingCartDate = DateTimeUtil.Today( context);
         A33ShoppingCartDate = DateTimeUtil.Today( context);
         i33ShoppingCartDate = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12062 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z16ShoppingCartId ;
      private short A16ShoppingCartId ;
      private short nIsMod_10 ;
      private short RcdFound10 ;
      private short GX_JID ;
      private short Z11CustomerId ;
      private short A11CustomerId ;
      private short Z8CountryId ;
      private short A8CountryId ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short nIsDirty_9 ;
      private short nRcdExists_10 ;
      private short Gxremove10 ;
      private short Z36QtyProduct ;
      private short A36QtyProduct ;
      private short Z6CategoryId ;
      private short A6CategoryId ;
      private short Z12ProductId ;
      private short A12ProductId ;
      private short nIsDirty_10 ;
      private int trnEnded ;
      private int nGXsfl_10_idx=1 ;
      private decimal s34ShoppingCartFinalPrice ;
      private decimal O34ShoppingCartFinalPrice ;
      private decimal A34ShoppingCartFinalPrice ;
      private decimal Z34ShoppingCartFinalPrice ;
      private decimal Z35TotalProduct ;
      private decimal A35TotalProduct ;
      private decimal Z27ProductPrice ;
      private decimal A27ProductPrice ;
      private decimal O35TotalProduct ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode9 ;
      private string Z20CustomerName ;
      private string A20CustomerName ;
      private string Z23CustomerPhone ;
      private string A23CustomerPhone ;
      private string Z9CountryName ;
      private string A9CountryName ;
      private string Z13ProductName ;
      private string A13ProductName ;
      private string Z7CategoryName ;
      private string A7CategoryName ;
      private string sMode10 ;
      private DateTime Z33ShoppingCartDate ;
      private DateTime A33ShoppingCartDate ;
      private DateTime Z38ShoppingCartDateDelivery ;
      private DateTime A38ShoppingCartDateDelivery ;
      private DateTime i33ShoppingCartDate ;
      private bool n34ShoppingCartFinalPrice ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z21CustomerAddress ;
      private string A21CustomerAddress ;
      private SdtShoppingCart bcShoppingCart ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000613_A16ShoppingCartId ;
      private DateTime[] BC000613_A33ShoppingCartDate ;
      private string[] BC000613_A20CustomerName ;
      private string[] BC000613_A9CountryName ;
      private string[] BC000613_A21CustomerAddress ;
      private string[] BC000613_A23CustomerPhone ;
      private short[] BC000613_A11CustomerId ;
      private short[] BC000613_A8CountryId ;
      private decimal[] BC000613_A34ShoppingCartFinalPrice ;
      private bool[] BC000613_n34ShoppingCartFinalPrice ;
      private decimal[] BC000611_A34ShoppingCartFinalPrice ;
      private bool[] BC000611_n34ShoppingCartFinalPrice ;
      private string[] BC00068_A20CustomerName ;
      private string[] BC00068_A21CustomerAddress ;
      private string[] BC00068_A23CustomerPhone ;
      private short[] BC00068_A8CountryId ;
      private string[] BC00069_A9CountryName ;
      private short[] BC000614_A16ShoppingCartId ;
      private short[] BC00067_A16ShoppingCartId ;
      private DateTime[] BC00067_A33ShoppingCartDate ;
      private short[] BC00067_A11CustomerId ;
      private short[] BC00066_A16ShoppingCartId ;
      private DateTime[] BC00066_A33ShoppingCartDate ;
      private short[] BC00066_A11CustomerId ;
      private short[] BC000615_A16ShoppingCartId ;
      private decimal[] BC000619_A34ShoppingCartFinalPrice ;
      private bool[] BC000619_n34ShoppingCartFinalPrice ;
      private string[] BC000620_A20CustomerName ;
      private string[] BC000620_A21CustomerAddress ;
      private string[] BC000620_A23CustomerPhone ;
      private short[] BC000620_A8CountryId ;
      private string[] BC000621_A9CountryName ;
      private short[] BC000623_A16ShoppingCartId ;
      private DateTime[] BC000623_A33ShoppingCartDate ;
      private string[] BC000623_A20CustomerName ;
      private string[] BC000623_A9CountryName ;
      private string[] BC000623_A21CustomerAddress ;
      private string[] BC000623_A23CustomerPhone ;
      private short[] BC000623_A11CustomerId ;
      private short[] BC000623_A8CountryId ;
      private decimal[] BC000623_A34ShoppingCartFinalPrice ;
      private bool[] BC000623_n34ShoppingCartFinalPrice ;
      private short[] BC000624_A16ShoppingCartId ;
      private string[] BC000624_A13ProductName ;
      private decimal[] BC000624_A27ProductPrice ;
      private short[] BC000624_A36QtyProduct ;
      private string[] BC000624_A7CategoryName ;
      private short[] BC000624_A12ProductId ;
      private short[] BC000624_A6CategoryId ;
      private string[] BC00064_A13ProductName ;
      private decimal[] BC00064_A27ProductPrice ;
      private short[] BC00064_A6CategoryId ;
      private string[] BC00065_A7CategoryName ;
      private short[] BC000625_A16ShoppingCartId ;
      private short[] BC000625_A12ProductId ;
      private short[] BC00063_A16ShoppingCartId ;
      private short[] BC00063_A36QtyProduct ;
      private short[] BC00063_A12ProductId ;
      private short[] BC00062_A16ShoppingCartId ;
      private short[] BC00062_A36QtyProduct ;
      private short[] BC00062_A12ProductId ;
      private string[] BC000629_A13ProductName ;
      private decimal[] BC000629_A27ProductPrice ;
      private short[] BC000629_A6CategoryId ;
      private string[] BC000630_A7CategoryName ;
      private short[] BC000631_A16ShoppingCartId ;
      private string[] BC000631_A13ProductName ;
      private decimal[] BC000631_A27ProductPrice ;
      private short[] BC000631_A36QtyProduct ;
      private string[] BC000631_A7CategoryName ;
      private short[] BC000631_A12ProductId ;
      private short[] BC000631_A6CategoryId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class shoppingcart_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000613;
          prmBC000613 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000611;
          prmBC000611 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC00068;
          prmBC00068 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC00069;
          prmBC00069 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000614;
          prmBC000614 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC00067;
          prmBC00067 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC00066;
          prmBC00066 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000615;
          prmBC000615 = new Object[] {
          new ParDef("@ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC000616;
          prmBC000616 = new Object[] {
          new ParDef("@ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0) ,
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000617;
          prmBC000617 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000619;
          prmBC000619 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000620;
          prmBC000620 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC000621;
          prmBC000621 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000623;
          prmBC000623 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmBC000624;
          prmBC000624 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00064;
          prmBC00064 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00065;
          prmBC00065 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmBC000625;
          prmBC000625 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00063;
          prmBC00063 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC00062;
          prmBC00062 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000626;
          prmBC000626 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@QtyProduct",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000627;
          prmBC000627 = new Object[] {
          new ParDef("@QtyProduct",GXType.Int16,4,0) ,
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000628;
          prmBC000628 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000629;
          prmBC000629 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmBC000630;
          prmBC000630 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmBC000631;
          prmBC000631 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00062", "SELECT [ShoppingCartId], [QtyProduct], [ProductId] FROM [ShoppingCartProduct] WITH (UPDLOCK) WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00063", "SELECT [ShoppingCartId], [QtyProduct], [ProductId] FROM [ShoppingCartProduct] WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00064", "SELECT [ProductName], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00065", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00066", "SELECT [ShoppingCartId], [ShoppingCartDate], [CustomerId] FROM [ShoppingCart] WITH (UPDLOCK) WHERE [ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00067", "SELECT [ShoppingCartId], [ShoppingCartDate], [CustomerId] FROM [ShoppingCart] WHERE [ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00068", "SELECT [CustomerName], [CustomerAddress], [CustomerPhone], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00068,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00069", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00069,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000611", "SELECT COALESCE( T1.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM (SELECT SUM(CASE  WHEN T4.[CategoryName] = 'Entretenimiento' THEN ( T3.[ProductPrice] * CAST(0.9 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 20, 10)) WHEN T4.[CategoryName] = 'Joyería' THEN ( T3.[ProductPrice] * CAST(1.05 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 20, 10)) ELSE T3.[ProductPrice] * CAST(T2.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T2.[ShoppingCartId] FROM (([ShoppingCartProduct] T2 WITH (UPDLOCK) INNER JOIN [Product] T3 ON T3.[ProductId] = T2.[ProductId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T3.[CategoryId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000613", "SELECT TM1.[ShoppingCartId], TM1.[ShoppingCartDate], T3.[CustomerName], T4.[CountryName], T3.[CustomerAddress], T3.[CustomerPhone], TM1.[CustomerId], T3.[CountryId], COALESCE( T2.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM ((([ShoppingCart] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoryName] = 'Entretenimiento' THEN ( T6.[ProductPrice] * CAST(0.9 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 20, 10)) WHEN T7.[CategoryName] = 'Joyería' THEN ( T6.[ProductPrice] * CAST(1.05 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 20, 10)) ELSE T6.[ProductPrice] * CAST(T5.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T5.[ShoppingCartId] FROM (([ShoppingCartProduct] T5 INNER JOIN [Product] T6 ON T6.[ProductId] = T5.[ProductId]) INNER JOIN [Category] T7 ON T7.[CategoryId] = T6.[CategoryId]) GROUP BY T5.[ShoppingCartId] ) T2 ON T2.[ShoppingCartId] = TM1.[ShoppingCartId]) INNER JOIN [Customer] T3 ON T3.[CustomerId] = TM1.[CustomerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) WHERE TM1.[ShoppingCartId] = @ShoppingCartId ORDER BY TM1.[ShoppingCartId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000613,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000614", "SELECT [ShoppingCartId] FROM [ShoppingCart] WHERE [ShoppingCartId] = @ShoppingCartId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000614,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000615", "INSERT INTO [ShoppingCart]([ShoppingCartDate], [CustomerId]) VALUES(@ShoppingCartDate, @CustomerId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC000615)
             ,new CursorDef("BC000616", "UPDATE [ShoppingCart] SET [ShoppingCartDate]=@ShoppingCartDate, [CustomerId]=@CustomerId  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK,prmBC000616)
             ,new CursorDef("BC000617", "DELETE FROM [ShoppingCart]  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK,prmBC000617)
             ,new CursorDef("BC000619", "SELECT COALESCE( T1.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM (SELECT SUM(CASE  WHEN T4.[CategoryName] = 'Entretenimiento' THEN ( T3.[ProductPrice] * CAST(0.9 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 20, 10)) WHEN T4.[CategoryName] = 'Joyería' THEN ( T3.[ProductPrice] * CAST(1.05 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 20, 10)) ELSE T3.[ProductPrice] * CAST(T2.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T2.[ShoppingCartId] FROM (([ShoppingCartProduct] T2 WITH (UPDLOCK) INNER JOIN [Product] T3 ON T3.[ProductId] = T2.[ProductId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T3.[CategoryId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000619,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000620", "SELECT [CustomerName], [CustomerAddress], [CustomerPhone], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000620,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000621", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000621,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000623", "SELECT TM1.[ShoppingCartId], TM1.[ShoppingCartDate], T3.[CustomerName], T4.[CountryName], T3.[CustomerAddress], T3.[CustomerPhone], TM1.[CustomerId], T3.[CountryId], COALESCE( T2.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM ((([ShoppingCart] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoryName] = 'Entretenimiento' THEN ( T6.[ProductPrice] * CAST(0.9 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 20, 10)) WHEN T7.[CategoryName] = 'Joyería' THEN ( T6.[ProductPrice] * CAST(1.05 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 20, 10)) ELSE T6.[ProductPrice] * CAST(T5.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T5.[ShoppingCartId] FROM (([ShoppingCartProduct] T5 INNER JOIN [Product] T6 ON T6.[ProductId] = T5.[ProductId]) INNER JOIN [Category] T7 ON T7.[CategoryId] = T6.[CategoryId]) GROUP BY T5.[ShoppingCartId] ) T2 ON T2.[ShoppingCartId] = TM1.[ShoppingCartId]) INNER JOIN [Customer] T3 ON T3.[CustomerId] = TM1.[CustomerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) WHERE TM1.[ShoppingCartId] = @ShoppingCartId ORDER BY TM1.[ShoppingCartId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000623,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000624", "SELECT T1.[ShoppingCartId], T2.[ProductName], T2.[ProductPrice], T1.[QtyProduct], T3.[CategoryName], T1.[ProductId], T2.[CategoryId] FROM (([ShoppingCartProduct] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T2.[CategoryId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId and T1.[ProductId] = @ProductId ORDER BY T1.[ShoppingCartId], T1.[ProductId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000624,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000625", "SELECT [ShoppingCartId], [ProductId] FROM [ShoppingCartProduct] WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000625,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000626", "INSERT INTO [ShoppingCartProduct]([ShoppingCartId], [QtyProduct], [ProductId]) VALUES(@ShoppingCartId, @QtyProduct, @ProductId)", GxErrorMask.GX_NOMASK,prmBC000626)
             ,new CursorDef("BC000627", "UPDATE [ShoppingCartProduct] SET [QtyProduct]=@QtyProduct  WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000627)
             ,new CursorDef("BC000628", "DELETE FROM [ShoppingCartProduct]  WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000628)
             ,new CursorDef("BC000629", "SELECT [ProductName], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000629,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000630", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000630,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000631", "SELECT T1.[ShoppingCartId], T2.[ProductName], T2.[ProductPrice], T1.[QtyProduct], T3.[CategoryName], T1.[ProductId], T2.[CategoryId] FROM (([ShoppingCartProduct] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T2.[CategoryId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId ORDER BY T1.[ShoppingCartId], T1.[ProductId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000631,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 23 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
