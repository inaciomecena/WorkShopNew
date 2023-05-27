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
   public class seller : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A8CountryId = (short)(NumberUtil.Val( GetPar( "CountryId"), "."));
            AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A8CountryId) ;
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
               AV7SellerId = (short)(NumberUtil.Val( GetPar( "SellerId"), "."));
               AssignAttri("", false, "AV7SellerId", StringUtil.LTrimStr( (decimal)(AV7SellerId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSELLERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SellerId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Vendedores", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSellerName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public seller( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public seller( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_SellerId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SellerId = aP1_SellerId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Vendedores", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Seller.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seller.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seller.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seller.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seller.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Seller.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSellerId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSellerId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSellerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SellerId), 4, 0, ",", "")), StringUtil.LTrim( ((edtSellerId_Enabled!=0) ? context.localUtil.Format( (decimal)(A10SellerId), "ZZZ9") : context.localUtil.Format( (decimal)(A10SellerId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSellerId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSellerId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Seller.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSellerName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSellerName_Internalname, "Vendedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSellerName_Internalname, StringUtil.RTrim( A18SellerName), StringUtil.RTrim( context.localUtil.Format( A18SellerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSellerName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSellerName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Seller.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgSellerPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Foto", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A19SellerPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000SellerPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40000SellerPhoto_GXI : context.PathToRelativeUrl( A19SellerPhoto));
         GxWebStd.gx_bitmap( context, imgSellerPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgSellerPhoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", "", "", 0, A19SellerPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Seller.htm");
         AssignProp("", false, imgSellerPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40000SellerPhoto_GXI : context.PathToRelativeUrl( A19SellerPhoto)), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A19SellerPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryId_Internalname, "País Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A8CountryId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Seller.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_8_Internalname, sImgUrl, imgprompt_8_Link, "", "", context.GetTheme( ), imgprompt_8_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seller.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryName_Internalname, "País", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, StringUtil.RTrim( A9CountryName), StringUtil.RTrim( context.localUtil.Format( A9CountryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Seller.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seller.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seller.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seller.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         E11042 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z10SellerId = (short)(context.localUtil.CToN( cgiGet( "Z10SellerId"), ",", "."));
               Z18SellerName = cgiGet( "Z18SellerName");
               Z8CountryId = (short)(context.localUtil.CToN( cgiGet( "Z8CountryId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N8CountryId = (short)(context.localUtil.CToN( cgiGet( "N8CountryId"), ",", "."));
               AV7SellerId = (short)(context.localUtil.CToN( cgiGet( "vSELLERID"), ",", "."));
               AV11Insert_CountryId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_COUNTRYID"), ",", "."));
               A40000SellerPhoto_GXI = cgiGet( "SELLERPHOTO_GXI");
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A10SellerId = (short)(context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ",", "."));
               AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
               A18SellerName = cgiGet( edtSellerName_Internalname);
               AssignAttri("", false, "A18SellerName", A18SellerName);
               A19SellerPhoto = cgiGet( imgSellerPhoto_Internalname);
               AssignAttri("", false, "A19SellerPhoto", A19SellerPhoto);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COUNTRYID");
                  AnyError = 1;
                  GX_FocusControl = edtCountryId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A8CountryId = 0;
                  AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
               }
               else
               {
                  A8CountryId = (short)(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ",", "."));
                  AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
               }
               A9CountryName = cgiGet( edtCountryName_Internalname);
               AssignAttri("", false, "A9CountryName", A9CountryName);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgSellerPhoto_Internalname, ref  A19SellerPhoto, ref  A40000SellerPhoto_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Seller");
               A10SellerId = (short)(context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ",", "."));
               AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
               forbiddenHiddens.Add("SellerId", context.localUtil.Format( (decimal)(A10SellerId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A10SellerId != Z10SellerId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("seller:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A10SellerId = (short)(NumberUtil.Val( GetPar( "SellerId"), "."));
                  AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
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
                     sMode4 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode4;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound4 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_040( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SELLERID");
                        AnyError = 1;
                        GX_FocusControl = edtSellerId_Internalname;
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
                           E11042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12042 ();
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
            E12042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll044( ) ;
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
            DisableAttributes044( ) ;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls044( ) ;
            }
            else
            {
               CheckExtendedTable044( ) ;
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption040( )
      {
      }

      protected void E11042( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_CountryId = 0;
         AssignAttri("", false, "AV11Insert_CountryId", StringUtil.LTrimStr( (decimal)(AV11Insert_CountryId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV13Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV14GXV1 = 1;
            AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            while ( AV14GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV14GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "CountryId") == 0 )
               {
                  AV11Insert_CountryId = (short)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_CountryId", StringUtil.LTrimStr( (decimal)(AV11Insert_CountryId), 4, 0));
               }
               AV14GXV1 = (int)(AV14GXV1+1);
               AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwseller.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z18SellerName = T00043_A18SellerName[0];
               Z8CountryId = T00043_A8CountryId[0];
            }
            else
            {
               Z18SellerName = A18SellerName;
               Z8CountryId = A8CountryId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z10SellerId = A10SellerId;
            Z18SellerName = A18SellerName;
            Z19SellerPhoto = A19SellerPhoto;
            Z40000SellerPhoto_GXI = A40000SellerPhoto_GXI;
            Z8CountryId = A8CountryId;
            Z9CountryName = A9CountryName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSellerId_Enabled = 0;
         AssignProp("", false, edtSellerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSellerId_Enabled), 5, 0), true);
         imgprompt_8_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COUNTRYID"+"'), id:'"+"COUNTRYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtSellerId_Enabled = 0;
         AssignProp("", false, edtSellerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSellerId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SellerId) )
         {
            A10SellerId = AV7SellerId;
            AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_CountryId) )
         {
            edtCountryId_Enabled = 0;
            AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         }
         else
         {
            edtCountryId_Enabled = 1;
            AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_CountryId) )
         {
            A8CountryId = AV11Insert_CountryId;
            AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV13Pgmname = "Seller";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T00044 */
            pr_default.execute(2, new Object[] {A8CountryId});
            A9CountryName = T00044_A9CountryName[0];
            AssignAttri("", false, "A9CountryName", A9CountryName);
            pr_default.close(2);
         }
      }

      protected void Load044( )
      {
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A10SellerId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound4 = 1;
            A18SellerName = T00045_A18SellerName[0];
            AssignAttri("", false, "A18SellerName", A18SellerName);
            A40000SellerPhoto_GXI = T00045_A40000SellerPhoto_GXI[0];
            AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40000SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
            AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
            A9CountryName = T00045_A9CountryName[0];
            AssignAttri("", false, "A9CountryName", A9CountryName);
            A8CountryId = T00045_A8CountryId[0];
            AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            A19SellerPhoto = T00045_A19SellerPhoto[0];
            AssignAttri("", false, "A19SellerPhoto", A19SellerPhoto);
            AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40000SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
            AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
            ZM044( -9) ;
         }
         pr_default.close(3);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
         AV13Pgmname = "Seller";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable044( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "Seller";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A18SellerName)) )
         {
            GX_msglist.addItem("Their name cannot be empty", 1, "SELLERNAME");
            AnyError = 1;
            GX_FocusControl = edtSellerName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtCountryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9CountryName = T00044_A9CountryName[0];
         AssignAttri("", false, "A9CountryName", A9CountryName);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( short A8CountryId )
      {
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtCountryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9CountryName = T00046_A9CountryName[0];
         AssignAttri("", false, "A9CountryName", A9CountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A9CountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey044( )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A10SellerId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A10SellerId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 9) ;
            RcdFound4 = 1;
            A10SellerId = T00043_A10SellerId[0];
            AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
            A18SellerName = T00043_A18SellerName[0];
            AssignAttri("", false, "A18SellerName", A18SellerName);
            A40000SellerPhoto_GXI = T00043_A40000SellerPhoto_GXI[0];
            AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40000SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
            AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
            A8CountryId = T00043_A8CountryId[0];
            AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            A19SellerPhoto = T00043_A19SellerPhoto[0];
            AssignAttri("", false, "A19SellerPhoto", A19SellerPhoto);
            AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40000SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
            AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
            Z10SellerId = A10SellerId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound4 = 0;
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A10SellerId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00048_A10SellerId[0] < A10SellerId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00048_A10SellerId[0] > A10SellerId ) ) )
            {
               A10SellerId = T00048_A10SellerId[0];
               AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A10SellerId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00049_A10SellerId[0] > A10SellerId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00049_A10SellerId[0] < A10SellerId ) ) )
            {
               A10SellerId = T00049_A10SellerId[0];
               AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSellerName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert044( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A10SellerId != Z10SellerId )
               {
                  A10SellerId = Z10SellerId;
                  AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SELLERID");
                  AnyError = 1;
                  GX_FocusControl = edtSellerId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSellerName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update044( ) ;
                  GX_FocusControl = edtSellerName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A10SellerId != Z10SellerId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSellerName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert044( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SELLERID");
                     AnyError = 1;
                     GX_FocusControl = edtSellerId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSellerName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert044( ) ;
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
         if ( A10SellerId != Z10SellerId )
         {
            A10SellerId = Z10SellerId;
            AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SELLERID");
            AnyError = 1;
            GX_FocusControl = edtSellerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSellerName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A10SellerId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Seller"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z18SellerName, T00042_A18SellerName[0]) != 0 ) || ( Z8CountryId != T00042_A8CountryId[0] ) )
            {
               if ( StringUtil.StrCmp(Z18SellerName, T00042_A18SellerName[0]) != 0 )
               {
                  GXUtil.WriteLog("seller:[seudo value changed for attri]"+"SellerName");
                  GXUtil.WriteLogRaw("Old: ",Z18SellerName);
                  GXUtil.WriteLogRaw("Current: ",T00042_A18SellerName[0]);
               }
               if ( Z8CountryId != T00042_A8CountryId[0] )
               {
                  GXUtil.WriteLog("seller:[seudo value changed for attri]"+"CountryId");
                  GXUtil.WriteLogRaw("Old: ",Z8CountryId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A8CountryId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Seller"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000410 */
                     pr_default.execute(8, new Object[] {A18SellerName, A19SellerPhoto, A40000SellerPhoto_GXI, A8CountryId});
                     A10SellerId = T000410_A10SellerId[0];
                     AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Seller");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption040( ) ;
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000411 */
                     pr_default.execute(9, new Object[] {A18SellerName, A8CountryId, A10SellerId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Seller");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Seller"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000412 */
            pr_default.execute(10, new Object[] {A19SellerPhoto, A40000SellerPhoto_GXI, A10SellerId});
            pr_default.close(10);
            dsDefault.SmartCacheProvider.SetUpdated("Seller");
         }
      }

      protected void delete( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000413 */
                  pr_default.execute(11, new Object[] {A10SellerId});
                  pr_default.close(11);
                  dsDefault.SmartCacheProvider.SetUpdated("Seller");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel044( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Seller";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T000414 */
            pr_default.execute(12, new Object[] {A8CountryId});
            A9CountryName = T000414_A9CountryName[0];
            AssignAttri("", false, "A9CountryName", A9CountryName);
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000415 */
            pr_default.execute(13, new Object[] {A10SellerId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("seller",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("seller",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart044( )
      {
         /* Scan By routine */
         /* Using cursor T000416 */
         pr_default.execute(14);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound4 = 1;
            A10SellerId = T000416_A10SellerId[0];
            AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound4 = 1;
            A10SellerId = T000416_A10SellerId[0];
            AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
         }
      }

      protected void ScanEnd044( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
         edtSellerId_Enabled = 0;
         AssignProp("", false, edtSellerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSellerId_Enabled), 5, 0), true);
         edtSellerName_Enabled = 0;
         AssignProp("", false, edtSellerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSellerName_Enabled), 5, 0), true);
         imgSellerPhoto_Enabled = 0;
         AssignProp("", false, imgSellerPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgSellerPhoto_Enabled), 5, 0), true);
         edtCountryId_Enabled = 0;
         AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         edtCountryName_Enabled = 0;
         AssignProp("", false, edtCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
      {
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
         context.AddJavascriptSource("gxcfg.js", "?20235262002470", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seller.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7SellerId,4,0))}, new string[] {"Gx_mode","SellerId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Seller");
         forbiddenHiddens.Add("SellerId", context.localUtil.Format( (decimal)(A10SellerId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("seller:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z10SellerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10SellerId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z18SellerName", StringUtil.RTrim( Z18SellerName));
         GxWebStd.gx_hidden_field( context, "Z8CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8CountryId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N8CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vSELLERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SellerId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSELLERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SellerId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_COUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_CountryId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SELLERPHOTO_GXI", A40000SellerPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
         GXCCtlgxBlob = "SELLERPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A19SellerPhoto);
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
         return formatLink("seller.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7SellerId,4,0))}, new string[] {"Gx_mode","SellerId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Seller" ;
      }

      public override string GetPgmdesc( )
      {
         return "Vendedores" ;
      }

      protected void InitializeNonKey044( )
      {
         A8CountryId = 0;
         AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
         A18SellerName = "";
         AssignAttri("", false, "A18SellerName", A18SellerName);
         A19SellerPhoto = "";
         AssignAttri("", false, "A19SellerPhoto", A19SellerPhoto);
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40000SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
         A40000SellerPhoto_GXI = "";
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40000SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
         A9CountryName = "";
         AssignAttri("", false, "A9CountryName", A9CountryName);
         Z18SellerName = "";
         Z8CountryId = 0;
      }

      protected void InitAll044( )
      {
         A10SellerId = 0;
         AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20235262002487", true, true);
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
         context.AddJavascriptSource("seller.js", "?20235262002487", false, true);
         /* End function include_jscripts */
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
         edtSellerId_Internalname = "SELLERID";
         edtSellerName_Internalname = "SELLERNAME";
         imgSellerPhoto_Internalname = "SELLERPHOTO";
         edtCountryId_Internalname = "COUNTRYID";
         edtCountryName_Internalname = "COUNTRYNAME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_8_Internalname = "PROMPT_8";
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
         Form.Caption = "Vendedores";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCountryName_Jsonclick = "";
         edtCountryName_Enabled = 0;
         imgprompt_8_Visible = 1;
         imgprompt_8_Link = "";
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 1;
         imgSellerPhoto_Enabled = 1;
         edtSellerName_Jsonclick = "";
         edtSellerName_Enabled = 1;
         edtSellerId_Jsonclick = "";
         edtSellerId_Enabled = 0;
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

      public void Valid_Countryid( )
      {
         /* Using cursor T000414 */
         pr_default.execute(12, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtCountryId_Internalname;
         }
         A9CountryName = T000414_A9CountryName[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A9CountryName", StringUtil.RTrim( A9CountryName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7SellerId',fld:'vSELLERID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7SellerId',fld:'vSELLERID',pic:'ZZZ9',hsh:true},{av:'A10SellerId',fld:'SELLERID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12042',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_SELLERID","{handler:'Valid_Sellerid',iparms:[]");
         setEventMetadata("VALID_SELLERID",",oparms:[]}");
         setEventMetadata("VALID_SELLERNAME","{handler:'Valid_Sellername',iparms:[]");
         setEventMetadata("VALID_SELLERNAME",",oparms:[]}");
         setEventMetadata("VALID_COUNTRYID","{handler:'Valid_Countryid',iparms:[{av:'A8CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A9CountryName',fld:'COUNTRYNAME',pic:''}]");
         setEventMetadata("VALID_COUNTRYID",",oparms:[{av:'A9CountryName',fld:'COUNTRYNAME',pic:''}]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z18SellerName = "";
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
         A18SellerName = "";
         A19SellerPhoto = "";
         A40000SellerPhoto_GXI = "";
         sImgUrl = "";
         A9CountryName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode4 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z19SellerPhoto = "";
         Z40000SellerPhoto_GXI = "";
         Z9CountryName = "";
         T00044_A9CountryName = new string[] {""} ;
         T00045_A10SellerId = new short[1] ;
         T00045_A18SellerName = new string[] {""} ;
         T00045_A40000SellerPhoto_GXI = new string[] {""} ;
         T00045_A9CountryName = new string[] {""} ;
         T00045_A8CountryId = new short[1] ;
         T00045_A19SellerPhoto = new string[] {""} ;
         T00046_A9CountryName = new string[] {""} ;
         T00047_A10SellerId = new short[1] ;
         T00043_A10SellerId = new short[1] ;
         T00043_A18SellerName = new string[] {""} ;
         T00043_A40000SellerPhoto_GXI = new string[] {""} ;
         T00043_A8CountryId = new short[1] ;
         T00043_A19SellerPhoto = new string[] {""} ;
         T00048_A10SellerId = new short[1] ;
         T00049_A10SellerId = new short[1] ;
         T00042_A10SellerId = new short[1] ;
         T00042_A18SellerName = new string[] {""} ;
         T00042_A40000SellerPhoto_GXI = new string[] {""} ;
         T00042_A8CountryId = new short[1] ;
         T00042_A19SellerPhoto = new string[] {""} ;
         T000410_A10SellerId = new short[1] ;
         T000414_A9CountryName = new string[] {""} ;
         T000415_A12ProductId = new short[1] ;
         T000416_A10SellerId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seller__default(),
            new Object[][] {
                new Object[] {
               T00042_A10SellerId, T00042_A18SellerName, T00042_A40000SellerPhoto_GXI, T00042_A8CountryId, T00042_A19SellerPhoto
               }
               , new Object[] {
               T00043_A10SellerId, T00043_A18SellerName, T00043_A40000SellerPhoto_GXI, T00043_A8CountryId, T00043_A19SellerPhoto
               }
               , new Object[] {
               T00044_A9CountryName
               }
               , new Object[] {
               T00045_A10SellerId, T00045_A18SellerName, T00045_A40000SellerPhoto_GXI, T00045_A9CountryName, T00045_A8CountryId, T00045_A19SellerPhoto
               }
               , new Object[] {
               T00046_A9CountryName
               }
               , new Object[] {
               T00047_A10SellerId
               }
               , new Object[] {
               T00048_A10SellerId
               }
               , new Object[] {
               T00049_A10SellerId
               }
               , new Object[] {
               T000410_A10SellerId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000414_A9CountryName
               }
               , new Object[] {
               T000415_A12ProductId
               }
               , new Object[] {
               T000416_A10SellerId
               }
            }
         );
         AV13Pgmname = "Seller";
      }

      private short wcpOAV7SellerId ;
      private short Z10SellerId ;
      private short Z8CountryId ;
      private short N8CountryId ;
      private short GxWebError ;
      private short A8CountryId ;
      private short AV7SellerId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A10SellerId ;
      private short AV11Insert_CountryId ;
      private short RcdFound4 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_4 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSellerId_Enabled ;
      private int edtSellerName_Enabled ;
      private int imgSellerPhoto_Enabled ;
      private int edtCountryId_Enabled ;
      private int imgprompt_8_Visible ;
      private int edtCountryName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV14GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z18SellerName ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSellerName_Internalname ;
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
      private string edtSellerId_Internalname ;
      private string edtSellerId_Jsonclick ;
      private string A18SellerName ;
      private string edtSellerName_Jsonclick ;
      private string imgSellerPhoto_Internalname ;
      private string sImgUrl ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string imgprompt_8_Internalname ;
      private string imgprompt_8_Link ;
      private string edtCountryName_Internalname ;
      private string A9CountryName ;
      private string edtCountryName_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode4 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z9CountryName ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A19SellerPhoto_IsBlob ;
      private bool returnInSub ;
      private string A40000SellerPhoto_GXI ;
      private string Z40000SellerPhoto_GXI ;
      private string A19SellerPhoto ;
      private string Z19SellerPhoto ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00044_A9CountryName ;
      private short[] T00045_A10SellerId ;
      private string[] T00045_A18SellerName ;
      private string[] T00045_A40000SellerPhoto_GXI ;
      private string[] T00045_A9CountryName ;
      private short[] T00045_A8CountryId ;
      private string[] T00045_A19SellerPhoto ;
      private string[] T00046_A9CountryName ;
      private short[] T00047_A10SellerId ;
      private short[] T00043_A10SellerId ;
      private string[] T00043_A18SellerName ;
      private string[] T00043_A40000SellerPhoto_GXI ;
      private short[] T00043_A8CountryId ;
      private string[] T00043_A19SellerPhoto ;
      private short[] T00048_A10SellerId ;
      private short[] T00049_A10SellerId ;
      private short[] T00042_A10SellerId ;
      private string[] T00042_A18SellerName ;
      private string[] T00042_A40000SellerPhoto_GXI ;
      private short[] T00042_A8CountryId ;
      private string[] T00042_A19SellerPhoto ;
      private short[] T000410_A10SellerId ;
      private string[] T000414_A9CountryName ;
      private short[] T000415_A12ProductId ;
      private short[] T000416_A10SellerId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class seller__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00045;
          prmT00045 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT00044;
          prmT00044 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT00046;
          prmT00046 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT00047;
          prmT00047 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT00043;
          prmT00043 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT00048;
          prmT00048 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT00049;
          prmT00049 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT00042;
          prmT00042 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT000410;
          prmT000410 = new Object[] {
          new ParDef("@SellerName",GXType.NChar,20,0) ,
          new ParDef("@SellerPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@SellerPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Seller", Fld="SellerPhoto"} ,
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000411;
          prmT000411 = new Object[] {
          new ParDef("@SellerName",GXType.NChar,20,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT000412;
          prmT000412 = new Object[] {
          new ParDef("@SellerPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@SellerPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Seller", Fld="SellerPhoto"} ,
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT000413;
          prmT000413 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT000415;
          prmT000415 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT000416;
          prmT000416 = new Object[] {
          };
          Object[] prmT000414;
          prmT000414 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [SellerId], [SellerName], [SellerPhoto_GXI], [CountryId], [SellerPhoto] FROM [Seller] WITH (UPDLOCK) WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00043", "SELECT [SellerId], [SellerName], [SellerPhoto_GXI], [CountryId], [SellerPhoto] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00044", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00045", "SELECT TM1.[SellerId], TM1.[SellerName], TM1.[SellerPhoto_GXI], T2.[CountryName], TM1.[CountryId], TM1.[SellerPhoto] FROM ([Seller] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[CountryId]) WHERE TM1.[SellerId] = @SellerId ORDER BY TM1.[SellerId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00046", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00047", "SELECT [SellerId] FROM [Seller] WHERE [SellerId] = @SellerId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00048", "SELECT TOP 1 [SellerId] FROM [Seller] WHERE ( [SellerId] > @SellerId) ORDER BY [SellerId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00049", "SELECT TOP 1 [SellerId] FROM [Seller] WHERE ( [SellerId] < @SellerId) ORDER BY [SellerId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000410", "INSERT INTO [Seller]([SellerName], [SellerPhoto], [SellerPhoto_GXI], [CountryId]) VALUES(@SellerName, @SellerPhoto, @SellerPhoto_GXI, @CountryId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000410)
             ,new CursorDef("T000411", "UPDATE [Seller] SET [SellerName]=@SellerName, [CountryId]=@CountryId  WHERE [SellerId] = @SellerId", GxErrorMask.GX_NOMASK,prmT000411)
             ,new CursorDef("T000412", "UPDATE [Seller] SET [SellerPhoto]=@SellerPhoto, [SellerPhoto_GXI]=@SellerPhoto_GXI  WHERE [SellerId] = @SellerId", GxErrorMask.GX_NOMASK,prmT000412)
             ,new CursorDef("T000413", "DELETE FROM [Seller]  WHERE [SellerId] = @SellerId", GxErrorMask.GX_NOMASK,prmT000413)
             ,new CursorDef("T000414", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000414,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000415", "SELECT TOP 1 [ProductId] FROM [Product] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000416", "SELECT [SellerId] FROM [Seller] ORDER BY [SellerId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(3));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
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
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
