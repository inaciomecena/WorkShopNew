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
   public class percentagepercategory : GXProcedure
   {
      public percentagepercategory( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public percentagepercategory( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_CategoryId ,
                           ref short aP1_Percentage )
      {
         this.AV8CategoryId = aP0_CategoryId;
         this.AV9Percentage = aP1_Percentage;
         initialize();
         executePrivate();
         aP0_CategoryId=this.AV8CategoryId;
         aP1_Percentage=this.AV9Percentage;
      }

      public short executeUdp( ref short aP0_CategoryId )
      {
         execute(ref aP0_CategoryId, ref aP1_Percentage);
         return AV9Percentage ;
      }

      public void executeSubmit( ref short aP0_CategoryId ,
                                 ref short aP1_Percentage )
      {
         percentagepercategory objpercentagepercategory;
         objpercentagepercategory = new percentagepercategory();
         objpercentagepercategory.AV8CategoryId = aP0_CategoryId;
         objpercentagepercategory.AV9Percentage = aP1_Percentage;
         objpercentagepercategory.context.SetSubmitInitialConfig(context);
         objpercentagepercategory.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpercentagepercategory);
         aP0_CategoryId=this.AV8CategoryId;
         aP1_Percentage=this.AV9Percentage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((percentagepercategory)stateInfo).executePrivate();
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
         /* Using cursor P000K2 */
         pr_default.execute(0, new Object[] {AV8CategoryId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A6CategoryId = P000K2_A6CategoryId[0];
            A12ProductId = P000K2_A12ProductId[0];
            AV11Product.Load(A12ProductId);
            AV10Precio = (short)(AV11Product.gxTpr_Productprice*(1+(AV9Percentage/ (decimal)(100))));
            AV11Product.gxTpr_Productprice = (decimal)(AV10Precio);
            AV11Product.Update();
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( (0==AV8CategoryId) )
         {
            /* Using cursor P000K3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A12ProductId = P000K3_A12ProductId[0];
               AV11Product.Load(A12ProductId);
               AV10Precio = (short)(AV11Product.gxTpr_Productprice*(1+(AV9Percentage/ (decimal)(100))));
               AV11Product.gxTpr_Productprice = (decimal)(AV10Precio);
               AV11Product.Update();
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         context.CommitDataStores("percentagepercategory",pr_default);
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
         scmdbuf = "";
         P000K2_A6CategoryId = new short[1] ;
         P000K2_A12ProductId = new short[1] ;
         AV11Product = new SdtProduct(context);
         P000K3_A12ProductId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.percentagepercategory__default(),
            new Object[][] {
                new Object[] {
               P000K2_A6CategoryId, P000K2_A12ProductId
               }
               , new Object[] {
               P000K3_A12ProductId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8CategoryId ;
      private short AV9Percentage ;
      private short A6CategoryId ;
      private short A12ProductId ;
      private short AV10Precio ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private short aP0_CategoryId ;
      private short aP1_Percentage ;
      private IDataStoreProvider pr_default ;
      private short[] P000K2_A6CategoryId ;
      private short[] P000K2_A12ProductId ;
      private short[] P000K3_A12ProductId ;
      private SdtProduct AV11Product ;
   }

   public class percentagepercategory__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000K2;
          prmP000K2 = new Object[] {
          new ParDef("@AV8CategoryId",GXType.Int16,4,0)
          };
          Object[] prmP000K3;
          prmP000K3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000K2", "SELECT [CategoryId], [ProductId] FROM [Product] WHERE [CategoryId] = @AV8CategoryId ORDER BY [CategoryId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000K2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000K3", "SELECT [ProductId] FROM [Product] ORDER BY [ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000K3,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
