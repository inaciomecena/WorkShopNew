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
   public class aproductspercategory : GXWebProcedure
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
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
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

      public aproductspercategory( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aproductspercategory( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         aproductspercategory objaproductspercategory;
         objaproductspercategory = new aproductspercategory();
         objaproductspercategory.context.SetSubmitInitialConfig(context);
         objaproductspercategory.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaproductspercategory);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aproductspercategory)stateInfo).executePrivate();
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
            H0H0( false, 209) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "90719676-8060-4034-b644-10b3f3a0bb9d", "", context.GetTheme( )), 67, Gx_line+17, 300, Gx_line+184) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 30, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Catalogue", 392, Gx_line+83, 642, Gx_line+131, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(8, Gx_line+201, 823, Gx_line+201, 2, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+209);
            /* Using cursor P000H2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK0H2 = false;
               A6CategoryId = P000H2_A6CategoryId[0];
               A10SellerId = P000H2_A10SellerId[0];
               A7CategoryName = P000H2_A7CategoryName[0];
               A40001SellerPhoto_GXI = P000H2_A40001SellerPhoto_GXI[0];
               A40000ProductPhoto_GXI = P000H2_A40000ProductPhoto_GXI[0];
               A18SellerName = P000H2_A18SellerName[0];
               A13ProductName = P000H2_A13ProductName[0];
               A27ProductPrice = P000H2_A27ProductPrice[0];
               A12ProductId = P000H2_A12ProductId[0];
               A19SellerPhoto = P000H2_A19SellerPhoto[0];
               A28ProductPhoto = P000H2_A28ProductPhoto[0];
               A7CategoryName = P000H2_A7CategoryName[0];
               A40001SellerPhoto_GXI = P000H2_A40001SellerPhoto_GXI[0];
               A18SellerName = P000H2_A18SellerName[0];
               A19SellerPhoto = P000H2_A19SellerPhoto[0];
               H0H0( false, 32) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A7CategoryName, "")), 0, Gx_line+0, 168, Gx_line+22, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+32);
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P000H2_A7CategoryName[0], A7CategoryName) == 0 ) )
               {
                  BRK0H2 = false;
                  A6CategoryId = P000H2_A6CategoryId[0];
                  A10SellerId = P000H2_A10SellerId[0];
                  A40001SellerPhoto_GXI = P000H2_A40001SellerPhoto_GXI[0];
                  A40000ProductPhoto_GXI = P000H2_A40000ProductPhoto_GXI[0];
                  A18SellerName = P000H2_A18SellerName[0];
                  A13ProductName = P000H2_A13ProductName[0];
                  A27ProductPrice = P000H2_A27ProductPrice[0];
                  A12ProductId = P000H2_A12ProductId[0];
                  A19SellerPhoto = P000H2_A19SellerPhoto[0];
                  A28ProductPhoto = P000H2_A28ProductPhoto[0];
                  A40001SellerPhoto_GXI = P000H2_A40001SellerPhoto_GXI[0];
                  A18SellerName = P000H2_A18SellerName[0];
                  A19SellerPhoto = P000H2_A19SellerPhoto[0];
                  H0H0( false, 114) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A27ProductPrice, "$ ZZZZ9.99")), 367, Gx_line+50, 462, Gx_line+72, 2+256, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : A28ProductPhoto);
                  getPrinter().GxDrawBitMap(sImgUrl, 67, Gx_line+50, 167, Gx_line+100) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13ProductName, "")), 183, Gx_line+50, 330, Gx_line+72, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A18SellerName, "")), 492, Gx_line+50, 639, Gx_line+72, 0+256, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : A19SellerPhoto);
                  getPrinter().GxDrawBitMap(sImgUrl, 692, Gx_line+50, 792, Gx_line+100) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+114);
                  BRK0H2 = true;
                  pr_default.readNext(0);
               }
               if ( ! BRK0H2 )
               {
                  BRK0H2 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0H0( true, 0) ;
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

      protected void H0H0( bool bFoot ,
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
         P000H2_A6CategoryId = new short[1] ;
         P000H2_A10SellerId = new short[1] ;
         P000H2_A7CategoryName = new string[] {""} ;
         P000H2_A40001SellerPhoto_GXI = new string[] {""} ;
         P000H2_A40000ProductPhoto_GXI = new string[] {""} ;
         P000H2_A18SellerName = new string[] {""} ;
         P000H2_A13ProductName = new string[] {""} ;
         P000H2_A27ProductPrice = new decimal[1] ;
         P000H2_A12ProductId = new short[1] ;
         P000H2_A19SellerPhoto = new string[] {""} ;
         P000H2_A28ProductPhoto = new string[] {""} ;
         A7CategoryName = "";
         A40001SellerPhoto_GXI = "";
         A40000ProductPhoto_GXI = "";
         A18SellerName = "";
         A13ProductName = "";
         A19SellerPhoto = "";
         A28ProductPhoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aproductspercategory__default(),
            new Object[][] {
                new Object[] {
               P000H2_A6CategoryId, P000H2_A10SellerId, P000H2_A7CategoryName, P000H2_A40001SellerPhoto_GXI, P000H2_A40000ProductPhoto_GXI, P000H2_A18SellerName, P000H2_A13ProductName, P000H2_A27ProductPrice, P000H2_A12ProductId, P000H2_A19SellerPhoto,
               P000H2_A28ProductPhoto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A6CategoryId ;
      private short A10SellerId ;
      private short A12ProductId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal A27ProductPrice ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A7CategoryName ;
      private string A18SellerName ;
      private string A13ProductName ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK0H2 ;
      private string A40001SellerPhoto_GXI ;
      private string A40000ProductPhoto_GXI ;
      private string A19SellerPhoto ;
      private string A28ProductPhoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000H2_A6CategoryId ;
      private short[] P000H2_A10SellerId ;
      private string[] P000H2_A7CategoryName ;
      private string[] P000H2_A40001SellerPhoto_GXI ;
      private string[] P000H2_A40000ProductPhoto_GXI ;
      private string[] P000H2_A18SellerName ;
      private string[] P000H2_A13ProductName ;
      private decimal[] P000H2_A27ProductPrice ;
      private short[] P000H2_A12ProductId ;
      private string[] P000H2_A19SellerPhoto ;
      private string[] P000H2_A28ProductPhoto ;
   }

   public class aproductspercategory__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000H2;
          prmP000H2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000H2", "SELECT T1.[CategoryId], T1.[SellerId], T2.[CategoryName], T3.[SellerPhoto_GXI], T1.[ProductPhoto_GXI], T3.[SellerName], T1.[ProductName], T1.[ProductPrice], T1.[ProductId], T3.[SellerPhoto], T1.[ProductPhoto] FROM (([Product] T1 INNER JOIN [Category] T2 ON T2.[CategoryId] = T1.[CategoryId]) INNER JOIN [Seller] T3 ON T3.[SellerId] = T1.[SellerId]) ORDER BY T2.[CategoryName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(4));
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
                return;
       }
    }

 }

}
