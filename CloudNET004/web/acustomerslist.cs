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
   public class acustomerslist : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "FromDate");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9FromDate = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV8ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
               }
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

      public acustomerslist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public acustomerslist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FromDate ,
                           ref DateTime aP1_ToDate )
      {
         this.AV9FromDate = aP0_FromDate;
         this.AV8ToDate = aP1_ToDate;
         initialize();
         executePrivate();
         aP0_FromDate=this.AV9FromDate;
         aP1_ToDate=this.AV8ToDate;
      }

      public DateTime executeUdp( ref DateTime aP0_FromDate )
      {
         execute(ref aP0_FromDate, ref aP1_ToDate);
         return AV8ToDate ;
      }

      public void executeSubmit( ref DateTime aP0_FromDate ,
                                 ref DateTime aP1_ToDate )
      {
         acustomerslist objacustomerslist;
         objacustomerslist = new acustomerslist();
         objacustomerslist.AV9FromDate = aP0_FromDate;
         objacustomerslist.AV8ToDate = aP1_ToDate;
         objacustomerslist.context.SetSubmitInitialConfig(context);
         objacustomerslist.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objacustomerslist);
         aP0_FromDate=this.AV9FromDate;
         aP1_ToDate=this.AV8ToDate;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((acustomerslist)stateInfo).executePrivate();
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
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV9FromDate ,
                                                 AV8ToDate ,
                                                 A33ShoppingCartDate } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P000I2 */
            pr_default.execute(0, new Object[] {AV9FromDate, AV8ToDate});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A33ShoppingCartDate = P000I2_A33ShoppingCartDate[0];
               A23CustomerPhone = P000I2_A23CustomerPhone[0];
               A22CustomerEmail = P000I2_A22CustomerEmail[0];
               A21CustomerAddress = P000I2_A21CustomerAddress[0];
               A20CustomerName = P000I2_A20CustomerName[0];
               A11CustomerId = P000I2_A11CustomerId[0];
               A23CustomerPhone = P000I2_A23CustomerPhone[0];
               A22CustomerEmail = P000I2_A22CustomerEmail[0];
               A21CustomerAddress = P000I2_A21CustomerAddress[0];
               A20CustomerName = P000I2_A20CustomerName[0];
               H0I0( false, 110) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A20CustomerName, "")), 42, Gx_line+50, 189, Gx_line+72, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A21CustomerAddress, "")), 250, Gx_line+50, 392, Gx_line+72, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A22CustomerEmail, "")), 530, Gx_line+50, 697, Gx_line+72, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A23CustomerPhone, "(99) 9999-9999")), 417, Gx_line+50, 564, Gx_line+72, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+110);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0I0( true, 0) ;
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

      protected void H0I0( bool bFoot ,
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
      }

      protected void add_metrics0( )
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
         A33ShoppingCartDate = DateTime.MinValue;
         P000I2_A33ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         P000I2_A23CustomerPhone = new string[] {""} ;
         P000I2_A22CustomerEmail = new string[] {""} ;
         P000I2_A21CustomerAddress = new string[] {""} ;
         P000I2_A20CustomerName = new string[] {""} ;
         P000I2_A11CustomerId = new short[1] ;
         A23CustomerPhone = "";
         A22CustomerEmail = "";
         A21CustomerAddress = "";
         A20CustomerName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acustomerslist__default(),
            new Object[][] {
                new Object[] {
               P000I2_A33ShoppingCartDate, P000I2_A23CustomerPhone, P000I2_A22CustomerEmail, P000I2_A21CustomerAddress, P000I2_A20CustomerName, P000I2_A11CustomerId
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
      private short A11CustomerId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A23CustomerPhone ;
      private string A20CustomerName ;
      private DateTime AV9FromDate ;
      private DateTime AV8ToDate ;
      private DateTime A33ShoppingCartDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A22CustomerEmail ;
      private string A21CustomerAddress ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P000I2_A33ShoppingCartDate ;
      private string[] P000I2_A23CustomerPhone ;
      private string[] P000I2_A22CustomerEmail ;
      private string[] P000I2_A21CustomerAddress ;
      private string[] P000I2_A20CustomerName ;
      private short[] P000I2_A11CustomerId ;
   }

   public class acustomerslist__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000I2( IGxContext context ,
                                             DateTime AV9FromDate ,
                                             DateTime AV8ToDate ,
                                             DateTime A33ShoppingCartDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [ShoppingCartDate], [CustomerPhone], [CustomerEmail], [CustomerAddress], [CustomerName], [CustomerId] FROM ( SELECT TOP(100) PERCENT T1.[ShoppingCartDate], T2.[CustomerPhone], T2.[CustomerEmail], T2.[CustomerAddress], T2.[CustomerName], T1.[CustomerId] FROM ([ShoppingCart] T1 INNER JOIN [Customer] T2 ON T2.[CustomerId] = T1.[CustomerId])";
         if ( ! (DateTime.MinValue==AV9FromDate) )
         {
            AddWhere(sWhereString, "(T1.[ShoppingCartDate] >= @AV9FromDate)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV8ToDate) )
         {
            AddWhere(sWhereString, "(T1.[ShoppingCartDate] <= @AV8ToDate)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CustomerId]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [CustomerId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P000I2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP000I2;
          prmP000I2 = new Object[] {
          new ParDef("@AV9FromDate",GXType.Date,8,0) ,
          new ParDef("@AV8ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000I2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
