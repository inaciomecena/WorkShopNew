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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class ashoppingcartdetail : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("Carmine");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ShoppingCartId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               A16ShoppingCartId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public ashoppingcartdetail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public ashoppingcartdetail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_ShoppingCartId )
      {
         this.A16ShoppingCartId = aP0_ShoppingCartId;
         initialize();
         executePrivate();
         aP0_ShoppingCartId=this.A16ShoppingCartId;
      }

      public short executeUdp( )
      {
         execute(ref aP0_ShoppingCartId);
         return A16ShoppingCartId ;
      }

      public void executeSubmit( ref short aP0_ShoppingCartId )
      {
         ashoppingcartdetail objashoppingcartdetail;
         objashoppingcartdetail = new ashoppingcartdetail();
         objashoppingcartdetail.A16ShoppingCartId = aP0_ShoppingCartId;
         objashoppingcartdetail.context.SetSubmitInitialConfig(context);
         objashoppingcartdetail.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objashoppingcartdetail);
         aP0_ShoppingCartId=this.A16ShoppingCartId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ashoppingcartdetail)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            H0F0( false, 102) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 28, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Relatório de Vendas", 287, Gx_line+27, 745, Gx_line+73, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "82a664b3-3df3-4cda-b374-f8e42bf48c8f", "", context.GetTheme( )), 20, Gx_line+13, 260, Gx_line+93) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+102);
            /* Using cursor P000F3 */
            pr_default.execute(0, new Object[] {A16ShoppingCartId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11CustomerId = P000F3_A11CustomerId[0];
               A8CountryId = P000F3_A8CountryId[0];
               A9CountryName = P000F3_A9CountryName[0];
               A21CustomerAddress = P000F3_A21CustomerAddress[0];
               A20CustomerName = P000F3_A20CustomerName[0];
               A34ShoppingCartFinalPrice = P000F3_A34ShoppingCartFinalPrice[0];
               n34ShoppingCartFinalPrice = P000F3_n34ShoppingCartFinalPrice[0];
               A33ShoppingCartDate = P000F3_A33ShoppingCartDate[0];
               A8CountryId = P000F3_A8CountryId[0];
               A21CustomerAddress = P000F3_A21CustomerAddress[0];
               A20CustomerName = P000F3_A20CustomerName[0];
               A9CountryName = P000F3_A9CountryName[0];
               A34ShoppingCartFinalPrice = P000F3_A34ShoppingCartFinalPrice[0];
               n34ShoppingCartFinalPrice = P000F3_n34ShoppingCartFinalPrice[0];
               A38ShoppingCartDateDelivery = DateTimeUtil.DAdd(A33ShoppingCartDate,+((int)(5)));
               H0F0( false, 199) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Shopping Cart:", 0, Gx_line+0, 133, Gx_line+33, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A16ShoppingCartId), "ZZZ9")), 142, Gx_line+10, 181, Gx_line+32, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Date:", 242, Gx_line+0, 289, Gx_line+21, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A33ShoppingCartDate, "99/99/99"), 325, Gx_line+10, 391, Gx_line+32, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Delivery Date:", 458, Gx_line+0, 576, Gx_line+21, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A38ShoppingCartDateDelivery, "99/99/99"), 625, Gx_line+10, 700, Gx_line+32, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Customer", 0, Gx_line+50, 81, Gx_line+92, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A20CustomerName, "")), 125, Gx_line+60, 272, Gx_line+82, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A21CustomerAddress, "")), 0, Gx_line+110, 617, Gx_line+132, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A9CountryName, "")), 0, Gx_line+150, 147, Gx_line+172, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total:", 525, Gx_line+150, 573, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A34ShoppingCartFinalPrice, "$ ZZZZZZ9.99")), 617, Gx_line+160, 731, Gx_line+182, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(2, Gx_line+184, 819, Gx_line+184, 2, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+199);
               /* Using cursor P000F4 */
               pr_default.execute(1, new Object[] {A16ShoppingCartId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A12ProductId = P000F4_A12ProductId[0];
                  A6CategoryId = P000F4_A6CategoryId[0];
                  A40000ProductPhoto_GXI = P000F4_A40000ProductPhoto_GXI[0];
                  A13ProductName = P000F4_A13ProductName[0];
                  A7CategoryName = P000F4_A7CategoryName[0];
                  A27ProductPrice = P000F4_A27ProductPrice[0];
                  A36QtyProduct = P000F4_A36QtyProduct[0];
                  A28ProductPhoto = P000F4_A28ProductPhoto[0];
                  A6CategoryId = P000F4_A6CategoryId[0];
                  A40000ProductPhoto_GXI = P000F4_A40000ProductPhoto_GXI[0];
                  A13ProductName = P000F4_A13ProductName[0];
                  A27ProductPrice = P000F4_A27ProductPrice[0];
                  A28ProductPhoto = P000F4_A28ProductPhoto[0];
                  A7CategoryName = P000F4_A7CategoryName[0];
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
                  H0F0( false, 124) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Product", 60, Gx_line+0, 126, Gx_line+21, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Price", 300, Gx_line+0, 343, Gx_line+21, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Quantity", 470, Gx_line+0, 541, Gx_line+21, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Total", 630, Gx_line+0, 673, Gx_line+21, 0+256, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : A28ProductPhoto);
                  getPrinter().GxDrawBitMap(sImgUrl, 0, Gx_line+33, 48, Gx_line+55) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13ProductName, "")), 50, Gx_line+33, 197, Gx_line+55, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A27ProductPrice, "R$ ZZZZ9.99")), 275, Gx_line+33, 379, Gx_line+55, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A36QtyProduct), "ZZZ9")), 475, Gx_line+33, 514, Gx_line+55, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A35TotalProduct, "R$ ZZZZ9.99")), 633, Gx_line+33, 737, Gx_line+55, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+124);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0F0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0F0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P000F3_A11CustomerId = new short[1] ;
         P000F3_A8CountryId = new short[1] ;
         P000F3_A16ShoppingCartId = new short[1] ;
         P000F3_A9CountryName = new string[] {""} ;
         P000F3_A21CustomerAddress = new string[] {""} ;
         P000F3_A20CustomerName = new string[] {""} ;
         P000F3_A34ShoppingCartFinalPrice = new decimal[1] ;
         P000F3_n34ShoppingCartFinalPrice = new bool[] {false} ;
         P000F3_A33ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         A9CountryName = "";
         A21CustomerAddress = "";
         A20CustomerName = "";
         A33ShoppingCartDate = DateTime.MinValue;
         A38ShoppingCartDateDelivery = DateTime.MinValue;
         P000F4_A12ProductId = new short[1] ;
         P000F4_A6CategoryId = new short[1] ;
         P000F4_A16ShoppingCartId = new short[1] ;
         P000F4_A40000ProductPhoto_GXI = new string[] {""} ;
         P000F4_A13ProductName = new string[] {""} ;
         P000F4_A7CategoryName = new string[] {""} ;
         P000F4_A27ProductPrice = new decimal[1] ;
         P000F4_A36QtyProduct = new short[1] ;
         P000F4_A28ProductPhoto = new string[] {""} ;
         A40000ProductPhoto_GXI = "";
         A13ProductName = "";
         A7CategoryName = "";
         A28ProductPhoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ashoppingcartdetail__default(),
            new Object[][] {
                new Object[] {
               P000F3_A11CustomerId, P000F3_A8CountryId, P000F3_A16ShoppingCartId, P000F3_A9CountryName, P000F3_A21CustomerAddress, P000F3_A20CustomerName, P000F3_A34ShoppingCartFinalPrice, P000F3_n34ShoppingCartFinalPrice, P000F3_A33ShoppingCartDate
               }
               , new Object[] {
               P000F4_A12ProductId, P000F4_A6CategoryId, P000F4_A16ShoppingCartId, P000F4_A40000ProductPhoto_GXI, P000F4_A13ProductName, P000F4_A7CategoryName, P000F4_A27ProductPrice, P000F4_A36QtyProduct, P000F4_A28ProductPhoto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short A16ShoppingCartId ;
      private short GxWebError ;
      private short A11CustomerId ;
      private short A8CountryId ;
      private short A12ProductId ;
      private short A6CategoryId ;
      private short A36QtyProduct ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal A34ShoppingCartFinalPrice ;
      private decimal A27ProductPrice ;
      private decimal A35TotalProduct ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A9CountryName ;
      private string A20CustomerName ;
      private string A13ProductName ;
      private string A7CategoryName ;
      private string sImgUrl ;
      private DateTime A33ShoppingCartDate ;
      private DateTime A38ShoppingCartDateDelivery ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n34ShoppingCartFinalPrice ;
      private string A21CustomerAddress ;
      private string A40000ProductPhoto_GXI ;
      private string A28ProductPhoto ;
      private IGxDataStore dsDefault ;
      private short aP0_ShoppingCartId ;
      private IDataStoreProvider pr_default ;
      private short[] P000F3_A11CustomerId ;
      private short[] P000F3_A8CountryId ;
      private short[] P000F3_A16ShoppingCartId ;
      private string[] P000F3_A9CountryName ;
      private string[] P000F3_A21CustomerAddress ;
      private string[] P000F3_A20CustomerName ;
      private decimal[] P000F3_A34ShoppingCartFinalPrice ;
      private bool[] P000F3_n34ShoppingCartFinalPrice ;
      private DateTime[] P000F3_A33ShoppingCartDate ;
      private short[] P000F4_A12ProductId ;
      private short[] P000F4_A6CategoryId ;
      private short[] P000F4_A16ShoppingCartId ;
      private string[] P000F4_A40000ProductPhoto_GXI ;
      private string[] P000F4_A13ProductName ;
      private string[] P000F4_A7CategoryName ;
      private decimal[] P000F4_A27ProductPrice ;
      private short[] P000F4_A36QtyProduct ;
      private string[] P000F4_A28ProductPhoto ;
   }

   public class ashoppingcartdetail__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000F3;
          prmP000F3 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmP000F4;
          prmP000F4 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000F3", "SELECT T1.[CustomerId], T2.[CountryId], T1.[ShoppingCartId], T3.[CountryName], T2.[CustomerAddress], T2.[CustomerName], COALESCE( T4.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice, T1.[ShoppingCartDate] FROM ((([ShoppingCart] T1 INNER JOIN [Customer] T2 ON T2.[CustomerId] = T1.[CustomerId]) INNER JOIN [Country] T3 ON T3.[CountryId] = T2.[CountryId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoryName] = 'Entretenimiento' THEN ( T6.[ProductPrice] * CAST(0.9 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 20, 10)) WHEN T7.[CategoryName] = 'Joyería' THEN ( T6.[ProductPrice] * CAST(1.05 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 20, 10)) ELSE T6.[ProductPrice] * CAST(T5.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T5.[ShoppingCartId] FROM (([ShoppingCartProduct] T5 INNER JOIN [Product] T6 ON T6.[ProductId] = T5.[ProductId]) INNER JOIN [Category] T7 ON T7.[CategoryId] = T6.[CategoryId]) GROUP BY T5.[ShoppingCartId] ) T4 ON T4.[ShoppingCartId] = T1.[ShoppingCartId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId ORDER BY T1.[ShoppingCartId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000F4", "SELECT T1.[ProductId], T2.[CategoryId], T1.[ShoppingCartId], T2.[ProductPhoto_GXI], T2.[ProductName], T3.[CategoryName], T2.[ProductPrice], T1.[QtyProduct], T2.[ProductPhoto] FROM (([ShoppingCartProduct] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T2.[CategoryId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId ORDER BY T2.[ProductName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
                return;
       }
    }

 }

}
