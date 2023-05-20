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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class categoriesandproductsproc : GXProcedure
   {
      public categoriesandproductsproc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public categoriesandproductsproc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_CategoryId ,
                           ref string aP1_CategoryName )
      {
         this.AV2CategoryId = aP0_CategoryId;
         this.AV3CategoryName = aP1_CategoryName;
         initialize();
         executePrivate();
         aP0_CategoryId=this.AV2CategoryId;
         aP1_CategoryName=this.AV3CategoryName;
      }

      public string executeUdp( ref short aP0_CategoryId )
      {
         execute(ref aP0_CategoryId, ref aP1_CategoryName);
         return AV3CategoryName ;
      }

      public void executeSubmit( ref short aP0_CategoryId ,
                                 ref string aP1_CategoryName )
      {
         categoriesandproductsproc objcategoriesandproductsproc;
         objcategoriesandproductsproc = new categoriesandproductsproc();
         objcategoriesandproductsproc.AV2CategoryId = aP0_CategoryId;
         objcategoriesandproductsproc.AV3CategoryName = aP1_CategoryName;
         objcategoriesandproductsproc.context.SetSubmitInitialConfig(context);
         objcategoriesandproductsproc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcategoriesandproductsproc);
         aP0_CategoryId=this.AV2CategoryId;
         aP1_CategoryName=this.AV3CategoryName;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((categoriesandproductsproc)stateInfo).executePrivate();
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
         args = new Object[] {(short)AV2CategoryId,(string)AV3CategoryName} ;
         ClassLoader.Execute("acategoriesandproductsproc","GeneXus.Programs","acategoriesandproductsproc", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV2CategoryId = (short)(args[0]) ;
            AV3CategoryName = (string)(args[1]) ;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV2CategoryId ;
      private string AV3CategoryName ;
      private IGxDataStore dsDefault ;
      private short aP0_CategoryId ;
      private string aP1_CategoryName ;
      private Object[] args ;
   }

}
