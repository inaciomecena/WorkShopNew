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
   public class promotion : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A12ProductId = (short)(NumberUtil.Val( GetPar( "ProductId"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A12ProductId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpromotion_product") == 0 )
         {
            nRC_GXsfl_63 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_63"), "."));
            nGXsfl_63_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_63_idx"), "."));
            sGXsfl_63_idx = GetPar( "sGXsfl_63_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridpromotion_product_newrow( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7PromotionId = (short)(NumberUtil.Val( GetPar( "PromotionId"), "."));
               AssignAttri("", false, "AV7PromotionId", StringUtil.LTrimStr( (decimal)(AV7PromotionId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPROMOTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PromotionId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 17_0_9-159740", 0) ;
            }
            Form.Meta.addItem("description", "Promoção", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPromotionDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public promotion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public promotion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_PromotionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PromotionId = aP1_PromotionId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("masterpage", "GeneXus.Programs.masterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Promoção", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPromotionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromotionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPromotionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15PromotionId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPromotionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A15PromotionId), "ZZZ9") : context.localUtil.Format( (decimal)(A15PromotionId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromotionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromotionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPromotionDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromotionDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromotionDescription_Internalname, StringUtil.RTrim( A29PromotionDescription), StringUtil.RTrim( context.localUtil.Format( A29PromotionDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromotionDescription_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromotionDescription_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgPromotionPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A30PromotionPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A30PromotionPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PromotionPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A30PromotionPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A30PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.PathToRelativeUrl( A30PromotionPhoto));
         GxWebStd.gx_bitmap( context, imgPromotionPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPromotionPhoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", "", "", 0, A30PromotionPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Promotion.htm");
         AssignProp("", false, imgPromotionPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A30PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.PathToRelativeUrl( A30PromotionPhoto)), true);
         AssignProp("", false, imgPromotionPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A30PromotionPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDateStart_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDateStart_Internalname, "Start", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDateStart_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDateStart_Internalname, context.localUtil.Format(A31DateStart, "99/99/99"), context.localUtil.Format( A31DateStart, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDateStart_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDateStart_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Promotion.htm");
         GxWebStd.gx_bitmap( context, edtDateStart_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDateStart_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Promotion.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDateFinish_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDateFinish_Internalname, "Finish", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDateFinish_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDateFinish_Internalname, context.localUtil.Format(A32DateFinish, "99/99/99"), context.localUtil.Format( A32DateFinish, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDateFinish_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDateFinish_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Promotion.htm");
         GxWebStd.gx_bitmap( context, edtDateFinish_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDateFinish_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Promotion.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divProducttable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleproduct_Internalname, "Product", "", "", lblTitleproduct_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridpromotion_product( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promotion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridpromotion_product( )
      {
         /*  Grid Control  */
         Gridpromotion_productContainer.AddObjectProperty("GridName", "Gridpromotion_product");
         Gridpromotion_productContainer.AddObjectProperty("Header", subGridpromotion_product_Header);
         Gridpromotion_productContainer.AddObjectProperty("Class", "Grid");
         Gridpromotion_productContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Backcolorstyle), 1, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("CmpContext", "");
         Gridpromotion_productContainer.AddObjectProperty("InMasterPage", "false");
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ".", "")));
         Gridpromotion_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productColumn.AddObjectProperty("Value", StringUtil.RTrim( A13ProductName));
         Gridpromotion_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromotion_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 11, 2, ".", "")));
         Gridpromotion_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", "")));
         Gridpromotion_productContainer.AddColumnProperties(Gridpromotion_productColumn);
         Gridpromotion_productContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Selectedindex), 4, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Allowselection), 1, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Selectioncolor), 9, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Allowhovering), 1, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Hoveringcolor), 9, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Allowcollapsing), 1, 0, ".", "")));
         Gridpromotion_productContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromotion_product_Collapsed), 1, 0, ".", "")));
         nGXsfl_63_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount8 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_8 = 1;
               ScanStart088( ) ;
               while ( RcdFound8 != 0 )
               {
                  init_level_properties8( ) ;
                  getByPrimaryKey088( ) ;
                  AddRow088( ) ;
                  ScanNext088( ) ;
               }
               ScanEnd088( ) ;
               nBlankRcdCount8 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal088( ) ;
            standaloneModal088( ) ;
            sMode8 = Gx_mode;
            while ( nGXsfl_63_idx < nRC_GXsfl_63 )
            {
               bGXsfl_63_Refreshing = true;
               ReadRow088( ) ;
               edtProductId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_63_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtProductName_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtProductPrice_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTPRICE_"+sGXsfl_63_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               imgprompt_12_Link = cgiGet( "PROMPT_12_"+sGXsfl_63_idx+"Link");
               if ( ( nRcdExists_8 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal088( ) ;
               }
               SendRow088( ) ;
               bGXsfl_63_Refreshing = false;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount8 = 5;
            nRcdExists_8 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart088( ) ;
               while ( RcdFound8 != 0 )
               {
                  sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_638( ) ;
                  init_level_properties8( ) ;
                  standaloneNotModal088( ) ;
                  getByPrimaryKey088( ) ;
                  standaloneModal088( ) ;
                  AddRow088( ) ;
                  ScanNext088( ) ;
               }
               ScanEnd088( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode8 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
            SubsflControlProps_638( ) ;
            InitAll088( ) ;
            init_level_properties8( ) ;
            nRcdExists_8 = 0;
            nIsMod_8 = 0;
            nRcdDeleted_8 = 0;
            nBlankRcdCount8 = (short)(nBlankRcdUsr8+nBlankRcdCount8);
            fRowAdded = 0;
            while ( nBlankRcdCount8 > 0 )
            {
               standaloneNotModal088( ) ;
               standaloneModal088( ) ;
               AddRow088( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount8 = (short)(nBlankRcdCount8-1);
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridpromotion_productContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpromotion_product", Gridpromotion_productContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpromotion_productContainerData", Gridpromotion_productContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpromotion_productContainerData"+"V", Gridpromotion_productContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridpromotion_productContainerData"+"V"+"\" value='"+Gridpromotion_productContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11082 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z15PromotionId = (short)(context.localUtil.CToN( cgiGet( "Z15PromotionId"), ",", "."));
               Z29PromotionDescription = cgiGet( "Z29PromotionDescription");
               Z31DateStart = context.localUtil.CToD( cgiGet( "Z31DateStart"), 0);
               Z32DateFinish = context.localUtil.CToD( cgiGet( "Z32DateFinish"), 0);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_63 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_63"), ",", "."));
               AV7PromotionId = (short)(context.localUtil.CToN( cgiGet( "vPROMOTIONID"), ",", "."));
               A40000PromotionPhoto_GXI = cgiGet( "PROMOTIONPHOTO_GXI");
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A15PromotionId = (short)(context.localUtil.CToN( cgiGet( edtPromotionId_Internalname), ",", "."));
               AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
               A29PromotionDescription = cgiGet( edtPromotionDescription_Internalname);
               AssignAttri("", false, "A29PromotionDescription", A29PromotionDescription);
               A30PromotionPhoto = cgiGet( imgPromotionPhoto_Internalname);
               AssignAttri("", false, "A30PromotionPhoto", A30PromotionPhoto);
               if ( context.localUtil.VCDate( cgiGet( edtDateStart_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Date Start"}), 1, "DATESTART");
                  AnyError = 1;
                  GX_FocusControl = edtDateStart_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A31DateStart = DateTime.MinValue;
                  AssignAttri("", false, "A31DateStart", context.localUtil.Format(A31DateStart, "99/99/99"));
               }
               else
               {
                  A31DateStart = context.localUtil.CToD( cgiGet( edtDateStart_Internalname), 2);
                  AssignAttri("", false, "A31DateStart", context.localUtil.Format(A31DateStart, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtDateFinish_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Date Finish"}), 1, "DATEFINISH");
                  AnyError = 1;
                  GX_FocusControl = edtDateFinish_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A32DateFinish = DateTime.MinValue;
                  AssignAttri("", false, "A32DateFinish", context.localUtil.Format(A32DateFinish, "99/99/99"));
               }
               else
               {
                  A32DateFinish = context.localUtil.CToD( cgiGet( edtDateFinish_Internalname), 2);
                  AssignAttri("", false, "A32DateFinish", context.localUtil.Format(A32DateFinish, "99/99/99"));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgPromotionPhoto_Internalname, ref  A30PromotionPhoto, ref  A40000PromotionPhoto_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Promotion");
               A15PromotionId = (short)(context.localUtil.CToN( cgiGet( edtPromotionId_Internalname), ",", "."));
               AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
               forbiddenHiddens.Add("PromotionId", context.localUtil.Format( (decimal)(A15PromotionId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A15PromotionId != Z15PromotionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("promotion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A15PromotionId = (short)(NumberUtil.Val( GetPar( "PromotionId"), "."));
                  AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode7 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode7;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound7 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_080( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROMOTIONID");
                        AnyError = 1;
                        GX_FocusControl = edtPromotionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
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
            E12082 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll087( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes087( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_080( )
      {
         BeforeValidate087( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls087( ) ;
            }
            else
            {
               CheckExtendedTable087( ) ;
               CloseExtendedTableCursors087( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode7 = Gx_mode;
            CONFIRM_088( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode7;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_088( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow088( ) ;
            if ( ( nRcdExists_8 != 0 ) || ( nIsMod_8 != 0 ) )
            {
               GetKey088( ) ;
               if ( ( nRcdExists_8 == 0 ) && ( nRcdDeleted_8 == 0 ) )
               {
                  if ( RcdFound8 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate088( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable088( ) ;
                        CloseExtendedTableCursors088( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound8 != 0 )
                  {
                     if ( nRcdDeleted_8 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey088( ) ;
                        Load088( ) ;
                        BeforeValidate088( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls088( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_8 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate088( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable088( ) ;
                              CloseExtendedTableCursors088( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_8 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( edtProductName_Internalname, StringUtil.RTrim( A13ProductName)) ;
            ChangePostValue( edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 11, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z12ProductId_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_8_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_8), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_8_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_8), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_8_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_8), 4, 0, ",", ""))) ;
            if ( nIsMod_8 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTPRICE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption080( )
      {
      }

      protected void E11082( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12082( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwpromotion.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM087( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z29PromotionDescription = T00086_A29PromotionDescription[0];
               Z31DateStart = T00086_A31DateStart[0];
               Z32DateFinish = T00086_A32DateFinish[0];
            }
            else
            {
               Z29PromotionDescription = A29PromotionDescription;
               Z31DateStart = A31DateStart;
               Z32DateFinish = A32DateFinish;
            }
         }
         if ( GX_JID == -6 )
         {
            Z15PromotionId = A15PromotionId;
            Z29PromotionDescription = A29PromotionDescription;
            Z30PromotionPhoto = A30PromotionPhoto;
            Z40000PromotionPhoto_GXI = A40000PromotionPhoto_GXI;
            Z31DateStart = A31DateStart;
            Z32DateFinish = A32DateFinish;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPromotionId_Enabled = 0;
         AssignProp("", false, edtPromotionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionId_Enabled), 5, 0), true);
         edtPromotionId_Enabled = 0;
         AssignProp("", false, edtPromotionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PromotionId) )
         {
            A15PromotionId = AV7PromotionId;
            AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load087( )
      {
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A15PromotionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound7 = 1;
            A29PromotionDescription = T00087_A29PromotionDescription[0];
            AssignAttri("", false, "A29PromotionDescription", A29PromotionDescription);
            A40000PromotionPhoto_GXI = T00087_A40000PromotionPhoto_GXI[0];
            AssignProp("", false, imgPromotionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A30PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A30PromotionPhoto))), true);
            AssignProp("", false, imgPromotionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A30PromotionPhoto), true);
            A31DateStart = T00087_A31DateStart[0];
            AssignAttri("", false, "A31DateStart", context.localUtil.Format(A31DateStart, "99/99/99"));
            A32DateFinish = T00087_A32DateFinish[0];
            AssignAttri("", false, "A32DateFinish", context.localUtil.Format(A32DateFinish, "99/99/99"));
            A30PromotionPhoto = T00087_A30PromotionPhoto[0];
            AssignAttri("", false, "A30PromotionPhoto", A30PromotionPhoto);
            AssignProp("", false, imgPromotionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A30PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A30PromotionPhoto))), true);
            AssignProp("", false, imgPromotionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A30PromotionPhoto), true);
            ZM087( -6) ;
         }
         pr_default.close(5);
         OnLoadActions087( ) ;
      }

      protected void OnLoadActions087( )
      {
         AV11Pgmname = "Promotion";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable087( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Promotion";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         if ( ! ( (DateTime.MinValue==A31DateStart) || ( DateTimeUtil.ResetTime ( A31DateStart ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Date Start fora do intervalo", "OutOfRange", 1, "DATESTART");
            AnyError = 1;
            GX_FocusControl = edtDateStart_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( DateTimeUtil.ResetTime ( A31DateStart ) > DateTimeUtil.ResetTime ( A32DateFinish ) )
         {
            GX_msglist.addItem("A data de início não pode ser posterior à data de término", 1, "DATESTART");
            AnyError = 1;
            GX_FocusControl = edtDateStart_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A32DateFinish) || ( DateTimeUtil.ResetTime ( A32DateFinish ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Date Finish fora do intervalo", "OutOfRange", 1, "DATEFINISH");
            AnyError = 1;
            GX_FocusControl = edtDateFinish_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors087( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey087( )
      {
         /* Using cursor T00088 */
         pr_default.execute(6, new Object[] {A15PromotionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {A15PromotionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM087( 6) ;
            RcdFound7 = 1;
            A15PromotionId = T00086_A15PromotionId[0];
            AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
            A29PromotionDescription = T00086_A29PromotionDescription[0];
            AssignAttri("", false, "A29PromotionDescription", A29PromotionDescription);
            A40000PromotionPhoto_GXI = T00086_A40000PromotionPhoto_GXI[0];
            AssignProp("", false, imgPromotionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A30PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A30PromotionPhoto))), true);
            AssignProp("", false, imgPromotionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A30PromotionPhoto), true);
            A31DateStart = T00086_A31DateStart[0];
            AssignAttri("", false, "A31DateStart", context.localUtil.Format(A31DateStart, "99/99/99"));
            A32DateFinish = T00086_A32DateFinish[0];
            AssignAttri("", false, "A32DateFinish", context.localUtil.Format(A32DateFinish, "99/99/99"));
            A30PromotionPhoto = T00086_A30PromotionPhoto[0];
            AssignAttri("", false, "A30PromotionPhoto", A30PromotionPhoto);
            AssignProp("", false, imgPromotionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A30PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A30PromotionPhoto))), true);
            AssignProp("", false, imgPromotionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A30PromotionPhoto), true);
            Z15PromotionId = A15PromotionId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load087( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey087( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey087( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey087( ) ;
         if ( RcdFound7 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {A15PromotionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00089_A15PromotionId[0] < A15PromotionId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00089_A15PromotionId[0] > A15PromotionId ) ) )
            {
               A15PromotionId = T00089_A15PromotionId[0];
               AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T000810 */
         pr_default.execute(8, new Object[] {A15PromotionId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000810_A15PromotionId[0] > A15PromotionId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000810_A15PromotionId[0] < A15PromotionId ) ) )
            {
               A15PromotionId = T000810_A15PromotionId[0];
               AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey087( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPromotionDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert087( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A15PromotionId != Z15PromotionId )
               {
                  A15PromotionId = Z15PromotionId;
                  AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROMOTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtPromotionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPromotionDescription_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update087( ) ;
                  GX_FocusControl = edtPromotionDescription_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A15PromotionId != Z15PromotionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtPromotionDescription_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert087( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROMOTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtPromotionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPromotionDescription_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert087( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A15PromotionId != Z15PromotionId )
         {
            A15PromotionId = Z15PromotionId;
            AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROMOTIONID");
            AnyError = 1;
            GX_FocusControl = edtPromotionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPromotionDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency087( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00085 */
            pr_default.execute(3, new Object[] {A15PromotionId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Promotion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z29PromotionDescription, T00085_A29PromotionDescription[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z31DateStart ) != DateTimeUtil.ResetTime ( T00085_A31DateStart[0] ) ) || ( DateTimeUtil.ResetTime ( Z32DateFinish ) != DateTimeUtil.ResetTime ( T00085_A32DateFinish[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z29PromotionDescription, T00085_A29PromotionDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("promotion:[seudo value changed for attri]"+"PromotionDescription");
                  GXUtil.WriteLogRaw("Old: ",Z29PromotionDescription);
                  GXUtil.WriteLogRaw("Current: ",T00085_A29PromotionDescription[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z31DateStart ) != DateTimeUtil.ResetTime ( T00085_A31DateStart[0] ) )
               {
                  GXUtil.WriteLog("promotion:[seudo value changed for attri]"+"DateStart");
                  GXUtil.WriteLogRaw("Old: ",Z31DateStart);
                  GXUtil.WriteLogRaw("Current: ",T00085_A31DateStart[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z32DateFinish ) != DateTimeUtil.ResetTime ( T00085_A32DateFinish[0] ) )
               {
                  GXUtil.WriteLog("promotion:[seudo value changed for attri]"+"DateFinish");
                  GXUtil.WriteLogRaw("Old: ",Z32DateFinish);
                  GXUtil.WriteLogRaw("Current: ",T00085_A32DateFinish[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Promotion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert087( )
      {
         BeforeValidate087( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable087( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM087( 0) ;
            CheckOptimisticConcurrency087( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm087( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert087( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000811 */
                     pr_default.execute(9, new Object[] {A29PromotionDescription, A30PromotionPhoto, A40000PromotionPhoto_GXI, A31DateStart, A32DateFinish});
                     A15PromotionId = T000811_A15PromotionId[0];
                     AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Promotion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel087( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption080( ) ;
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
               Load087( ) ;
            }
            EndLevel087( ) ;
         }
         CloseExtendedTableCursors087( ) ;
      }

      protected void Update087( )
      {
         BeforeValidate087( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable087( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency087( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm087( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate087( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000812 */
                     pr_default.execute(10, new Object[] {A29PromotionDescription, A31DateStart, A32DateFinish, A15PromotionId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Promotion");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Promotion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate087( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel087( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
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
            }
            EndLevel087( ) ;
         }
         CloseExtendedTableCursors087( ) ;
      }

      protected void DeferredUpdate087( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000813 */
            pr_default.execute(11, new Object[] {A30PromotionPhoto, A40000PromotionPhoto_GXI, A15PromotionId});
            pr_default.close(11);
            dsDefault.SmartCacheProvider.SetUpdated("Promotion");
         }
      }

      protected void delete( )
      {
         BeforeValidate087( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency087( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls087( ) ;
            AfterConfirm087( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete087( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart088( ) ;
                  while ( RcdFound8 != 0 )
                  {
                     getByPrimaryKey088( ) ;
                     Delete088( ) ;
                     ScanNext088( ) ;
                  }
                  ScanEnd088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000814 */
                     pr_default.execute(12, new Object[] {A15PromotionId});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("Promotion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
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
            }
         }
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel087( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls087( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Promotion";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void ProcessNestedLevel088( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow088( ) ;
            if ( ( nRcdExists_8 != 0 ) || ( nIsMod_8 != 0 ) )
            {
               standaloneNotModal088( ) ;
               GetKey088( ) ;
               if ( ( nRcdExists_8 == 0 ) && ( nRcdDeleted_8 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert088( ) ;
               }
               else
               {
                  if ( RcdFound8 != 0 )
                  {
                     if ( ( nRcdDeleted_8 != 0 ) && ( nRcdExists_8 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete088( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_8 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update088( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_8 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( edtProductName_Internalname, StringUtil.RTrim( A13ProductName)) ;
            ChangePostValue( edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 11, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z12ProductId_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_8_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_8), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_8_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_8), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_8_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_8), 4, 0, ",", ""))) ;
            if ( nIsMod_8 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTPRICE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll088( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_8 = 0;
         nIsMod_8 = 0;
         nRcdDeleted_8 = 0;
      }

      protected void ProcessLevel087( )
      {
         /* Save parent mode. */
         sMode7 = Gx_mode;
         ProcessNestedLevel088( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel087( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete087( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("promotion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("promotion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart087( )
      {
         /* Scan By routine */
         /* Using cursor T000815 */
         pr_default.execute(13);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound7 = 1;
            A15PromotionId = T000815_A15PromotionId[0];
            AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext087( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound7 = 1;
            A15PromotionId = T000815_A15PromotionId[0];
            AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
         }
      }

      protected void ScanEnd087( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm087( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert087( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate087( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete087( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete087( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate087( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes087( )
      {
         edtPromotionId_Enabled = 0;
         AssignProp("", false, edtPromotionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionId_Enabled), 5, 0), true);
         edtPromotionDescription_Enabled = 0;
         AssignProp("", false, edtPromotionDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromotionDescription_Enabled), 5, 0), true);
         imgPromotionPhoto_Enabled = 0;
         AssignProp("", false, imgPromotionPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgPromotionPhoto_Enabled), 5, 0), true);
         edtDateStart_Enabled = 0;
         AssignProp("", false, edtDateStart_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDateStart_Enabled), 5, 0), true);
         edtDateFinish_Enabled = 0;
         AssignProp("", false, edtDateFinish_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDateFinish_Enabled), 5, 0), true);
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -7 )
         {
            Z15PromotionId = A15PromotionId;
            Z12ProductId = A12ProductId;
            Z13ProductName = A13ProductName;
            Z27ProductPrice = A27ProductPrice;
         }
      }

      protected void standaloneNotModal088( )
      {
      }

      protected void standaloneModal088( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProductId_Enabled = 0;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
         else
         {
            edtProductId_Enabled = 1;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
      }

      protected void Load088( )
      {
         /* Using cursor T000816 */
         pr_default.execute(14, new Object[] {A15PromotionId, A12ProductId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound8 = 1;
            A13ProductName = T000816_A13ProductName[0];
            A27ProductPrice = T000816_A27ProductPrice[0];
            ZM088( -7) ;
         }
         pr_default.close(14);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
      }

      protected void CheckExtendedTable088( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         standaloneModal088( ) ;
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
            GX_msglist.addItem("Não existe 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A13ProductName = T00084_A13ProductName[0];
         A27ProductPrice = T00084_A27ProductPrice[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors088( )
      {
         pr_default.close(2);
      }

      protected void enableDisable088( )
      {
      }

      protected void gxLoad_8( short A12ProductId )
      {
         /* Using cursor T000817 */
         pr_default.execute(15, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
            GX_msglist.addItem("Não existe 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A13ProductName = T000817_A13ProductName[0];
         A27ProductPrice = T000817_A27ProductPrice[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A13ProductName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 8, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void GetKey088( )
      {
         /* Using cursor T000818 */
         pr_default.execute(16, new Object[] {A15PromotionId, A12ProductId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey088( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A15PromotionId, A12ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 7) ;
            RcdFound8 = 1;
            InitializeNonKey088( ) ;
            A12ProductId = T00083_A12ProductId[0];
            Z15PromotionId = A15PromotionId;
            Z12ProductId = A12ProductId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load088( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal088( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes088( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A15PromotionId, A12ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PromotionProduct"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PromotionProduct"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000819 */
                     pr_default.execute(17, new Object[] {A15PromotionId, A12ProductId});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("PromotionProduct");
                     if ( (pr_default.getStatus(17) == 1) )
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( ( nIsMod_8 != 0 ) || ( nIsDirty_8 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency088( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm088( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate088( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [PromotionProduct] */
                        DeferredUpdate088( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey088( ) ;
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
               EndLevel088( ) ;
            }
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
      }

      protected void Delete088( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000820 */
                  pr_default.execute(18, new Object[] {A15PromotionId, A12ProductId});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("PromotionProduct");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel088( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal088( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000821 */
            pr_default.execute(19, new Object[] {A12ProductId});
            A13ProductName = T000821_A13ProductName[0];
            A27ProductPrice = T000821_A27ProductPrice[0];
            pr_default.close(19);
         }
      }

      protected void EndLevel088( )
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

      public void ScanStart088( )
      {
         /* Scan By routine */
         /* Using cursor T000822 */
         pr_default.execute(20, new Object[] {A15PromotionId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound8 = 1;
            A12ProductId = T000822_A12ProductId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound8 = 1;
            A12ProductId = T000822_A12ProductId[0];
         }
      }

      protected void ScanEnd088( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtProductPrice_Enabled = 0;
         AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void send_integrity_lvl_hashes087( )
      {
      }

      protected void SubsflControlProps_638( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_63_idx;
         imgprompt_12_Internalname = "PROMPT_12_"+sGXsfl_63_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_63_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_63_idx;
      }

      protected void SubsflControlProps_fel_638( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_63_fel_idx;
         imgprompt_12_Internalname = "PROMPT_12_"+sGXsfl_63_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_63_fel_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_63_fel_idx;
      }

      protected void AddRow088( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_638( ) ;
         SendRow088( ) ;
      }

      protected void SendRow088( )
      {
         Gridpromotion_productRow = GXWebRow.GetNew(context);
         if ( subGridpromotion_product_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridpromotion_product_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
            {
               subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Odd";
            }
         }
         else if ( subGridpromotion_product_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridpromotion_product_Backstyle = 0;
            subGridpromotion_product_Backcolor = subGridpromotion_product_Allbackcolor;
            if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
            {
               subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Uniform";
            }
         }
         else if ( subGridpromotion_product_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridpromotion_product_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
            {
               subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Odd";
            }
            subGridpromotion_product_Backcolor = (int)(0x0);
         }
         else if ( subGridpromotion_product_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridpromotion_product_Backstyle = 1;
            if ( ((int)((nGXsfl_63_idx) % (2))) == 0 )
            {
               subGridpromotion_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
               {
                  subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Even";
               }
            }
            else
            {
               subGridpromotion_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpromotion_product_Class, "") != 0 )
               {
                  subGridpromotion_product_Linesclass = subGridpromotion_product_Class+"Odd";
               }
            }
         }
         imgprompt_12_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID_"+sGXsfl_63_idx+"'), id:'"+"PRODUCTID_"+sGXsfl_63_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_8_"+sGXsfl_63_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_8_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridpromotion_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12ProductId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridpromotion_productRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_12_Internalname,(string)sImgUrl,(string)imgprompt_12_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_12_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridpromotion_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,StringUtil.RTrim( A13ProductName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridpromotion_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 11, 2, ",", "")),StringUtil.LTrim( ((edtProductPrice_Enabled!=0) ? context.localUtil.Format( A27ProductPrice, "R$ ZZZZ9.99") : context.localUtil.Format( A27ProductPrice, "R$ ZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductPrice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Gridpromotion_productRow);
         send_integrity_lvl_hashes088( ) ;
         GXCCtl = "Z12ProductId_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12ProductId), 4, 0, ",", "")));
         GXCCtl = "nRcdDeleted_8_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_8), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_8_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_8), 4, 0, ",", "")));
         GXCCtl = "nIsMod_8_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_8), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_63_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPROMOTIONID_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PromotionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTPRICE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_12_"+sGXsfl_63_idx+"Link", StringUtil.RTrim( imgprompt_12_Link));
         ajax_sending_grid_row(null);
         Gridpromotion_productContainer.AddRow(Gridpromotion_productRow);
      }

      protected void ReadRow088( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_638( ) ;
         edtProductId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_63_idx+"Enabled"), ",", "."));
         edtProductName_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_63_idx+"Enabled"), ",", "."));
         edtProductPrice_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTPRICE_"+sGXsfl_63_idx+"Enabled"), ",", "."));
         imgprompt_12_Link = cgiGet( "PROMPT_12_"+sGXsfl_63_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_63_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            wbErr = true;
            A12ProductId = 0;
         }
         else
         {
            A12ProductId = (short)(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", "."));
         }
         A13ProductName = cgiGet( edtProductName_Internalname);
         A27ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ",", ".");
         GXCCtl = "Z12ProductId_" + sGXsfl_63_idx;
         Z12ProductId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdDeleted_8_" + sGXsfl_63_idx;
         nRcdDeleted_8 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_8_" + sGXsfl_63_idx;
         nRcdExists_8 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_8_" + sGXsfl_63_idx;
         nIsMod_8 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void assign_properties_default( )
      {
         defedtProductId_Enabled = edtProductId_Enabled;
      }

      protected void ConfirmValues080( )
      {
         nGXsfl_63_idx = 0;
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_638( ) ;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_638( ) ;
            ChangePostValue( "Z12ProductId_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z12ProductId_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z12ProductId_"+sGXsfl_63_idx) ;
         }
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 204480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20235211521737", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("promotion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PromotionId,4,0))}, new string[] {"Gx_mode","PromotionId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Promotion");
         forbiddenHiddens.Add("PromotionId", context.localUtil.Format( (decimal)(A15PromotionId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("promotion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z15PromotionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15PromotionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z29PromotionDescription", StringUtil.RTrim( Z29PromotionDescription));
         GxWebStd.gx_hidden_field( context, "Z31DateStart", context.localUtil.DToC( Z31DateStart, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z32DateFinish", context.localUtil.DToC( Z32DateFinish, 0, "/"));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_63", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_63_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPROMOTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PromotionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PromotionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROMOTIONPHOTO_GXI", A40000PromotionPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
         GXCCtlgxBlob = "PROMOTIONPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A30PromotionPhoto);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("promotion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PromotionId,4,0))}, new string[] {"Gx_mode","PromotionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Promotion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Promoção" ;
      }

      protected void InitializeNonKey087( )
      {
         A29PromotionDescription = "";
         AssignAttri("", false, "A29PromotionDescription", A29PromotionDescription);
         A30PromotionPhoto = "";
         AssignAttri("", false, "A30PromotionPhoto", A30PromotionPhoto);
         AssignProp("", false, imgPromotionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A30PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A30PromotionPhoto))), true);
         AssignProp("", false, imgPromotionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A30PromotionPhoto), true);
         A40000PromotionPhoto_GXI = "";
         AssignProp("", false, imgPromotionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A30PromotionPhoto)) ? A40000PromotionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A30PromotionPhoto))), true);
         AssignProp("", false, imgPromotionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A30PromotionPhoto), true);
         A31DateStart = DateTime.MinValue;
         AssignAttri("", false, "A31DateStart", context.localUtil.Format(A31DateStart, "99/99/99"));
         A32DateFinish = DateTime.MinValue;
         AssignAttri("", false, "A32DateFinish", context.localUtil.Format(A32DateFinish, "99/99/99"));
         Z29PromotionDescription = "";
         Z31DateStart = DateTime.MinValue;
         Z32DateFinish = DateTime.MinValue;
      }

      protected void InitAll087( )
      {
         A15PromotionId = 0;
         AssignAttri("", false, "A15PromotionId", StringUtil.LTrimStr( (decimal)(A15PromotionId), 4, 0));
         InitializeNonKey087( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey088( )
      {
         A13ProductName = "";
         A27ProductPrice = 0;
      }

      protected void InitAll088( )
      {
         A12ProductId = 0;
         InitializeNonKey088( ) ;
      }

      protected void StandaloneModalInsert088( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20235211521758", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("promotion.js", "?20235211521759", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties8( )
      {
         edtProductId_Enabled = defedtProductId_Enabled;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtPromotionId_Internalname = "PROMOTIONID";
         edtPromotionDescription_Internalname = "PROMOTIONDESCRIPTION";
         imgPromotionPhoto_Internalname = "PROMOTIONPHOTO";
         edtDateStart_Internalname = "DATESTART";
         edtDateFinish_Internalname = "DATEFINISH";
         lblTitleproduct_Internalname = "TITLEPRODUCT";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         divProducttable_Internalname = "PRODUCTTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_12_Internalname = "PROMPT_12";
         subGridpromotion_product_Internalname = "GRIDPROMOTION_PRODUCT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Promoção";
         edtProductPrice_Jsonclick = "";
         edtProductName_Jsonclick = "";
         imgprompt_12_Visible = 1;
         imgprompt_12_Link = "";
         imgprompt_12_Visible = 1;
         edtProductId_Jsonclick = "";
         subGridpromotion_product_Class = "Grid";
         subGridpromotion_product_Backcolorstyle = 0;
         subGridpromotion_product_Allowcollapsing = 0;
         subGridpromotion_product_Allowselection = 0;
         edtProductPrice_Enabled = 0;
         edtProductName_Enabled = 0;
         edtProductId_Enabled = 1;
         subGridpromotion_product_Header = "";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDateFinish_Jsonclick = "";
         edtDateFinish_Enabled = 1;
         edtDateStart_Jsonclick = "";
         edtDateStart_Enabled = 1;
         imgPromotionPhoto_Enabled = 1;
         edtPromotionDescription_Jsonclick = "";
         edtPromotionDescription_Enabled = 1;
         edtPromotionId_Jsonclick = "";
         edtPromotionId_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridpromotion_product_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_638( ) ;
         while ( nGXsfl_63_idx <= nRC_GXsfl_63 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal088( ) ;
            standaloneModal088( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow088( ) ;
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_638( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridpromotion_productContainer)) ;
         /* End function gxnrGridpromotion_product_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
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

      public void Valid_Productid( )
      {
         /* Using cursor T000821 */
         pr_default.execute(19, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("Não existe 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
         }
         A13ProductName = T000821_A13ProductName[0];
         A27ProductPrice = T000821_A27ProductPrice[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A13ProductName", StringUtil.RTrim( A13ProductName));
         AssignAttri("", false, "A27ProductPrice", StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 8, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7PromotionId',fld:'vPROMOTIONID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7PromotionId',fld:'vPROMOTIONID',pic:'ZZZ9',hsh:true},{av:'A15PromotionId',fld:'PROMOTIONID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12082',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PROMOTIONID","{handler:'Valid_Promotionid',iparms:[]");
         setEventMetadata("VALID_PROMOTIONID",",oparms:[]}");
         setEventMetadata("VALID_DATESTART","{handler:'Valid_Datestart',iparms:[]");
         setEventMetadata("VALID_DATESTART",",oparms:[]}");
         setEventMetadata("VALID_DATEFINISH","{handler:'Valid_Datefinish',iparms:[]");
         setEventMetadata("VALID_DATEFINISH",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A12ProductId',fld:'PRODUCTID',pic:'ZZZ9'},{av:'A13ProductName',fld:'PRODUCTNAME',pic:''},{av:'A27ProductPrice',fld:'PRODUCTPRICE',pic:'R$ ZZZZ9.99'}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[{av:'A13ProductName',fld:'PRODUCTNAME',pic:''},{av:'A27ProductPrice',fld:'PRODUCTPRICE',pic:'R$ ZZZZ9.99'}]}");
         setEventMetadata("NULL","{handler:'Valid_Productprice',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
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
         pr_default.close(19);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z29PromotionDescription = "";
         Z31DateStart = DateTime.MinValue;
         Z32DateFinish = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A29PromotionDescription = "";
         A30PromotionPhoto = "";
         A40000PromotionPhoto_GXI = "";
         sImgUrl = "";
         A31DateStart = DateTime.MinValue;
         A32DateFinish = DateTime.MinValue;
         lblTitleproduct_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridpromotion_productContainer = new GXWebGrid( context);
         Gridpromotion_productColumn = new GXWebColumn();
         A13ProductName = "";
         sMode8 = "";
         sStyleString = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode7 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z30PromotionPhoto = "";
         Z40000PromotionPhoto_GXI = "";
         T00087_A15PromotionId = new short[1] ;
         T00087_A29PromotionDescription = new string[] {""} ;
         T00087_A40000PromotionPhoto_GXI = new string[] {""} ;
         T00087_A31DateStart = new DateTime[] {DateTime.MinValue} ;
         T00087_A32DateFinish = new DateTime[] {DateTime.MinValue} ;
         T00087_A30PromotionPhoto = new string[] {""} ;
         T00088_A15PromotionId = new short[1] ;
         T00086_A15PromotionId = new short[1] ;
         T00086_A29PromotionDescription = new string[] {""} ;
         T00086_A40000PromotionPhoto_GXI = new string[] {""} ;
         T00086_A31DateStart = new DateTime[] {DateTime.MinValue} ;
         T00086_A32DateFinish = new DateTime[] {DateTime.MinValue} ;
         T00086_A30PromotionPhoto = new string[] {""} ;
         T00089_A15PromotionId = new short[1] ;
         T000810_A15PromotionId = new short[1] ;
         T00085_A15PromotionId = new short[1] ;
         T00085_A29PromotionDescription = new string[] {""} ;
         T00085_A40000PromotionPhoto_GXI = new string[] {""} ;
         T00085_A31DateStart = new DateTime[] {DateTime.MinValue} ;
         T00085_A32DateFinish = new DateTime[] {DateTime.MinValue} ;
         T00085_A30PromotionPhoto = new string[] {""} ;
         T000811_A15PromotionId = new short[1] ;
         T000815_A15PromotionId = new short[1] ;
         Z13ProductName = "";
         T000816_A15PromotionId = new short[1] ;
         T000816_A13ProductName = new string[] {""} ;
         T000816_A27ProductPrice = new decimal[1] ;
         T000816_A12ProductId = new short[1] ;
         T00084_A13ProductName = new string[] {""} ;
         T00084_A27ProductPrice = new decimal[1] ;
         T000817_A13ProductName = new string[] {""} ;
         T000817_A27ProductPrice = new decimal[1] ;
         T000818_A15PromotionId = new short[1] ;
         T000818_A12ProductId = new short[1] ;
         T00083_A15PromotionId = new short[1] ;
         T00083_A12ProductId = new short[1] ;
         T00082_A15PromotionId = new short[1] ;
         T00082_A12ProductId = new short[1] ;
         T000821_A13ProductName = new string[] {""} ;
         T000821_A27ProductPrice = new decimal[1] ;
         T000822_A15PromotionId = new short[1] ;
         T000822_A12ProductId = new short[1] ;
         Gridpromotion_productRow = new GXWebRow();
         subGridpromotion_product_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promotion__default(),
            new Object[][] {
                new Object[] {
               T00082_A15PromotionId, T00082_A12ProductId
               }
               , new Object[] {
               T00083_A15PromotionId, T00083_A12ProductId
               }
               , new Object[] {
               T00084_A13ProductName, T00084_A27ProductPrice
               }
               , new Object[] {
               T00085_A15PromotionId, T00085_A29PromotionDescription, T00085_A40000PromotionPhoto_GXI, T00085_A31DateStart, T00085_A32DateFinish, T00085_A30PromotionPhoto
               }
               , new Object[] {
               T00086_A15PromotionId, T00086_A29PromotionDescription, T00086_A40000PromotionPhoto_GXI, T00086_A31DateStart, T00086_A32DateFinish, T00086_A30PromotionPhoto
               }
               , new Object[] {
               T00087_A15PromotionId, T00087_A29PromotionDescription, T00087_A40000PromotionPhoto_GXI, T00087_A31DateStart, T00087_A32DateFinish, T00087_A30PromotionPhoto
               }
               , new Object[] {
               T00088_A15PromotionId
               }
               , new Object[] {
               T00089_A15PromotionId
               }
               , new Object[] {
               T000810_A15PromotionId
               }
               , new Object[] {
               T000811_A15PromotionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000815_A15PromotionId
               }
               , new Object[] {
               T000816_A15PromotionId, T000816_A13ProductName, T000816_A27ProductPrice, T000816_A12ProductId
               }
               , new Object[] {
               T000817_A13ProductName, T000817_A27ProductPrice
               }
               , new Object[] {
               T000818_A15PromotionId, T000818_A12ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000821_A13ProductName, T000821_A27ProductPrice
               }
               , new Object[] {
               T000822_A15PromotionId, T000822_A12ProductId
               }
            }
         );
         AV11Pgmname = "Promotion";
      }

      private short nIsMod_8 ;
      private short wcpOAV7PromotionId ;
      private short Z15PromotionId ;
      private short Z12ProductId ;
      private short nRcdDeleted_8 ;
      private short nRcdExists_8 ;
      private short GxWebError ;
      private short A12ProductId ;
      private short AV7PromotionId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A15PromotionId ;
      private short subGridpromotion_product_Backcolorstyle ;
      private short subGridpromotion_product_Allowselection ;
      private short subGridpromotion_product_Allowhovering ;
      private short subGridpromotion_product_Allowcollapsing ;
      private short subGridpromotion_product_Collapsed ;
      private short nBlankRcdCount8 ;
      private short RcdFound8 ;
      private short nBlankRcdUsr8 ;
      private short RcdFound7 ;
      private short GX_JID ;
      private short nIsDirty_7 ;
      private short Gx_BScreen ;
      private short nIsDirty_8 ;
      private short subGridpromotion_product_Backstyle ;
      private short gxajaxcallmode ;
      private int nRC_GXsfl_63 ;
      private int nGXsfl_63_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPromotionId_Enabled ;
      private int edtPromotionDescription_Enabled ;
      private int imgPromotionPhoto_Enabled ;
      private int edtDateStart_Enabled ;
      private int edtDateFinish_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductPrice_Enabled ;
      private int subGridpromotion_product_Selectedindex ;
      private int subGridpromotion_product_Selectioncolor ;
      private int subGridpromotion_product_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridpromotion_product_Backcolor ;
      private int subGridpromotion_product_Allbackcolor ;
      private int imgprompt_12_Visible ;
      private int defedtProductId_Enabled ;
      private int idxLst ;
      private long GRIDPROMOTION_PRODUCT_nFirstRecordOnPage ;
      private decimal A27ProductPrice ;
      private decimal Z27ProductPrice ;
      private string sPrefix ;
      private string sGXsfl_63_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z29PromotionDescription ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPromotionDescription_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtPromotionId_Internalname ;
      private string edtPromotionId_Jsonclick ;
      private string A29PromotionDescription ;
      private string edtPromotionDescription_Jsonclick ;
      private string imgPromotionPhoto_Internalname ;
      private string sImgUrl ;
      private string edtDateStart_Internalname ;
      private string edtDateStart_Jsonclick ;
      private string edtDateFinish_Internalname ;
      private string edtDateFinish_Jsonclick ;
      private string divProducttable_Internalname ;
      private string lblTitleproduct_Internalname ;
      private string lblTitleproduct_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridpromotion_product_Header ;
      private string A13ProductName ;
      private string sMode8 ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductPrice_Internalname ;
      private string imgprompt_12_Link ;
      private string sStyleString ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode7 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string Z13ProductName ;
      private string imgprompt_12_Internalname ;
      private string sGXsfl_63_fel_idx="0001" ;
      private string subGridpromotion_product_Class ;
      private string subGridpromotion_product_Linesclass ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtProductPrice_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string subGridpromotion_product_Internalname ;
      private DateTime Z31DateStart ;
      private DateTime Z32DateFinish ;
      private DateTime A31DateStart ;
      private DateTime A32DateFinish ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A30PromotionPhoto_IsBlob ;
      private bool bGXsfl_63_Refreshing=false ;
      private bool returnInSub ;
      private string A40000PromotionPhoto_GXI ;
      private string Z40000PromotionPhoto_GXI ;
      private string A30PromotionPhoto ;
      private string Z30PromotionPhoto ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridpromotion_productContainer ;
      private GXWebRow Gridpromotion_productRow ;
      private GXWebColumn Gridpromotion_productColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00087_A15PromotionId ;
      private string[] T00087_A29PromotionDescription ;
      private string[] T00087_A40000PromotionPhoto_GXI ;
      private DateTime[] T00087_A31DateStart ;
      private DateTime[] T00087_A32DateFinish ;
      private string[] T00087_A30PromotionPhoto ;
      private short[] T00088_A15PromotionId ;
      private short[] T00086_A15PromotionId ;
      private string[] T00086_A29PromotionDescription ;
      private string[] T00086_A40000PromotionPhoto_GXI ;
      private DateTime[] T00086_A31DateStart ;
      private DateTime[] T00086_A32DateFinish ;
      private string[] T00086_A30PromotionPhoto ;
      private short[] T00089_A15PromotionId ;
      private short[] T000810_A15PromotionId ;
      private short[] T00085_A15PromotionId ;
      private string[] T00085_A29PromotionDescription ;
      private string[] T00085_A40000PromotionPhoto_GXI ;
      private DateTime[] T00085_A31DateStart ;
      private DateTime[] T00085_A32DateFinish ;
      private string[] T00085_A30PromotionPhoto ;
      private short[] T000811_A15PromotionId ;
      private short[] T000815_A15PromotionId ;
      private short[] T000816_A15PromotionId ;
      private string[] T000816_A13ProductName ;
      private decimal[] T000816_A27ProductPrice ;
      private short[] T000816_A12ProductId ;
      private string[] T00084_A13ProductName ;
      private decimal[] T00084_A27ProductPrice ;
      private string[] T000817_A13ProductName ;
      private decimal[] T000817_A27ProductPrice ;
      private short[] T000818_A15PromotionId ;
      private short[] T000818_A12ProductId ;
      private short[] T00083_A15PromotionId ;
      private short[] T00083_A12ProductId ;
      private short[] T00082_A15PromotionId ;
      private short[] T00082_A12ProductId ;
      private string[] T000821_A13ProductName ;
      private decimal[] T000821_A27ProductPrice ;
      private short[] T000822_A15PromotionId ;
      private short[] T000822_A12ProductId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class promotion__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00087;
          prmT00087 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT00088;
          prmT00088 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT00086;
          prmT00086 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT00089;
          prmT00089 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000810;
          prmT000810 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT00085;
          prmT00085 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000811;
          prmT000811 = new Object[] {
          new ParDef("@PromotionDescription",GXType.NChar,50,0) ,
          new ParDef("@PromotionPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PromotionPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Promotion", Fld="PromotionPhoto"} ,
          new ParDef("@DateStart",GXType.Date,8,0) ,
          new ParDef("@DateFinish",GXType.Date,8,0)
          };
          Object[] prmT000812;
          prmT000812 = new Object[] {
          new ParDef("@PromotionDescription",GXType.NChar,50,0) ,
          new ParDef("@DateStart",GXType.Date,8,0) ,
          new ParDef("@DateFinish",GXType.Date,8,0) ,
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000813;
          prmT000813 = new Object[] {
          new ParDef("@PromotionPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PromotionPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Promotion", Fld="PromotionPhoto"} ,
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000814;
          prmT000814 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000815;
          prmT000815 = new Object[] {
          };
          Object[] prmT000816;
          prmT000816 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00084;
          prmT00084 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000817;
          prmT000817 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000818;
          prmT000818 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00083;
          prmT00083 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00082;
          prmT00082 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000819;
          prmT000819 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000820;
          prmT000820 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000822;
          prmT000822 = new Object[] {
          new ParDef("@PromotionId",GXType.Int16,4,0)
          };
          Object[] prmT000821;
          prmT000821 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00082", "SELECT [PromotionId], [ProductId] FROM [PromotionProduct] WITH (UPDLOCK) WHERE [PromotionId] = @PromotionId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00083", "SELECT [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [PromotionId] = @PromotionId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00084", "SELECT [ProductName], [ProductPrice] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00085", "SELECT [PromotionId], [PromotionDescription], [PromotionPhoto_GXI], [DateStart], [DateFinish], [PromotionPhoto] FROM [Promotion] WITH (UPDLOCK) WHERE [PromotionId] = @PromotionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00086", "SELECT [PromotionId], [PromotionDescription], [PromotionPhoto_GXI], [DateStart], [DateFinish], [PromotionPhoto] FROM [Promotion] WHERE [PromotionId] = @PromotionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00087", "SELECT TM1.[PromotionId], TM1.[PromotionDescription], TM1.[PromotionPhoto_GXI], TM1.[DateStart], TM1.[DateFinish], TM1.[PromotionPhoto] FROM [Promotion] TM1 WHERE TM1.[PromotionId] = @PromotionId ORDER BY TM1.[PromotionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00088", "SELECT [PromotionId] FROM [Promotion] WHERE [PromotionId] = @PromotionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00089", "SELECT TOP 1 [PromotionId] FROM [Promotion] WHERE ( [PromotionId] > @PromotionId) ORDER BY [PromotionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000810", "SELECT TOP 1 [PromotionId] FROM [Promotion] WHERE ( [PromotionId] < @PromotionId) ORDER BY [PromotionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000811", "INSERT INTO [Promotion]([PromotionDescription], [PromotionPhoto], [PromotionPhoto_GXI], [DateStart], [DateFinish]) VALUES(@PromotionDescription, @PromotionPhoto, @PromotionPhoto_GXI, @DateStart, @DateFinish); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000811)
             ,new CursorDef("T000812", "UPDATE [Promotion] SET [PromotionDescription]=@PromotionDescription, [DateStart]=@DateStart, [DateFinish]=@DateFinish  WHERE [PromotionId] = @PromotionId", GxErrorMask.GX_NOMASK,prmT000812)
             ,new CursorDef("T000813", "UPDATE [Promotion] SET [PromotionPhoto]=@PromotionPhoto, [PromotionPhoto_GXI]=@PromotionPhoto_GXI  WHERE [PromotionId] = @PromotionId", GxErrorMask.GX_NOMASK,prmT000813)
             ,new CursorDef("T000814", "DELETE FROM [Promotion]  WHERE [PromotionId] = @PromotionId", GxErrorMask.GX_NOMASK,prmT000814)
             ,new CursorDef("T000815", "SELECT [PromotionId] FROM [Promotion] ORDER BY [PromotionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000815,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000816", "SELECT T1.[PromotionId], T2.[ProductName], T2.[ProductPrice], T1.[ProductId] FROM ([PromotionProduct] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PromotionId] = @PromotionId and T1.[ProductId] = @ProductId ORDER BY T1.[PromotionId], T1.[ProductId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000816,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000817", "SELECT [ProductName], [ProductPrice] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000817,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000818", "SELECT [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [PromotionId] = @PromotionId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000818,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000819", "INSERT INTO [PromotionProduct]([PromotionId], [ProductId]) VALUES(@PromotionId, @ProductId)", GxErrorMask.GX_NOMASK,prmT000819)
             ,new CursorDef("T000820", "DELETE FROM [PromotionProduct]  WHERE [PromotionId] = @PromotionId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000820)
             ,new CursorDef("T000821", "SELECT [ProductName], [ProductPrice] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000821,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000822", "SELECT [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [PromotionId] = @PromotionId ORDER BY [PromotionId], [ProductId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000822,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
