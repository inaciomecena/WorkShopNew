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
   public class country_bc : GxSilentTrn, IGxSilentTrn
   {
      public country_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public country_bc( IGxContext context )
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
         ReadRow033( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey033( ) ;
         standaloneModal( ) ;
         AddRow033( ) ;
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
            E11032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z8CountryId = A8CountryId;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12032( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11032( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z9CountryName = A9CountryName;
         }
         if ( GX_JID == -2 )
         {
            Z8CountryId = A8CountryId;
            Z9CountryName = A9CountryName;
            Z17CountryFlag = A17CountryFlag;
            Z40000CountryFlag_GXI = A40000CountryFlag_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load033( )
      {
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound3 = 1;
            A9CountryName = BC00034_A9CountryName[0];
            A40000CountryFlag_GXI = BC00034_A40000CountryFlag_GXI[0];
            A17CountryFlag = BC00034_A17CountryFlag[0];
            ZM033( -2) ;
         }
         pr_default.close(2);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {A9CountryName, A8CountryId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Pa�s"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A9CountryName)) )
         {
            GX_msglist.addItem("O Campo Nome do Pa�s deve ser preenchido", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor BC00036 */
         pr_default.execute(4, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 2) ;
            RcdFound3 = 1;
            A8CountryId = BC00033_A8CountryId[0];
            A9CountryName = BC00033_A9CountryName[0];
            A40000CountryFlag_GXI = BC00033_A40000CountryFlag_GXI[0];
            A17CountryFlag = BC00033_A17CountryFlag[0];
            Z8CountryId = A8CountryId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode3;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
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
         CONFIRM_030( ) ;
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

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {A8CountryId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Country"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z9CountryName, BC00032_A9CountryName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Country"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00037 */
                     pr_default.execute(5, new Object[] {A9CountryName, A17CountryFlag, A40000CountryFlag_GXI});
                     A8CountryId = BC00037_A8CountryId[0];
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Country");
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00038 */
                     pr_default.execute(6, new Object[] {A9CountryName, A8CountryId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Country");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Country"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC00039 */
            pr_default.execute(7, new Object[] {A17CountryFlag, A40000CountryFlag_GXI, A8CountryId});
            pr_default.close(7);
            dsDefault.SmartCacheProvider.SetUpdated("Country");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000310 */
                  pr_default.execute(8, new Object[] {A8CountryId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Country");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel033( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000311 */
            pr_default.execute(9, new Object[] {A8CountryId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000312 */
            pr_default.execute(10, new Object[] {A8CountryId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Customer"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000313 */
            pr_default.execute(11, new Object[] {A8CountryId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Seller"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
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

      public void ScanKeyStart033( )
      {
         /* Scan By routine */
         /* Using cursor BC000314 */
         pr_default.execute(12, new Object[] {A8CountryId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound3 = 1;
            A8CountryId = BC000314_A8CountryId[0];
            A9CountryName = BC000314_A9CountryName[0];
            A40000CountryFlag_GXI = BC000314_A40000CountryFlag_GXI[0];
            A17CountryFlag = BC000314_A17CountryFlag[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound3 = 0;
         ScanKeyLoad033( ) ;
      }

      protected void ScanKeyLoad033( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound3 = 1;
            A8CountryId = BC000314_A8CountryId[0];
            A9CountryName = BC000314_A9CountryName[0];
            A40000CountryFlag_GXI = BC000314_A40000CountryFlag_GXI[0];
            A17CountryFlag = BC000314_A17CountryFlag[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd033( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void AddRow033( )
      {
         VarsToRow3( bcCountry) ;
      }

      protected void ReadRow033( )
      {
         RowToVars3( bcCountry, 1) ;
      }

      protected void InitializeNonKey033( )
      {
         A9CountryName = "";
         A17CountryFlag = "";
         A40000CountryFlag_GXI = "";
         Z9CountryName = "";
      }

      protected void InitAll033( )
      {
         A8CountryId = 0;
         InitializeNonKey033( ) ;
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

      public void VarsToRow3( SdtCountry obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Countryname = A9CountryName;
         obj3.gxTpr_Countryflag = A17CountryFlag;
         obj3.gxTpr_Countryflag_gxi = A40000CountryFlag_GXI;
         obj3.gxTpr_Countryid = A8CountryId;
         obj3.gxTpr_Countryid_Z = Z8CountryId;
         obj3.gxTpr_Countryname_Z = Z9CountryName;
         obj3.gxTpr_Countryflag_gxi_Z = Z40000CountryFlag_GXI;
         obj3.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow3( SdtCountry obj3 )
      {
         obj3.gxTpr_Countryid = A8CountryId;
         return  ;
      }

      public void RowToVars3( SdtCountry obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A9CountryName = obj3.gxTpr_Countryname;
         A17CountryFlag = obj3.gxTpr_Countryflag;
         A40000CountryFlag_GXI = obj3.gxTpr_Countryflag_gxi;
         A8CountryId = obj3.gxTpr_Countryid;
         Z8CountryId = obj3.gxTpr_Countryid_Z;
         Z9CountryName = obj3.gxTpr_Countryname_Z;
         Z40000CountryFlag_GXI = obj3.gxTpr_Countryflag_gxi_Z;
         Gx_mode = obj3.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A8CountryId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey033( ) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z8CountryId = A8CountryId;
         }
         ZM033( -2) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
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
         RowToVars3( bcCountry, 0) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z8CountryId = A8CountryId;
         }
         ZM033( -2) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert033( ) ;
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A8CountryId != Z8CountryId )
               {
                  A8CountryId = Z8CountryId;
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
                  Update033( ) ;
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
                  if ( A8CountryId != Z8CountryId )
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
                        Insert033( ) ;
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
                        Insert033( ) ;
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
         RowToVars3( bcCountry, 1) ;
         SaveImpl( ) ;
         VarsToRow3( bcCountry) ;
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
         RowToVars3( bcCountry, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
         AfterTrn( ) ;
         VarsToRow3( bcCountry) ;
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
            SdtCountry auxBC = new SdtCountry(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A8CountryId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCountry);
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
         RowToVars3( bcCountry, 1) ;
         UpdateImpl( ) ;
         VarsToRow3( bcCountry) ;
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
         RowToVars3( bcCountry, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
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
         VarsToRow3( bcCountry) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcCountry, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey033( ) ;
         if ( RcdFound3 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A8CountryId != Z8CountryId )
            {
               A8CountryId = Z8CountryId;
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
            if ( A8CountryId != Z8CountryId )
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
         context.RollbackDataStores("country_bc",pr_default);
         VarsToRow3( bcCountry) ;
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
         Gx_mode = bcCountry.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCountry.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCountry )
         {
            bcCountry = (SdtCountry)(sdt);
            if ( StringUtil.StrCmp(bcCountry.gxTpr_Mode, "") == 0 )
            {
               bcCountry.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow3( bcCountry) ;
            }
            else
            {
               RowToVars3( bcCountry, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCountry.gxTpr_Mode, "") == 0 )
            {
               bcCountry.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars3( bcCountry, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtCountry Country_BC
      {
         get {
            return bcCountry ;
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
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z9CountryName = "";
         A9CountryName = "";
         Z17CountryFlag = "";
         A17CountryFlag = "";
         Z40000CountryFlag_GXI = "";
         A40000CountryFlag_GXI = "";
         BC00034_A8CountryId = new short[1] ;
         BC00034_A9CountryName = new string[] {""} ;
         BC00034_A40000CountryFlag_GXI = new string[] {""} ;
         BC00034_A17CountryFlag = new string[] {""} ;
         BC00035_A9CountryName = new string[] {""} ;
         BC00036_A8CountryId = new short[1] ;
         BC00033_A8CountryId = new short[1] ;
         BC00033_A9CountryName = new string[] {""} ;
         BC00033_A40000CountryFlag_GXI = new string[] {""} ;
         BC00033_A17CountryFlag = new string[] {""} ;
         sMode3 = "";
         BC00032_A8CountryId = new short[1] ;
         BC00032_A9CountryName = new string[] {""} ;
         BC00032_A40000CountryFlag_GXI = new string[] {""} ;
         BC00032_A17CountryFlag = new string[] {""} ;
         BC00037_A8CountryId = new short[1] ;
         BC000311_A12ProductId = new short[1] ;
         BC000312_A11CustomerId = new short[1] ;
         BC000313_A10SellerId = new short[1] ;
         BC000314_A8CountryId = new short[1] ;
         BC000314_A9CountryName = new string[] {""} ;
         BC000314_A40000CountryFlag_GXI = new string[] {""} ;
         BC000314_A17CountryFlag = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.country_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A8CountryId, BC00032_A9CountryName, BC00032_A40000CountryFlag_GXI, BC00032_A17CountryFlag
               }
               , new Object[] {
               BC00033_A8CountryId, BC00033_A9CountryName, BC00033_A40000CountryFlag_GXI, BC00033_A17CountryFlag
               }
               , new Object[] {
               BC00034_A8CountryId, BC00034_A9CountryName, BC00034_A40000CountryFlag_GXI, BC00034_A17CountryFlag
               }
               , new Object[] {
               BC00035_A9CountryName
               }
               , new Object[] {
               BC00036_A8CountryId
               }
               , new Object[] {
               BC00037_A8CountryId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000311_A12ProductId
               }
               , new Object[] {
               BC000312_A11CustomerId
               }
               , new Object[] {
               BC000313_A10SellerId
               }
               , new Object[] {
               BC000314_A8CountryId, BC000314_A9CountryName, BC000314_A40000CountryFlag_GXI, BC000314_A17CountryFlag
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12032 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z8CountryId ;
      private short A8CountryId ;
      private short GX_JID ;
      private short RcdFound3 ;
      private short nIsDirty_3 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z9CountryName ;
      private string A9CountryName ;
      private string sMode3 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z40000CountryFlag_GXI ;
      private string A40000CountryFlag_GXI ;
      private string Z17CountryFlag ;
      private string A17CountryFlag ;
      private SdtCountry bcCountry ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00034_A8CountryId ;
      private string[] BC00034_A9CountryName ;
      private string[] BC00034_A40000CountryFlag_GXI ;
      private string[] BC00034_A17CountryFlag ;
      private string[] BC00035_A9CountryName ;
      private short[] BC00036_A8CountryId ;
      private short[] BC00033_A8CountryId ;
      private string[] BC00033_A9CountryName ;
      private string[] BC00033_A40000CountryFlag_GXI ;
      private string[] BC00033_A17CountryFlag ;
      private short[] BC00032_A8CountryId ;
      private string[] BC00032_A9CountryName ;
      private string[] BC00032_A40000CountryFlag_GXI ;
      private string[] BC00032_A17CountryFlag ;
      private short[] BC00037_A8CountryId ;
      private short[] BC000311_A12ProductId ;
      private short[] BC000312_A11CustomerId ;
      private short[] BC000313_A10SellerId ;
      private short[] BC000314_A8CountryId ;
      private string[] BC000314_A9CountryName ;
      private string[] BC000314_A40000CountryFlag_GXI ;
      private string[] BC000314_A17CountryFlag ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class country_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00034;
          prmBC00034 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00035;
          prmBC00035 = new Object[] {
          new ParDef("@CountryName",GXType.NChar,20,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00036;
          prmBC00036 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00033;
          prmBC00033 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00032;
          prmBC00032 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00037;
          prmBC00037 = new Object[] {
          new ParDef("@CountryName",GXType.NChar,20,0) ,
          new ParDef("@CountryFlag",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@CountryFlag_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Country", Fld="CountryFlag"}
          };
          Object[] prmBC00038;
          prmBC00038 = new Object[] {
          new ParDef("@CountryName",GXType.NChar,20,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00039;
          prmBC00039 = new Object[] {
          new ParDef("@CountryFlag",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@CountryFlag_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Country", Fld="CountryFlag"} ,
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000310;
          prmBC000310 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000311;
          prmBC000311 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000312;
          prmBC000312 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000313;
          prmBC000313 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000314;
          prmBC000314 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00032", "SELECT [CountryId], [CountryName], [CountryFlag_GXI], [CountryFlag] FROM [Country] WITH (UPDLOCK) WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00033", "SELECT [CountryId], [CountryName], [CountryFlag_GXI], [CountryFlag] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00034", "SELECT TM1.[CountryId], TM1.[CountryName], TM1.[CountryFlag_GXI], TM1.[CountryFlag] FROM [Country] TM1 WHERE TM1.[CountryId] = @CountryId ORDER BY TM1.[CountryId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00035", "SELECT [CountryName] FROM [Country] WHERE ([CountryName] = @CountryName) AND (Not ( [CountryId] = @CountryId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00036", "SELECT [CountryId] FROM [Country] WHERE [CountryId] = @CountryId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00036,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00037", "INSERT INTO [Country]([CountryName], [CountryFlag], [CountryFlag_GXI]) VALUES(@CountryName, @CountryFlag, @CountryFlag_GXI); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC00037)
             ,new CursorDef("BC00038", "UPDATE [Country] SET [CountryName]=@CountryName  WHERE [CountryId] = @CountryId", GxErrorMask.GX_NOMASK,prmBC00038)
             ,new CursorDef("BC00039", "UPDATE [Country] SET [CountryFlag]=@CountryFlag, [CountryFlag_GXI]=@CountryFlag_GXI  WHERE [CountryId] = @CountryId", GxErrorMask.GX_NOMASK,prmBC00039)
             ,new CursorDef("BC000310", "DELETE FROM [Country]  WHERE [CountryId] = @CountryId", GxErrorMask.GX_NOMASK,prmBC000310)
             ,new CursorDef("BC000311", "SELECT TOP 1 [ProductId] FROM [Product] WHERE [ProductCountryID] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000311,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000312", "SELECT TOP 1 [CustomerId] FROM [Customer] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000312,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000313", "SELECT TOP 1 [SellerId] FROM [Seller] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000313,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000314", "SELECT TM1.[CountryId], TM1.[CountryName], TM1.[CountryFlag_GXI], TM1.[CountryFlag] FROM [Country] TM1 WHERE TM1.[CountryId] = @CountryId ORDER BY TM1.[CountryId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000314,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
       }
    }

 }

}
