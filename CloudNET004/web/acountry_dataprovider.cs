using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class acountry_dataprovider : GXProcedure
   {
      public acountry_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public acountry_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtCountry> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtCountry>( context, "Country", "WorkShopNew") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtCountry> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtCountry> aP0_Gxm2rootcol )
      {
         acountry_dataprovider objacountry_dataprovider;
         objacountry_dataprovider = new acountry_dataprovider();
         objacountry_dataprovider.Gxm2rootcol = new GXBCCollection<SdtCountry>( context, "Country", "WorkShopNew") ;
         objacountry_dataprovider.context.SetSubmitInitialConfig(context);
         objacountry_dataprovider.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objacountry_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((acountry_dataprovider)stateInfo).executePrivate();
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
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryname = "Uruguay";
         Gxm1country.gxTpr_Countryflag = context.convertURL( (string)(context.GetImagePath( "24e1a39e-14e4-4953-9696-e01b5601194c", "", context.GetTheme( ))));
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryname = "Brasil";
         Gxm1country.gxTpr_Countryflag = context.convertURL( (string)(context.GetImagePath( "ec0bfb71-9eeb-4b5f-96b5-a1d5fed7f629", "", context.GetTheme( ))));
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryname = "Argentina";
         Gxm1country.gxTpr_Countryflag = context.convertURL( (string)(context.GetImagePath( "9c658c6a-b553-4ab0-acc2-3bbab0ac9805", "", context.GetTheme( ))));
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryname = "México";
         Gxm1country.gxTpr_Countryflag = context.convertURL( (string)(context.GetImagePath( "e037a193-e70d-44c4-90db-bde5f7ad15ce", "", context.GetTheme( ))));
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryname = "China";
         Gxm1country.gxTpr_Countryflag = context.convertURL( (string)(context.GetImagePath( "ac396fee-550f-4d1e-8717-cc604bdeb677", "", context.GetTheme( ))));
         Gxm1country = new SdtCountry(context);
         Gxm2rootcol.Add(Gxm1country, 0);
         Gxm1country.gxTpr_Countryname = "Estados Unidos";
         Gxm1country.gxTpr_Countryflag = context.convertURL( (string)(context.GetImagePath( "e4964f85-ca81-4f48-b090-8982e04427d6", "", context.GetTheme( ))));
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         Gxm1country = new SdtCountry(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtCountry> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtCountry> Gxm2rootcol ;
      private SdtCountry Gxm1country ;
   }

}
