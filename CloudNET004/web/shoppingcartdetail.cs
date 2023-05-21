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
   public class shoppingcartdetail : GXProcedure
   {
      public shoppingcartdetail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public shoppingcartdetail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_ShoppingCartId )
      {
         this.AV2ShoppingCartId = aP0_ShoppingCartId;
         initialize();
         executePrivate();
         aP0_ShoppingCartId=this.AV2ShoppingCartId;
      }

      public short executeUdp( )
      {
         execute(ref aP0_ShoppingCartId);
         return AV2ShoppingCartId ;
      }

      public void executeSubmit( ref short aP0_ShoppingCartId )
      {
         shoppingcartdetail objshoppingcartdetail;
         objshoppingcartdetail = new shoppingcartdetail();
         objshoppingcartdetail.AV2ShoppingCartId = aP0_ShoppingCartId;
         objshoppingcartdetail.context.SetSubmitInitialConfig(context);
         objshoppingcartdetail.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objshoppingcartdetail);
         aP0_ShoppingCartId=this.AV2ShoppingCartId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((shoppingcartdetail)stateInfo).executePrivate();
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
         args = new Object[] {(short)AV2ShoppingCartId} ;
         ClassLoader.Execute("ashoppingcartdetail","GeneXus.Programs","ashoppingcartdetail", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ShoppingCartId = (short)(args[0]) ;
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

      private short AV2ShoppingCartId ;
      private IGxDataStore dsDefault ;
      private short aP0_ShoppingCartId ;
      private Object[] args ;
   }

}
