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
   public class shoppingcart : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A16ShoppingCartId = (short)(NumberUtil.Val( GetPar( "ShoppingCartId"), "."));
            AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A16ShoppingCartId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A11CustomerId = (short)(NumberUtil.Val( GetPar( "CustomerId"), "."));
            AssignAttri("", false, "A11CustomerId", StringUtil.LTrimStr( (decimal)(A11CustomerId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A11CustomerId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A8CountryId = (short)(NumberUtil.Val( GetPar( "CountryId"), "."));
            AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A8CountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A12ProductId = (short)(NumberUtil.Val( GetPar( "ProductId"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A12ProductId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A6CategoryId = (short)(NumberUtil.Val( GetPar( "CategoryId"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A6CategoryId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridshoppingcart_product") == 0 )
         {
            nRC_GXsfl_88 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_88"), "."));
            nGXsfl_88_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_88_idx"), "."));
            sGXsfl_88_idx = GetPar( "sGXsfl_88_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridshoppingcart_product_newrow( ) ;
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
               AV9ShoppingCartId = (short)(NumberUtil.Val( GetPar( "ShoppingCartId"), "."));
               AssignAttri("", false, "AV9ShoppingCartId", StringUtil.LTrimStr( (decimal)(AV9ShoppingCartId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSHOPPINGCARTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9ShoppingCartId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Carrinho de Compras", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public shoppingcart( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public shoppingcart( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ShoppingCartId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV9ShoppingCartId = aP1_ShoppingCartId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Carrinho de Compras", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ShoppingCart.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ShoppingCart.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtShoppingCartId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShoppingCartId_Internalname, "Cart Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtShoppingCartId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16ShoppingCartId), 4, 0, ",", "")), StringUtil.LTrim( ((edtShoppingCartId_Enabled!=0) ? context.localUtil.Format( (decimal)(A16ShoppingCartId), "ZZZ9") : context.localUtil.Format( (decimal)(A16ShoppingCartId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShoppingCartId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtShoppingCartDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShoppingCartDate_Internalname, "Cart Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtShoppingCartDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtShoppingCartDate_Internalname, context.localUtil.Format(A33ShoppingCartDate, "99/99/99"), context.localUtil.Format( A33ShoppingCartDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShoppingCartDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_bitmap( context, edtShoppingCartDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtShoppingCartDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ShoppingCart.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtShoppingCartDateDelivery_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShoppingCartDateDelivery_Internalname, "Date Delivery", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtShoppingCartDateDelivery_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtShoppingCartDateDelivery_Internalname, context.localUtil.Format(A38ShoppingCartDateDelivery, "99/99/99"), context.localUtil.Format( A38ShoppingCartDateDelivery, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartDateDelivery_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShoppingCartDateDelivery_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_bitmap( context, edtShoppingCartDateDelivery_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtShoppingCartDateDelivery_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ShoppingCart.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCustomerId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerId_Internalname, "Cliente Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11CustomerId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A11CustomerId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ShoppingCart.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_11_Internalname, sImgUrl, imgprompt_11_Link, "", "", context.GetTheme( ), imgprompt_11_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCustomerName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerName_Internalname, "Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCustomerName_Internalname, StringUtil.RTrim( A20CustomerName), StringUtil.RTrim( context.localUtil.Format( A20CustomerName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ShoppingCart.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ",", "")), StringUtil.LTrim( ((edtCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A8CountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A8CountryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ShoppingCart.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, StringUtil.RTrim( A9CountryName), StringUtil.RTrim( context.localUtil.Format( A9CountryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCustomerAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerAddress_Internalname, "Endereço", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCustomerAddress_Internalname, A21CustomerAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A21CustomerAddress), "", 0, 1, edtCustomerAddress_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCustomerPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerPhone_Internalname, "Telefone", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A23CustomerPhone);
         }
         GxWebStd.gx_single_line_edit( context, edtCustomerPhone_Internalname, StringUtil.RTrim( A23CustomerPhone), StringUtil.RTrim( context.localUtil.Format( A23CustomerPhone, "(99) 9999-9999")), "", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCustomerPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtShoppingCartFinalPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShoppingCartFinalPrice_Internalname, "Final Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtShoppingCartFinalPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A34ShoppingCartFinalPrice, 13, 2, ",", "")), StringUtil.LTrim( ((edtShoppingCartFinalPrice_Enabled!=0) ? context.localUtil.Format( A34ShoppingCartFinalPrice, "R$ ZZZZZZ9.99") : context.localUtil.Format( A34ShoppingCartFinalPrice, "R$ ZZZZZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartFinalPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShoppingCartFinalPrice_Enabled, 0, "text", "", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ShoppingCart.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTitleproduct_Internalname, "Product", "", "", lblTitleproduct_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridshoppingcart_product( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ShoppingCart.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridshoppingcart_product( )
      {
         /*  Grid Control  */
         Gridshoppingcart_productContainer.AddObjectProperty("GridName", "Gridshoppingcart_product");
         Gridshoppingcart_productContainer.AddObjectProperty("Header", subGridshoppingcart_product_Header);
         Gridshoppingcart_productContainer.AddObjectProperty("Class", "Grid");
         Gridshoppingcart_productContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Backcolorstyle), 1, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("CmpContext", "");
         Gridshoppingcart_productContainer.AddObjectProperty("InMasterPage", "false");
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ".", "")));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.RTrim( A13ProductName));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 11, 2, ".", "")));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A36QtyProduct), 4, 0, ".", "")));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtQtyProduct_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A35TotalProduct, 11, 2, ".", "")));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTotalProduct_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CategoryId), 4, 0, ".", "")));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryId_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridshoppingcart_productColumn.AddObjectProperty("Value", StringUtil.RTrim( A7CategoryName));
         Gridshoppingcart_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", "")));
         Gridshoppingcart_productContainer.AddColumnProperties(Gridshoppingcart_productColumn);
         Gridshoppingcart_productContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Selectedindex), 4, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Allowselection), 1, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Selectioncolor), 9, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Allowhovering), 1, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Hoveringcolor), 9, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Allowcollapsing), 1, 0, ".", "")));
         Gridshoppingcart_productContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridshoppingcart_product_Collapsed), 1, 0, ".", "")));
         nGXsfl_88_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount10 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_10 = 1;
               ScanStart0610( ) ;
               while ( RcdFound10 != 0 )
               {
                  init_level_properties10( ) ;
                  getByPrimaryKey0610( ) ;
                  AddRow0610( ) ;
                  ScanNext0610( ) ;
               }
               ScanEnd0610( ) ;
               nBlankRcdCount10 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            standaloneNotModal0610( ) ;
            standaloneModal0610( ) ;
            sMode10 = Gx_mode;
            while ( nGXsfl_88_idx < nRC_GXsfl_88 )
            {
               bGXsfl_88_Refreshing = true;
               ReadRow0610( ) ;
               edtProductId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProductName_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProductPrice_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTPRICE_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtQtyProduct_Enabled = (int)(context.localUtil.CToN( cgiGet( "QTYPRODUCT_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtQtyProduct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtQtyProduct_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtTotalProduct_Enabled = (int)(context.localUtil.CToN( cgiGet( "TOTALPRODUCT_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtTotalProduct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotalProduct_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtCategoryId_Enabled = (int)(context.localUtil.CToN( cgiGet( "CATEGORYID_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtCategoryName_Enabled = (int)(context.localUtil.CToN( cgiGet( "CATEGORYNAME_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               imgprompt_11_Link = cgiGet( "PROMPT_12_"+sGXsfl_88_idx+"Link");
               if ( ( nRcdExists_10 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0610( ) ;
               }
               SendRow0610( ) ;
               bGXsfl_88_Refreshing = false;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A34ShoppingCartFinalPrice = B34ShoppingCartFinalPrice;
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount10 = 5;
            nRcdExists_10 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0610( ) ;
               while ( RcdFound10 != 0 )
               {
                  sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8810( ) ;
                  init_level_properties10( ) ;
                  standaloneNotModal0610( ) ;
                  getByPrimaryKey0610( ) ;
                  standaloneModal0610( ) ;
                  AddRow0610( ) ;
                  ScanNext0610( ) ;
               }
               ScanEnd0610( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode10 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8810( ) ;
            InitAll0610( ) ;
            init_level_properties10( ) ;
            B34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            nRcdExists_10 = 0;
            nIsMod_10 = 0;
            nRcdDeleted_10 = 0;
            nBlankRcdCount10 = (short)(nBlankRcdUsr10+nBlankRcdCount10);
            fRowAdded = 0;
            while ( nBlankRcdCount10 > 0 )
            {
               standaloneNotModal0610( ) ;
               standaloneModal0610( ) ;
               AddRow0610( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount10 = (short)(nBlankRcdCount10-1);
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A34ShoppingCartFinalPrice = B34ShoppingCartFinalPrice;
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridshoppingcart_productContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridshoppingcart_product", Gridshoppingcart_productContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridshoppingcart_productContainerData", Gridshoppingcart_productContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridshoppingcart_productContainerData"+"V", Gridshoppingcart_productContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridshoppingcart_productContainerData"+"V"+"\" value='"+Gridshoppingcart_productContainer.GridValuesHidden()+"'/>") ;
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
         E11062 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z16ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( "Z16ShoppingCartId"), ",", "."));
               Z33ShoppingCartDate = context.localUtil.CToD( cgiGet( "Z33ShoppingCartDate"), 0);
               Z11CustomerId = (short)(context.localUtil.CToN( cgiGet( "Z11CustomerId"), ",", "."));
               O34ShoppingCartFinalPrice = context.localUtil.CToN( cgiGet( "O34ShoppingCartFinalPrice"), ",", ".");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_88 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_88"), ",", "."));
               N11CustomerId = (short)(context.localUtil.CToN( cgiGet( "N11CustomerId"), ",", "."));
               AV9ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( "vSHOPPINGCARTID"), ",", "."));
               AV7Insert_CustomerId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_CUSTOMERID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A16ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( edtShoppingCartId_Internalname), ",", "."));
               AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
               if ( context.localUtil.VCDate( cgiGet( edtShoppingCartDate_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Shopping Cart Date"}), 1, "SHOPPINGCARTDATE");
                  AnyError = 1;
                  GX_FocusControl = edtShoppingCartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A33ShoppingCartDate = DateTime.MinValue;
                  AssignAttri("", false, "A33ShoppingCartDate", context.localUtil.Format(A33ShoppingCartDate, "99/99/99"));
               }
               else
               {
                  A33ShoppingCartDate = context.localUtil.CToD( cgiGet( edtShoppingCartDate_Internalname), 2);
                  AssignAttri("", false, "A33ShoppingCartDate", context.localUtil.Format(A33ShoppingCartDate, "99/99/99"));
               }
               A38ShoppingCartDateDelivery = context.localUtil.CToD( cgiGet( edtShoppingCartDateDelivery_Internalname), 2);
               AssignAttri("", false, "A38ShoppingCartDateDelivery", context.localUtil.Format(A38ShoppingCartDateDelivery, "99/99/99"));
               if ( ( ( context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUSTOMERID");
                  AnyError = 1;
                  GX_FocusControl = edtCustomerId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A11CustomerId = 0;
                  AssignAttri("", false, "A11CustomerId", StringUtil.LTrimStr( (decimal)(A11CustomerId), 4, 0));
               }
               else
               {
                  A11CustomerId = (short)(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ",", "."));
                  AssignAttri("", false, "A11CustomerId", StringUtil.LTrimStr( (decimal)(A11CustomerId), 4, 0));
               }
               A20CustomerName = cgiGet( edtCustomerName_Internalname);
               AssignAttri("", false, "A20CustomerName", A20CustomerName);
               A8CountryId = (short)(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ",", "."));
               AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
               A9CountryName = cgiGet( edtCountryName_Internalname);
               AssignAttri("", false, "A9CountryName", A9CountryName);
               A21CustomerAddress = cgiGet( edtCustomerAddress_Internalname);
               AssignAttri("", false, "A21CustomerAddress", A21CustomerAddress);
               A23CustomerPhone = cgiGet( edtCustomerPhone_Internalname);
               AssignAttri("", false, "A23CustomerPhone", A23CustomerPhone);
               A34ShoppingCartFinalPrice = context.localUtil.CToN( cgiGet( edtShoppingCartFinalPrice_Internalname), ",", ".");
               n34ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ShoppingCart");
               A16ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( edtShoppingCartId_Internalname), ",", "."));
               AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
               forbiddenHiddens.Add("ShoppingCartId", context.localUtil.Format( (decimal)(A16ShoppingCartId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A16ShoppingCartId != Z16ShoppingCartId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("shoppingcart:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A16ShoppingCartId = (short)(NumberUtil.Val( GetPar( "ShoppingCartId"), "."));
                  AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
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
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode9;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SHOPPINGCARTID");
                        AnyError = 1;
                        GX_FocusControl = edtShoppingCartId_Internalname;
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
                           E11062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12062 ();
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
            E12062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll069( ) ;
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
            DisableAttributes069( ) ;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls069( ) ;
            }
            else
            {
               CheckExtendedTable069( ) ;
               CloseExtendedTableCursors069( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode9 = Gx_mode;
            CONFIRM_0610( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode9;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0610( )
      {
         s34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
         n34ShoppingCartFinalPrice = false;
         AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow0610( ) ;
            if ( ( nRcdExists_10 != 0 ) || ( nIsMod_10 != 0 ) )
            {
               GetKey0610( ) ;
               if ( ( nRcdExists_10 == 0 ) && ( nRcdDeleted_10 == 0 ) )
               {
                  if ( RcdFound10 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0610( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0610( ) ;
                        CloseExtendedTableCursors0610( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
                        n34ShoppingCartFinalPrice = false;
                        AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTID_" + sGXsfl_88_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound10 != 0 )
                  {
                     if ( nRcdDeleted_10 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0610( ) ;
                        Load0610( ) ;
                        BeforeValidate0610( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0610( ) ;
                           O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
                           n34ShoppingCartFinalPrice = false;
                           AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
                        }
                     }
                     else
                     {
                        if ( nIsMod_10 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0610( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0610( ) ;
                              CloseExtendedTableCursors0610( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
                              n34ShoppingCartFinalPrice = false;
                              AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_10 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_88_idx;
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
            ChangePostValue( edtQtyProduct_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A36QtyProduct), 4, 0, ",", ""))) ;
            ChangePostValue( edtTotalProduct_Internalname, StringUtil.LTrim( StringUtil.NToC( A35TotalProduct, 11, 2, ",", ""))) ;
            ChangePostValue( edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CategoryId), 4, 0, ",", ""))) ;
            ChangePostValue( edtCategoryName_Internalname, StringUtil.RTrim( A7CategoryName)) ;
            ChangePostValue( "ZT_"+"Z12ProductId_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z36QtyProduct_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z36QtyProduct), 4, 0, ",", ""))) ;
            ChangePostValue( "T35TotalProduct_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( O35TotalProduct, 8, 2, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_10_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_10), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_10_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_10), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_10_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_10), 4, 0, ",", ""))) ;
            if ( nIsMod_10 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTPRICE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "QTYPRODUCT_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtQtyProduct_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TOTALPRODUCT_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTotalProduct_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYNAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O34ShoppingCartFinalPrice = s34ShoppingCartFinalPrice;
         n34ShoppingCartFinalPrice = false;
         AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV10TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         AV7Insert_CustomerId = 0;
         AssignAttri("", false, "AV7Insert_CustomerId", StringUtil.LTrimStr( (decimal)(AV7Insert_CustomerId), 4, 0));
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV11TrnContextAtt = ((SdtTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "CustomerId") == 0 )
               {
                  AV7Insert_CustomerId = (short)(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV7Insert_CustomerId", StringUtil.LTrimStr( (decimal)(AV7Insert_CustomerId), 4, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
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

      protected void E12062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.PopUp(formatLink("ashoppingcartdetail.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A16ShoppingCartId,4,0))}, new string[] {"ShoppingCartId"}) , new Object[] {"A16ShoppingCartId"});
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwshoppingcart.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM069( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z33ShoppingCartDate = T00067_A33ShoppingCartDate[0];
               Z11CustomerId = T00067_A11CustomerId[0];
            }
            else
            {
               Z33ShoppingCartDate = A33ShoppingCartDate;
               Z11CustomerId = A11CustomerId;
            }
         }
         if ( GX_JID == -14 )
         {
            Z16ShoppingCartId = A16ShoppingCartId;
            Z33ShoppingCartDate = A33ShoppingCartDate;
            Z11CustomerId = A11CustomerId;
            Z34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
            Z20CustomerName = A20CustomerName;
            Z21CustomerAddress = A21CustomerAddress;
            Z23CustomerPhone = A23CustomerPhone;
            Z8CountryId = A8CountryId;
            Z9CountryName = A9CountryName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtShoppingCartId_Enabled = 0;
         AssignProp("", false, edtShoppingCartId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_11_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CUSTOMERID"+"'), id:'"+"CUSTOMERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtShoppingCartId_Enabled = 0;
         AssignProp("", false, edtShoppingCartId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV9ShoppingCartId) )
         {
            A16ShoppingCartId = AV9ShoppingCartId;
            AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV7Insert_CustomerId) )
         {
            edtCustomerId_Enabled = 0;
            AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         }
         else
         {
            edtCustomerId_Enabled = 1;
            AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV7Insert_CustomerId) )
         {
            A11CustomerId = AV7Insert_CustomerId;
            AssignAttri("", false, "A11CustomerId", StringUtil.LTrimStr( (decimal)(A11CustomerId), 4, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A33ShoppingCartDate) && ( Gx_BScreen == 0 ) )
         {
            A33ShoppingCartDate = DateTimeUtil.Today( context);
            AssignAttri("", false, "A33ShoppingCartDate", context.localUtil.Format(A33ShoppingCartDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000611 */
            pr_default.execute(8, new Object[] {A16ShoppingCartId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               A34ShoppingCartFinalPrice = T000611_A34ShoppingCartFinalPrice[0];
               n34ShoppingCartFinalPrice = T000611_n34ShoppingCartFinalPrice[0];
               AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            }
            else
            {
               A34ShoppingCartFinalPrice = 0;
               n34ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            }
            O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            pr_default.close(8);
            AV14Pgmname = "ShoppingCart";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T00068 */
            pr_default.execute(6, new Object[] {A11CustomerId});
            A20CustomerName = T00068_A20CustomerName[0];
            AssignAttri("", false, "A20CustomerName", A20CustomerName);
            A21CustomerAddress = T00068_A21CustomerAddress[0];
            AssignAttri("", false, "A21CustomerAddress", A21CustomerAddress);
            A23CustomerPhone = T00068_A23CustomerPhone[0];
            AssignAttri("", false, "A23CustomerPhone", A23CustomerPhone);
            A8CountryId = T00068_A8CountryId[0];
            AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            pr_default.close(6);
            /* Using cursor T00069 */
            pr_default.execute(7, new Object[] {A8CountryId});
            A9CountryName = T00069_A9CountryName[0];
            AssignAttri("", false, "A9CountryName", A9CountryName);
            pr_default.close(7);
            A38ShoppingCartDateDelivery = DateTimeUtil.DAdd(A33ShoppingCartDate,+((int)(5)));
            AssignAttri("", false, "A38ShoppingCartDateDelivery", context.localUtil.Format(A38ShoppingCartDateDelivery, "99/99/99"));
         }
      }

      protected void Load069( )
      {
         /* Using cursor T000613 */
         pr_default.execute(9, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound9 = 1;
            A33ShoppingCartDate = T000613_A33ShoppingCartDate[0];
            AssignAttri("", false, "A33ShoppingCartDate", context.localUtil.Format(A33ShoppingCartDate, "99/99/99"));
            A20CustomerName = T000613_A20CustomerName[0];
            AssignAttri("", false, "A20CustomerName", A20CustomerName);
            A9CountryName = T000613_A9CountryName[0];
            AssignAttri("", false, "A9CountryName", A9CountryName);
            A21CustomerAddress = T000613_A21CustomerAddress[0];
            AssignAttri("", false, "A21CustomerAddress", A21CustomerAddress);
            A23CustomerPhone = T000613_A23CustomerPhone[0];
            AssignAttri("", false, "A23CustomerPhone", A23CustomerPhone);
            A11CustomerId = T000613_A11CustomerId[0];
            AssignAttri("", false, "A11CustomerId", StringUtil.LTrimStr( (decimal)(A11CustomerId), 4, 0));
            A8CountryId = T000613_A8CountryId[0];
            AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            A34ShoppingCartFinalPrice = T000613_A34ShoppingCartFinalPrice[0];
            n34ShoppingCartFinalPrice = T000613_n34ShoppingCartFinalPrice[0];
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            ZM069( -14) ;
         }
         pr_default.close(9);
         OnLoadActions069( ) ;
      }

      protected void OnLoadActions069( )
      {
         O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
         n34ShoppingCartFinalPrice = false;
         AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         AV14Pgmname = "ShoppingCart";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         A38ShoppingCartDateDelivery = DateTimeUtil.DAdd(A33ShoppingCartDate,+((int)(5)));
         AssignAttri("", false, "A38ShoppingCartDateDelivery", context.localUtil.Format(A38ShoppingCartDateDelivery, "99/99/99"));
      }

      protected void CheckExtendedTable069( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV14Pgmname = "ShoppingCart";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         /* Using cursor T000611 */
         pr_default.execute(8, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A34ShoppingCartFinalPrice = T000611_A34ShoppingCartFinalPrice[0];
            n34ShoppingCartFinalPrice = T000611_n34ShoppingCartFinalPrice[0];
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         }
         else
         {
            nIsDirty_9 = 1;
            A34ShoppingCartFinalPrice = 0;
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         }
         pr_default.close(8);
         if ( ! ( (DateTime.MinValue==A33ShoppingCartDate) || ( DateTimeUtil.ResetTime ( A33ShoppingCartDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Shopping Cart Date fora do intervalo", "OutOfRange", 1, "SHOPPINGCARTDATE");
            AnyError = 1;
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         nIsDirty_9 = 1;
         A38ShoppingCartDateDelivery = DateTimeUtil.DAdd(A33ShoppingCartDate,+((int)(5)));
         AssignAttri("", false, "A38ShoppingCartDateDelivery", context.localUtil.Format(A38ShoppingCartDateDelivery, "99/99/99"));
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A11CustomerId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A20CustomerName = T00068_A20CustomerName[0];
         AssignAttri("", false, "A20CustomerName", A20CustomerName);
         A21CustomerAddress = T00068_A21CustomerAddress[0];
         AssignAttri("", false, "A21CustomerAddress", A21CustomerAddress);
         A23CustomerPhone = T00068_A23CustomerPhone[0];
         AssignAttri("", false, "A23CustomerPhone", A23CustomerPhone);
         A8CountryId = T00068_A8CountryId[0];
         AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
         pr_default.close(6);
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A9CountryName = T00069_A9CountryName[0];
         AssignAttri("", false, "A9CountryName", A9CountryName);
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors069( )
      {
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( short A16ShoppingCartId )
      {
         /* Using cursor T000615 */
         pr_default.execute(10, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A34ShoppingCartFinalPrice = T000615_A34ShoppingCartFinalPrice[0];
            n34ShoppingCartFinalPrice = T000615_n34ShoppingCartFinalPrice[0];
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         }
         else
         {
            A34ShoppingCartFinalPrice = 0;
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A34ShoppingCartFinalPrice, 10, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_15( short A11CustomerId )
      {
         /* Using cursor T000616 */
         pr_default.execute(11, new Object[] {A11CustomerId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("Não existe 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A20CustomerName = T000616_A20CustomerName[0];
         AssignAttri("", false, "A20CustomerName", A20CustomerName);
         A21CustomerAddress = T000616_A21CustomerAddress[0];
         AssignAttri("", false, "A21CustomerAddress", A21CustomerAddress);
         A23CustomerPhone = T000616_A23CustomerPhone[0];
         AssignAttri("", false, "A23CustomerPhone", A23CustomerPhone);
         A8CountryId = T000616_A8CountryId[0];
         AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A20CustomerName))+"\""+","+"\""+GXUtil.EncodeJSConstant( A21CustomerAddress)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A23CustomerPhone))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_16( short A8CountryId )
      {
         /* Using cursor T000617 */
         pr_default.execute(12, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A9CountryName = T000617_A9CountryName[0];
         AssignAttri("", false, "A9CountryName", A9CountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A9CountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey069( )
      {
         /* Using cursor T000618 */
         pr_default.execute(13, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM069( 14) ;
            RcdFound9 = 1;
            A16ShoppingCartId = T00067_A16ShoppingCartId[0];
            AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
            A33ShoppingCartDate = T00067_A33ShoppingCartDate[0];
            AssignAttri("", false, "A33ShoppingCartDate", context.localUtil.Format(A33ShoppingCartDate, "99/99/99"));
            A11CustomerId = T00067_A11CustomerId[0];
            AssignAttri("", false, "A11CustomerId", StringUtil.LTrimStr( (decimal)(A11CustomerId), 4, 0));
            Z16ShoppingCartId = A16ShoppingCartId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load069( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey069( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey069( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey069( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T000619 */
         pr_default.execute(14, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000619_A16ShoppingCartId[0] < A16ShoppingCartId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000619_A16ShoppingCartId[0] > A16ShoppingCartId ) ) )
            {
               A16ShoppingCartId = T000619_A16ShoppingCartId[0];
               AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000620 */
         pr_default.execute(15, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T000620_A16ShoppingCartId[0] > A16ShoppingCartId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T000620_A16ShoppingCartId[0] < A16ShoppingCartId ) ) )
            {
               A16ShoppingCartId = T000620_A16ShoppingCartId[0];
               AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey069( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert069( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A16ShoppingCartId != Z16ShoppingCartId )
               {
                  A16ShoppingCartId = Z16ShoppingCartId;
                  AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SHOPPINGCARTID");
                  AnyError = 1;
                  GX_FocusControl = edtShoppingCartId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
                  n34ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtShoppingCartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
                  n34ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
                  Update069( ) ;
                  GX_FocusControl = edtShoppingCartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A16ShoppingCartId != Z16ShoppingCartId )
               {
                  /* Insert record */
                  A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
                  n34ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
                  GX_FocusControl = edtShoppingCartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert069( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SHOPPINGCARTID");
                     AnyError = 1;
                     GX_FocusControl = edtShoppingCartId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
                     n34ShoppingCartFinalPrice = false;
                     AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
                     GX_FocusControl = edtShoppingCartDate_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert069( ) ;
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
         if ( A16ShoppingCartId != Z16ShoppingCartId )
         {
            A16ShoppingCartId = Z16ShoppingCartId;
            AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SHOPPINGCARTID");
            AnyError = 1;
            GX_FocusControl = edtShoppingCartId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency069( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00066 */
            pr_default.execute(4, new Object[] {A16ShoppingCartId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCart"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( DateTimeUtil.ResetTime ( Z33ShoppingCartDate ) != DateTimeUtil.ResetTime ( T00066_A33ShoppingCartDate[0] ) ) || ( Z11CustomerId != T00066_A11CustomerId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z33ShoppingCartDate ) != DateTimeUtil.ResetTime ( T00066_A33ShoppingCartDate[0] ) )
               {
                  GXUtil.WriteLog("shoppingcart:[seudo value changed for attri]"+"ShoppingCartDate");
                  GXUtil.WriteLogRaw("Old: ",Z33ShoppingCartDate);
                  GXUtil.WriteLogRaw("Current: ",T00066_A33ShoppingCartDate[0]);
               }
               if ( Z11CustomerId != T00066_A11CustomerId[0] )
               {
                  GXUtil.WriteLog("shoppingcart:[seudo value changed for attri]"+"CustomerId");
                  GXUtil.WriteLogRaw("Old: ",Z11CustomerId);
                  GXUtil.WriteLogRaw("Current: ",T00066_A11CustomerId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ShoppingCart"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert069( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM069( 0) ;
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000621 */
                     pr_default.execute(16, new Object[] {A33ShoppingCartDate, A11CustomerId});
                     A16ShoppingCartId = T000621_A16ShoppingCartId[0];
                     AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel069( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption060( ) ;
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
               Load069( ) ;
            }
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void Update069( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000622 */
                     pr_default.execute(17, new Object[] {A33ShoppingCartDate, A11CustomerId, A16ShoppingCartId});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCart");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCart"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate069( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel069( ) ;
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
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void DeferredUpdate069( )
      {
      }

      protected void delete( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls069( ) ;
            AfterConfirm069( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete069( ) ;
               if ( AnyError == 0 )
               {
                  A34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
                  n34ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
                  ScanStart0610( ) ;
                  while ( RcdFound10 != 0 )
                  {
                     getByPrimaryKey0610( ) ;
                     Delete0610( ) ;
                     ScanNext0610( ) ;
                     O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
                     n34ShoppingCartFinalPrice = false;
                     AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
                  }
                  ScanEnd0610( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000623 */
                     pr_default.execute(18, new Object[] {A16ShoppingCartId});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCart");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel069( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls069( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "ShoppingCart";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000625 */
            pr_default.execute(19, new Object[] {A16ShoppingCartId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A34ShoppingCartFinalPrice = T000625_A34ShoppingCartFinalPrice[0];
               n34ShoppingCartFinalPrice = T000625_n34ShoppingCartFinalPrice[0];
               AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            }
            else
            {
               A34ShoppingCartFinalPrice = 0;
               n34ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            }
            pr_default.close(19);
            A38ShoppingCartDateDelivery = DateTimeUtil.DAdd(A33ShoppingCartDate,+((int)(5)));
            AssignAttri("", false, "A38ShoppingCartDateDelivery", context.localUtil.Format(A38ShoppingCartDateDelivery, "99/99/99"));
            /* Using cursor T000626 */
            pr_default.execute(20, new Object[] {A11CustomerId});
            A20CustomerName = T000626_A20CustomerName[0];
            AssignAttri("", false, "A20CustomerName", A20CustomerName);
            A21CustomerAddress = T000626_A21CustomerAddress[0];
            AssignAttri("", false, "A21CustomerAddress", A21CustomerAddress);
            A23CustomerPhone = T000626_A23CustomerPhone[0];
            AssignAttri("", false, "A23CustomerPhone", A23CustomerPhone);
            A8CountryId = T000626_A8CountryId[0];
            AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            pr_default.close(20);
            /* Using cursor T000627 */
            pr_default.execute(21, new Object[] {A8CountryId});
            A9CountryName = T000627_A9CountryName[0];
            AssignAttri("", false, "A9CountryName", A9CountryName);
            pr_default.close(21);
         }
      }

      protected void ProcessNestedLevel0610( )
      {
         s34ShoppingCartFinalPrice = O34ShoppingCartFinalPrice;
         n34ShoppingCartFinalPrice = false;
         AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow0610( ) ;
            if ( ( nRcdExists_10 != 0 ) || ( nIsMod_10 != 0 ) )
            {
               standaloneNotModal0610( ) ;
               GetKey0610( ) ;
               if ( ( nRcdExists_10 == 0 ) && ( nRcdDeleted_10 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0610( ) ;
               }
               else
               {
                  if ( RcdFound10 != 0 )
                  {
                     if ( ( nRcdDeleted_10 != 0 ) && ( nRcdExists_10 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0610( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_10 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0610( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_10 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_88_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
               n34ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            }
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( edtProductName_Internalname, StringUtil.RTrim( A13ProductName)) ;
            ChangePostValue( edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 11, 2, ",", ""))) ;
            ChangePostValue( edtQtyProduct_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A36QtyProduct), 4, 0, ",", ""))) ;
            ChangePostValue( edtTotalProduct_Internalname, StringUtil.LTrim( StringUtil.NToC( A35TotalProduct, 11, 2, ",", ""))) ;
            ChangePostValue( edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CategoryId), 4, 0, ",", ""))) ;
            ChangePostValue( edtCategoryName_Internalname, StringUtil.RTrim( A7CategoryName)) ;
            ChangePostValue( "ZT_"+"Z12ProductId_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12ProductId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z36QtyProduct_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z36QtyProduct), 4, 0, ",", ""))) ;
            ChangePostValue( "T35TotalProduct_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( O35TotalProduct, 8, 2, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_10_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_10), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_10_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_10), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_10_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_10), 4, 0, ",", ""))) ;
            if ( nIsMod_10 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTPRICE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "QTYPRODUCT_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtQtyProduct_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TOTALPRODUCT_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTotalProduct_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORYNAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0610( ) ;
         if ( AnyError != 0 )
         {
            O34ShoppingCartFinalPrice = s34ShoppingCartFinalPrice;
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         }
         nRcdExists_10 = 0;
         nIsMod_10 = 0;
         nRcdDeleted_10 = 0;
      }

      protected void ProcessLevel069( )
      {
         /* Save parent mode. */
         sMode9 = Gx_mode;
         ProcessNestedLevel0610( ) ;
         if ( AnyError != 0 )
         {
            O34ShoppingCartFinalPrice = s34ShoppingCartFinalPrice;
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         }
         /* Restore parent mode. */
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel069( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete069( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("shoppingcart",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("shoppingcart",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart069( )
      {
         /* Scan By routine */
         /* Using cursor T000628 */
         pr_default.execute(22);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound9 = 1;
            A16ShoppingCartId = T000628_A16ShoppingCartId[0];
            AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext069( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound9 = 1;
            A16ShoppingCartId = T000628_A16ShoppingCartId[0];
            AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
         }
      }

      protected void ScanEnd069( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm069( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert069( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate069( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete069( )
      {
         /* Before Delete Rules */
         if ( DateTimeUtil.ResetTime ( A33ShoppingCartDate ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
         {
            GX_msglist.addItem("Não é possível excluir o carrinho de hoje", 1, "SHOPPINGCARTDATE");
            AnyError = 1;
            GX_FocusControl = edtShoppingCartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void BeforeComplete069( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate069( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes069( )
      {
         edtShoppingCartId_Enabled = 0;
         AssignProp("", false, edtShoppingCartId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartId_Enabled), 5, 0), true);
         edtShoppingCartDate_Enabled = 0;
         AssignProp("", false, edtShoppingCartDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartDate_Enabled), 5, 0), true);
         edtShoppingCartDateDelivery_Enabled = 0;
         AssignProp("", false, edtShoppingCartDateDelivery_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartDateDelivery_Enabled), 5, 0), true);
         edtCustomerId_Enabled = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         edtCustomerName_Enabled = 0;
         AssignProp("", false, edtCustomerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerName_Enabled), 5, 0), true);
         edtCountryId_Enabled = 0;
         AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         edtCountryName_Enabled = 0;
         AssignProp("", false, edtCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryName_Enabled), 5, 0), true);
         edtCustomerAddress_Enabled = 0;
         AssignProp("", false, edtCustomerAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerAddress_Enabled), 5, 0), true);
         edtCustomerPhone_Enabled = 0;
         AssignProp("", false, edtCustomerPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerPhone_Enabled), 5, 0), true);
         edtShoppingCartFinalPrice_Enabled = 0;
         AssignProp("", false, edtShoppingCartFinalPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShoppingCartFinalPrice_Enabled), 5, 0), true);
      }

      protected void ZM0610( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z36QtyProduct = T00063_A36QtyProduct[0];
            }
            else
            {
               Z36QtyProduct = A36QtyProduct;
            }
         }
         if ( GX_JID == -18 )
         {
            Z16ShoppingCartId = A16ShoppingCartId;
            Z36QtyProduct = A36QtyProduct;
            Z12ProductId = A12ProductId;
            Z13ProductName = A13ProductName;
            Z27ProductPrice = A27ProductPrice;
            Z6CategoryId = A6CategoryId;
            Z7CategoryName = A7CategoryName;
         }
      }

      protected void standaloneNotModal0610( )
      {
      }

      protected void standaloneModal0610( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProductId_Enabled = 0;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
         else
         {
            edtProductId_Enabled = 1;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
      }

      protected void Load0610( )
      {
         /* Using cursor T000629 */
         pr_default.execute(23, new Object[] {A16ShoppingCartId, A12ProductId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound10 = 1;
            A13ProductName = T000629_A13ProductName[0];
            A27ProductPrice = T000629_A27ProductPrice[0];
            A36QtyProduct = T000629_A36QtyProduct[0];
            A7CategoryName = T000629_A7CategoryName[0];
            A6CategoryId = T000629_A6CategoryId[0];
            ZM0610( -18) ;
         }
         pr_default.close(23);
         OnLoadActions0610( ) ;
      }

      protected void OnLoadActions0610( )
      {
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
         O35TotalProduct = A35TotalProduct;
         if ( IsIns( )  )
         {
            A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice+A35TotalProduct);
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice+A35TotalProduct-O35TotalProduct);
               n34ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice-O35TotalProduct);
                  n34ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
               }
            }
         }
      }

      protected void CheckExtendedTable0610( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0610( ) ;
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_88_idx;
            GX_msglist.addItem("Não existe 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A13ProductName = T00064_A13ProductName[0];
         A27ProductPrice = T00064_A27ProductPrice[0];
         A6CategoryId = T00064_A6CategoryId[0];
         pr_default.close(2);
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A6CategoryId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "CATEGORYID_" + sGXsfl_88_idx;
            GX_msglist.addItem("Não existe 'Category'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A7CategoryName = T00065_A7CategoryName[0];
         pr_default.close(3);
         if ( StringUtil.StrCmp(A7CategoryName, "Entretenimiento") == 0 )
         {
            nIsDirty_10 = 1;
            A35TotalProduct = (decimal)((A27ProductPrice*0.9m)*A36QtyProduct);
         }
         else
         {
            if ( StringUtil.StrCmp(A7CategoryName, "Joyería") == 0 )
            {
               nIsDirty_10 = 1;
               A35TotalProduct = (decimal)((A27ProductPrice*1.05m)*A36QtyProduct);
            }
            else
            {
               nIsDirty_10 = 1;
               A35TotalProduct = (decimal)(A27ProductPrice*A36QtyProduct);
            }
         }
         if ( IsIns( )  )
         {
            nIsDirty_10 = 1;
            A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice+A35TotalProduct);
            n34ShoppingCartFinalPrice = false;
            AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_10 = 1;
               A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice+A35TotalProduct-O35TotalProduct);
               n34ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_10 = 1;
                  A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice-O35TotalProduct);
                  n34ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
               }
            }
         }
      }

      protected void CloseExtendedTableCursors0610( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0610( )
      {
      }

      protected void gxLoad_19( short A12ProductId )
      {
         /* Using cursor T000630 */
         pr_default.execute(24, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_88_idx;
            GX_msglist.addItem("Não existe 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A13ProductName = T000630_A13ProductName[0];
         A27ProductPrice = T000630_A27ProductPrice[0];
         A6CategoryId = T000630_A6CategoryId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A13ProductName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 8, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CategoryId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void gxLoad_20( short A6CategoryId )
      {
         /* Using cursor T000631 */
         pr_default.execute(25, new Object[] {A6CategoryId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GXCCtl = "CATEGORYID_" + sGXsfl_88_idx;
            GX_msglist.addItem("Não existe 'Category'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A7CategoryName = T000631_A7CategoryName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A7CategoryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void GetKey0610( )
      {
         /* Using cursor T000632 */
         pr_default.execute(26, new Object[] {A16ShoppingCartId, A12ProductId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(26);
      }

      protected void getByPrimaryKey0610( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A16ShoppingCartId, A12ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0610( 18) ;
            RcdFound10 = 1;
            InitializeNonKey0610( ) ;
            A36QtyProduct = T00063_A36QtyProduct[0];
            A12ProductId = T00063_A12ProductId[0];
            Z16ShoppingCartId = A16ShoppingCartId;
            Z12ProductId = A12ProductId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0610( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0610( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0610( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0610( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0610( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A16ShoppingCartId, A12ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCartProduct"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z36QtyProduct != T00062_A36QtyProduct[0] ) )
            {
               if ( Z36QtyProduct != T00062_A36QtyProduct[0] )
               {
                  GXUtil.WriteLog("shoppingcart:[seudo value changed for attri]"+"QtyProduct");
                  GXUtil.WriteLogRaw("Old: ",Z36QtyProduct);
                  GXUtil.WriteLogRaw("Current: ",T00062_A36QtyProduct[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ShoppingCartProduct"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0610( )
      {
         BeforeValidate0610( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0610( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0610( 0) ;
            CheckOptimisticConcurrency0610( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0610( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0610( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000633 */
                     pr_default.execute(27, new Object[] {A16ShoppingCartId, A36QtyProduct, A12ProductId});
                     pr_default.close(27);
                     dsDefault.SmartCacheProvider.SetUpdated("ShoppingCartProduct");
                     if ( (pr_default.getStatus(27) == 1) )
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
               Load0610( ) ;
            }
            EndLevel0610( ) ;
         }
         CloseExtendedTableCursors0610( ) ;
      }

      protected void Update0610( )
      {
         BeforeValidate0610( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0610( ) ;
         }
         if ( ( nIsMod_10 != 0 ) || ( nIsDirty_10 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0610( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0610( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0610( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000634 */
                        pr_default.execute(28, new Object[] {A36QtyProduct, A16ShoppingCartId, A12ProductId});
                        pr_default.close(28);
                        dsDefault.SmartCacheProvider.SetUpdated("ShoppingCartProduct");
                        if ( (pr_default.getStatus(28) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ShoppingCartProduct"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0610( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0610( ) ;
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
               EndLevel0610( ) ;
            }
         }
         CloseExtendedTableCursors0610( ) ;
      }

      protected void DeferredUpdate0610( )
      {
      }

      protected void Delete0610( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0610( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0610( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0610( ) ;
            AfterConfirm0610( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0610( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000635 */
                  pr_default.execute(29, new Object[] {A16ShoppingCartId, A12ProductId});
                  pr_default.close(29);
                  dsDefault.SmartCacheProvider.SetUpdated("ShoppingCartProduct");
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0610( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0610( )
      {
         standaloneModal0610( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000636 */
            pr_default.execute(30, new Object[] {A12ProductId});
            A13ProductName = T000636_A13ProductName[0];
            A27ProductPrice = T000636_A27ProductPrice[0];
            A6CategoryId = T000636_A6CategoryId[0];
            pr_default.close(30);
            /* Using cursor T000637 */
            pr_default.execute(31, new Object[] {A6CategoryId});
            A7CategoryName = T000637_A7CategoryName[0];
            pr_default.close(31);
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
            if ( IsIns( )  )
            {
               A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice+A35TotalProduct);
               n34ShoppingCartFinalPrice = false;
               AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice+A35TotalProduct-O35TotalProduct);
                  n34ShoppingCartFinalPrice = false;
                  AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A34ShoppingCartFinalPrice = (decimal)(O34ShoppingCartFinalPrice-O35TotalProduct);
                     n34ShoppingCartFinalPrice = false;
                     AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
                  }
               }
            }
         }
      }

      protected void EndLevel0610( )
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

      public void ScanStart0610( )
      {
         /* Scan By routine */
         /* Using cursor T000638 */
         pr_default.execute(32, new Object[] {A16ShoppingCartId});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound10 = 1;
            A12ProductId = T000638_A12ProductId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0610( )
      {
         /* Scan next routine */
         pr_default.readNext(32);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound10 = 1;
            A12ProductId = T000638_A12ProductId[0];
         }
      }

      protected void ScanEnd0610( )
      {
         pr_default.close(32);
      }

      protected void AfterConfirm0610( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0610( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0610( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0610( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0610( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0610( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0610( )
      {
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProductPrice_Enabled = 0;
         AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtQtyProduct_Enabled = 0;
         AssignProp("", false, edtQtyProduct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtQtyProduct_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtTotalProduct_Enabled = 0;
         AssignProp("", false, edtTotalProduct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotalProduct_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtCategoryId_Enabled = 0;
         AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtCategoryName_Enabled = 0;
         AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void send_integrity_lvl_hashes0610( )
      {
      }

      protected void send_integrity_lvl_hashes069( )
      {
      }

      protected void SubsflControlProps_8810( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_88_idx;
         imgprompt_12_Internalname = "PROMPT_12_"+sGXsfl_88_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_88_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_88_idx;
         edtQtyProduct_Internalname = "QTYPRODUCT_"+sGXsfl_88_idx;
         edtTotalProduct_Internalname = "TOTALPRODUCT_"+sGXsfl_88_idx;
         edtCategoryId_Internalname = "CATEGORYID_"+sGXsfl_88_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_88_idx;
      }

      protected void SubsflControlProps_fel_8810( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_88_fel_idx;
         imgprompt_12_Internalname = "PROMPT_12_"+sGXsfl_88_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_88_fel_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_88_fel_idx;
         edtQtyProduct_Internalname = "QTYPRODUCT_"+sGXsfl_88_fel_idx;
         edtTotalProduct_Internalname = "TOTALPRODUCT_"+sGXsfl_88_fel_idx;
         edtCategoryId_Internalname = "CATEGORYID_"+sGXsfl_88_fel_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_88_fel_idx;
      }

      protected void AddRow0610( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8810( ) ;
         SendRow0610( ) ;
      }

      protected void SendRow0610( )
      {
         Gridshoppingcart_productRow = GXWebRow.GetNew(context);
         if ( subGridshoppingcart_product_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridshoppingcart_product_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
            {
               subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Odd";
            }
         }
         else if ( subGridshoppingcart_product_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridshoppingcart_product_Backstyle = 0;
            subGridshoppingcart_product_Backcolor = subGridshoppingcart_product_Allbackcolor;
            if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
            {
               subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Uniform";
            }
         }
         else if ( subGridshoppingcart_product_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridshoppingcart_product_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
            {
               subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Odd";
            }
            subGridshoppingcart_product_Backcolor = (int)(0x0);
         }
         else if ( subGridshoppingcart_product_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridshoppingcart_product_Backstyle = 1;
            if ( ((int)((nGXsfl_88_idx) % (2))) == 0 )
            {
               subGridshoppingcart_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
               {
                  subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Even";
               }
            }
            else
            {
               subGridshoppingcart_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridshoppingcart_product_Class, "") != 0 )
               {
                  subGridshoppingcart_product_Linesclass = subGridshoppingcart_product_Class+"Odd";
               }
            }
         }
         imgprompt_12_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID_"+sGXsfl_88_idx+"'), id:'"+"PRODUCTID_"+sGXsfl_88_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_10_"+sGXsfl_88_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12ProductId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridshoppingcart_productRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_12_Internalname,(string)sImgUrl,(string)imgprompt_12_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_12_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,StringUtil.RTrim( A13ProductName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 11, 2, ",", "")),StringUtil.LTrim( ((edtProductPrice_Enabled!=0) ? context.localUtil.Format( A27ProductPrice, "R$ ZZZZ9.99") : context.localUtil.Format( A27ProductPrice, "R$ ZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductPrice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtQtyProduct_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A36QtyProduct), 4, 0, ",", "")),StringUtil.LTrim( ((edtQtyProduct_Enabled!=0) ? context.localUtil.Format( (decimal)(A36QtyProduct), "ZZZ9") : context.localUtil.Format( (decimal)(A36QtyProduct), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,92);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtQtyProduct_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtQtyProduct_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTotalProduct_Internalname,StringUtil.LTrim( StringUtil.NToC( A35TotalProduct, 11, 2, ",", "")),StringUtil.LTrim( ((edtTotalProduct_Enabled!=0) ? context.localUtil.Format( A35TotalProduct, "R$ ZZZZ9.99") : context.localUtil.Format( A35TotalProduct, "R$ ZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTotalProduct_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtTotalProduct_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoryId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CategoryId), 4, 0, ",", "")),StringUtil.LTrim( ((edtCategoryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A6CategoryId), "ZZZ9") : context.localUtil.Format( (decimal)(A6CategoryId), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoryId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCategoryId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridshoppingcart_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoryName_Internalname,StringUtil.RTrim( A7CategoryName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoryName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCategoryName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridshoppingcart_productRow);
         send_integrity_lvl_hashes0610( ) ;
         GXCCtl = "Z12ProductId_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12ProductId), 4, 0, ",", "")));
         GXCCtl = "Z36QtyProduct_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z36QtyProduct), 4, 0, ",", "")));
         GXCCtl = "O35TotalProduct_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( O35TotalProduct, 8, 2, ",", "")));
         GXCCtl = "nRcdDeleted_10_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_10), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_10_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_10), 4, 0, ",", "")));
         GXCCtl = "nIsMod_10_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_10), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_88_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV10TrnContext);
         }
         GXCCtl = "vSHOPPINGCARTID_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ShoppingCartId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTPRICE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "QTYPRODUCT_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtQtyProduct_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TOTALPRODUCT_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTotalProduct_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORYID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORYNAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoryName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_12_"+sGXsfl_88_idx+"Link", StringUtil.RTrim( imgprompt_12_Link));
         ajax_sending_grid_row(null);
         Gridshoppingcart_productContainer.AddRow(Gridshoppingcart_productRow);
      }

      protected void ReadRow0610( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8810( ) ;
         edtProductId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         edtProductName_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         edtProductPrice_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUCTPRICE_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         edtQtyProduct_Enabled = (int)(context.localUtil.CToN( cgiGet( "QTYPRODUCT_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         edtTotalProduct_Enabled = (int)(context.localUtil.CToN( cgiGet( "TOTALPRODUCT_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         edtCategoryId_Enabled = (int)(context.localUtil.CToN( cgiGet( "CATEGORYID_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         edtCategoryName_Enabled = (int)(context.localUtil.CToN( cgiGet( "CATEGORYNAME_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         imgprompt_11_Link = cgiGet( "PROMPT_12_"+sGXsfl_88_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_88_idx;
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
         if ( ( ( context.localUtil.CToN( cgiGet( edtQtyProduct_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtQtyProduct_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "QTYPRODUCT_" + sGXsfl_88_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtQtyProduct_Internalname;
            wbErr = true;
            A36QtyProduct = 0;
         }
         else
         {
            A36QtyProduct = (short)(context.localUtil.CToN( cgiGet( edtQtyProduct_Internalname), ",", "."));
         }
         A35TotalProduct = context.localUtil.CToN( cgiGet( edtTotalProduct_Internalname), ",", ".");
         A6CategoryId = (short)(context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ",", "."));
         A7CategoryName = cgiGet( edtCategoryName_Internalname);
         GXCCtl = "Z12ProductId_" + sGXsfl_88_idx;
         Z12ProductId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z36QtyProduct_" + sGXsfl_88_idx;
         Z36QtyProduct = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "O35TotalProduct_" + sGXsfl_88_idx;
         O35TotalProduct = context.localUtil.CToN( cgiGet( GXCCtl), ",", ".");
         GXCCtl = "nRcdDeleted_10_" + sGXsfl_88_idx;
         nRcdDeleted_10 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_10_" + sGXsfl_88_idx;
         nRcdExists_10 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_10_" + sGXsfl_88_idx;
         nIsMod_10 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void assign_properties_default( )
      {
         defedtProductId_Enabled = edtProductId_Enabled;
      }

      protected void ConfirmValues060( )
      {
         nGXsfl_88_idx = 0;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8810( ) ;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8810( ) ;
            ChangePostValue( "Z12ProductId_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z12ProductId_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z12ProductId_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z36QtyProduct_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z36QtyProduct_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z36QtyProduct_"+sGXsfl_88_idx) ;
         }
         ChangePostValue( "O35TotalProduct", cgiGet( "T35TotalProduct")) ;
         DeletePostValue( "T35TotalProduct") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202352119123387", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("shoppingcart.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV9ShoppingCartId,4,0))}, new string[] {"Gx_mode","ShoppingCartId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ShoppingCart");
         forbiddenHiddens.Add("ShoppingCartId", context.localUtil.Format( (decimal)(A16ShoppingCartId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("shoppingcart:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z16ShoppingCartId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16ShoppingCartId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z33ShoppingCartDate", context.localUtil.DToC( Z33ShoppingCartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z11CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11CustomerId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O34ShoppingCartFinalPrice", StringUtil.LTrim( StringUtil.NToC( O34ShoppingCartFinalPrice, 10, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_88", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_88_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N11CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11CustomerId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vSHOPPINGCARTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ShoppingCartId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSHOPPINGCARTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9ShoppingCartId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Insert_CustomerId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
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
         return formatLink("shoppingcart.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV9ShoppingCartId,4,0))}, new string[] {"Gx_mode","ShoppingCartId"})  ;
      }

      public override string GetPgmname( )
      {
         return "ShoppingCart" ;
      }

      public override string GetPgmdesc( )
      {
         return "Carrinho de Compras" ;
      }

      protected void InitializeNonKey069( )
      {
         A11CustomerId = 0;
         AssignAttri("", false, "A11CustomerId", StringUtil.LTrimStr( (decimal)(A11CustomerId), 4, 0));
         A38ShoppingCartDateDelivery = DateTime.MinValue;
         AssignAttri("", false, "A38ShoppingCartDateDelivery", context.localUtil.Format(A38ShoppingCartDateDelivery, "99/99/99"));
         A20CustomerName = "";
         AssignAttri("", false, "A20CustomerName", A20CustomerName);
         A8CountryId = 0;
         AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
         A9CountryName = "";
         AssignAttri("", false, "A9CountryName", A9CountryName);
         A21CustomerAddress = "";
         AssignAttri("", false, "A21CustomerAddress", A21CustomerAddress);
         A23CustomerPhone = "";
         AssignAttri("", false, "A23CustomerPhone", A23CustomerPhone);
         A34ShoppingCartFinalPrice = 0;
         n34ShoppingCartFinalPrice = false;
         AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         A33ShoppingCartDate = DateTimeUtil.Today( context);
         AssignAttri("", false, "A33ShoppingCartDate", context.localUtil.Format(A33ShoppingCartDate, "99/99/99"));
         O34ShoppingCartFinalPrice = A34ShoppingCartFinalPrice;
         n34ShoppingCartFinalPrice = false;
         AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         Z33ShoppingCartDate = DateTime.MinValue;
         Z11CustomerId = 0;
      }

      protected void InitAll069( )
      {
         A16ShoppingCartId = 0;
         AssignAttri("", false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
         InitializeNonKey069( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A33ShoppingCartDate = i33ShoppingCartDate;
         AssignAttri("", false, "A33ShoppingCartDate", context.localUtil.Format(A33ShoppingCartDate, "99/99/99"));
      }

      protected void InitializeNonKey0610( )
      {
         A35TotalProduct = 0;
         A13ProductName = "";
         A27ProductPrice = 0;
         A36QtyProduct = 0;
         A6CategoryId = 0;
         A7CategoryName = "";
         O35TotalProduct = A35TotalProduct;
         Z36QtyProduct = 0;
      }

      protected void InitAll0610( )
      {
         A12ProductId = 0;
         InitializeNonKey0610( ) ;
      }

      protected void StandaloneModalInsert0610( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202352119123418", true, true);
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
         context.AddJavascriptSource("shoppingcart.js", "?202352119123419", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties10( )
      {
         edtProductId_Enabled = defedtProductId_Enabled;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
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
         edtShoppingCartId_Internalname = "SHOPPINGCARTID";
         edtShoppingCartDate_Internalname = "SHOPPINGCARTDATE";
         edtShoppingCartDateDelivery_Internalname = "SHOPPINGCARTDATEDELIVERY";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerName_Internalname = "CUSTOMERNAME";
         edtCountryId_Internalname = "COUNTRYID";
         edtCountryName_Internalname = "COUNTRYNAME";
         edtCustomerAddress_Internalname = "CUSTOMERADDRESS";
         edtCustomerPhone_Internalname = "CUSTOMERPHONE";
         edtShoppingCartFinalPrice_Internalname = "SHOPPINGCARTFINALPRICE";
         lblTitleproduct_Internalname = "TITLEPRODUCT";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         edtQtyProduct_Internalname = "QTYPRODUCT";
         edtTotalProduct_Internalname = "TOTALPRODUCT";
         edtCategoryId_Internalname = "CATEGORYID";
         edtCategoryName_Internalname = "CATEGORYNAME";
         divProducttable_Internalname = "PRODUCTTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_11_Internalname = "PROMPT_11";
         imgprompt_12_Internalname = "PROMPT_12";
         subGridshoppingcart_product_Internalname = "GRIDSHOPPINGCART_PRODUCT";
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
         Form.Caption = "Carrinho de Compras";
         edtCategoryName_Jsonclick = "";
         edtCategoryId_Jsonclick = "";
         edtTotalProduct_Jsonclick = "";
         edtQtyProduct_Jsonclick = "";
         edtProductPrice_Jsonclick = "";
         edtProductName_Jsonclick = "";
         imgprompt_12_Visible = 1;
         imgprompt_12_Link = "";
         imgprompt_11_Visible = 1;
         edtProductId_Jsonclick = "";
         subGridshoppingcart_product_Class = "Grid";
         subGridshoppingcart_product_Backcolorstyle = 0;
         subGridshoppingcart_product_Allowcollapsing = 0;
         subGridshoppingcart_product_Allowselection = 0;
         edtCategoryName_Enabled = 0;
         edtCategoryId_Enabled = 0;
         edtTotalProduct_Enabled = 0;
         edtQtyProduct_Enabled = 1;
         edtProductPrice_Enabled = 0;
         edtProductName_Enabled = 0;
         edtProductId_Enabled = 1;
         subGridshoppingcart_product_Header = "";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtShoppingCartFinalPrice_Jsonclick = "";
         edtShoppingCartFinalPrice_Enabled = 0;
         edtCustomerPhone_Jsonclick = "";
         edtCustomerPhone_Enabled = 0;
         edtCustomerAddress_Enabled = 0;
         edtCountryName_Jsonclick = "";
         edtCountryName_Enabled = 0;
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 0;
         edtCustomerName_Jsonclick = "";
         edtCustomerName_Enabled = 0;
         imgprompt_11_Visible = 1;
         imgprompt_11_Link = "";
         edtCustomerId_Jsonclick = "";
         edtCustomerId_Enabled = 1;
         edtShoppingCartDateDelivery_Jsonclick = "";
         edtShoppingCartDateDelivery_Enabled = 0;
         edtShoppingCartDate_Jsonclick = "";
         edtShoppingCartDate_Enabled = 1;
         edtShoppingCartId_Jsonclick = "";
         edtShoppingCartId_Enabled = 0;
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

      protected void gxnrGridshoppingcart_product_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_8810( ) ;
         while ( nGXsfl_88_idx <= nRC_GXsfl_88 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0610( ) ;
            standaloneModal0610( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0610( ) ;
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8810( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridshoppingcart_productContainer)) ;
         /* End function gxnrGridshoppingcart_product_newrow */
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

      public void Valid_Shoppingcartid( )
      {
         n34ShoppingCartFinalPrice = false;
         /* Using cursor T000625 */
         pr_default.execute(19, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A34ShoppingCartFinalPrice = T000625_A34ShoppingCartFinalPrice[0];
            n34ShoppingCartFinalPrice = T000625_n34ShoppingCartFinalPrice[0];
         }
         else
         {
            A34ShoppingCartFinalPrice = 0;
            n34ShoppingCartFinalPrice = false;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A34ShoppingCartFinalPrice", StringUtil.LTrim( StringUtil.NToC( A34ShoppingCartFinalPrice, 10, 2, ".", "")));
      }

      public void Valid_Customerid( )
      {
         /* Using cursor T000626 */
         pr_default.execute(20, new Object[] {A11CustomerId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("Não existe 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
         }
         A20CustomerName = T000626_A20CustomerName[0];
         A21CustomerAddress = T000626_A21CustomerAddress[0];
         A23CustomerPhone = T000626_A23CustomerPhone[0];
         A8CountryId = T000626_A8CountryId[0];
         pr_default.close(20);
         /* Using cursor T000627 */
         pr_default.execute(21, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A9CountryName = T000627_A9CountryName[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A20CustomerName", StringUtil.RTrim( A20CustomerName));
         AssignAttri("", false, "A21CustomerAddress", A21CustomerAddress);
         AssignAttri("", false, "A23CustomerPhone", StringUtil.RTrim( A23CustomerPhone));
         AssignAttri("", false, "A8CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A9CountryName", StringUtil.RTrim( A9CountryName));
      }

      public void Valid_Productid( )
      {
         /* Using cursor T000636 */
         pr_default.execute(30, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("Não existe 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
         }
         A13ProductName = T000636_A13ProductName[0];
         A27ProductPrice = T000636_A27ProductPrice[0];
         A6CategoryId = T000636_A6CategoryId[0];
         pr_default.close(30);
         /* Using cursor T000637 */
         pr_default.execute(31, new Object[] {A6CategoryId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem("Não existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
         }
         A7CategoryName = T000637_A7CategoryName[0];
         pr_default.close(31);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A13ProductName", StringUtil.RTrim( A13ProductName));
         AssignAttri("", false, "A27ProductPrice", StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 8, 2, ".", "")));
         AssignAttri("", false, "A6CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CategoryId), 4, 0, ".", "")));
         AssignAttri("", false, "A7CategoryName", StringUtil.RTrim( A7CategoryName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9ShoppingCartId',fld:'vSHOPPINGCARTID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV9ShoppingCartId',fld:'vSHOPPINGCARTID',pic:'ZZZ9',hsh:true},{av:'A16ShoppingCartId',fld:'SHOPPINGCARTID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12062',iparms:[{av:'A16ShoppingCartId',fld:'SHOPPINGCARTID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A16ShoppingCartId',fld:'SHOPPINGCARTID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_SHOPPINGCARTID","{handler:'Valid_Shoppingcartid',iparms:[{av:'A16ShoppingCartId',fld:'SHOPPINGCARTID',pic:'ZZZ9'},{av:'A34ShoppingCartFinalPrice',fld:'SHOPPINGCARTFINALPRICE',pic:'R$ ZZZZZZ9.99'}]");
         setEventMetadata("VALID_SHOPPINGCARTID",",oparms:[{av:'A34ShoppingCartFinalPrice',fld:'SHOPPINGCARTFINALPRICE',pic:'R$ ZZZZZZ9.99'}]}");
         setEventMetadata("VALID_SHOPPINGCARTDATE","{handler:'Valid_Shoppingcartdate',iparms:[]");
         setEventMetadata("VALID_SHOPPINGCARTDATE",",oparms:[]}");
         setEventMetadata("VALID_CUSTOMERID","{handler:'Valid_Customerid',iparms:[{av:'A11CustomerId',fld:'CUSTOMERID',pic:'ZZZ9'},{av:'A8CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A20CustomerName',fld:'CUSTOMERNAME',pic:''},{av:'A21CustomerAddress',fld:'CUSTOMERADDRESS',pic:''},{av:'A23CustomerPhone',fld:'CUSTOMERPHONE',pic:'(99) 9999-9999'},{av:'A9CountryName',fld:'COUNTRYNAME',pic:''}]");
         setEventMetadata("VALID_CUSTOMERID",",oparms:[{av:'A20CustomerName',fld:'CUSTOMERNAME',pic:''},{av:'A21CustomerAddress',fld:'CUSTOMERADDRESS',pic:''},{av:'A23CustomerPhone',fld:'CUSTOMERPHONE',pic:'(99) 9999-9999'},{av:'A8CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A9CountryName',fld:'COUNTRYNAME',pic:''}]}");
         setEventMetadata("VALID_COUNTRYID","{handler:'Valid_Countryid',iparms:[]");
         setEventMetadata("VALID_COUNTRYID",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A12ProductId',fld:'PRODUCTID',pic:'ZZZ9'},{av:'A6CategoryId',fld:'CATEGORYID',pic:'ZZZ9'},{av:'A13ProductName',fld:'PRODUCTNAME',pic:''},{av:'A27ProductPrice',fld:'PRODUCTPRICE',pic:'R$ ZZZZ9.99'},{av:'A7CategoryName',fld:'CATEGORYNAME',pic:''}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[{av:'A13ProductName',fld:'PRODUCTNAME',pic:''},{av:'A27ProductPrice',fld:'PRODUCTPRICE',pic:'R$ ZZZZ9.99'},{av:'A6CategoryId',fld:'CATEGORYID',pic:'ZZZ9'},{av:'A7CategoryName',fld:'CATEGORYNAME',pic:''}]}");
         setEventMetadata("VALID_PRODUCTPRICE","{handler:'Valid_Productprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTPRICE",",oparms:[]}");
         setEventMetadata("VALID_QTYPRODUCT","{handler:'Valid_Qtyproduct',iparms:[]");
         setEventMetadata("VALID_QTYPRODUCT",",oparms:[]}");
         setEventMetadata("VALID_TOTALPRODUCT","{handler:'Valid_Totalproduct',iparms:[]");
         setEventMetadata("VALID_TOTALPRODUCT",",oparms:[]}");
         setEventMetadata("VALID_CATEGORYID","{handler:'Valid_Categoryid',iparms:[]");
         setEventMetadata("VALID_CATEGORYID",",oparms:[]}");
         setEventMetadata("VALID_CATEGORYNAME","{handler:'Valid_Categoryname',iparms:[]");
         setEventMetadata("VALID_CATEGORYNAME",",oparms:[]}");
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
         pr_default.close(30);
         pr_default.close(31);
         pr_default.close(5);
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z33ShoppingCartDate = DateTime.MinValue;
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
         A33ShoppingCartDate = DateTime.MinValue;
         A38ShoppingCartDateDelivery = DateTime.MinValue;
         sImgUrl = "";
         A20CustomerName = "";
         A9CountryName = "";
         A21CustomerAddress = "";
         gxphoneLink = "";
         A23CustomerPhone = "";
         lblTitleproduct_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridshoppingcart_productContainer = new GXWebGrid( context);
         Gridshoppingcart_productColumn = new GXWebColumn();
         A13ProductName = "";
         A7CategoryName = "";
         sMode10 = "";
         sStyleString = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV10TrnContext = new SdtTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV11TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z20CustomerName = "";
         Z21CustomerAddress = "";
         Z23CustomerPhone = "";
         Z9CountryName = "";
         T000611_A34ShoppingCartFinalPrice = new decimal[1] ;
         T000611_n34ShoppingCartFinalPrice = new bool[] {false} ;
         T00068_A20CustomerName = new string[] {""} ;
         T00068_A21CustomerAddress = new string[] {""} ;
         T00068_A23CustomerPhone = new string[] {""} ;
         T00068_A8CountryId = new short[1] ;
         T00069_A9CountryName = new string[] {""} ;
         T000613_A16ShoppingCartId = new short[1] ;
         T000613_A33ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         T000613_A20CustomerName = new string[] {""} ;
         T000613_A9CountryName = new string[] {""} ;
         T000613_A21CustomerAddress = new string[] {""} ;
         T000613_A23CustomerPhone = new string[] {""} ;
         T000613_A11CustomerId = new short[1] ;
         T000613_A8CountryId = new short[1] ;
         T000613_A34ShoppingCartFinalPrice = new decimal[1] ;
         T000613_n34ShoppingCartFinalPrice = new bool[] {false} ;
         T000615_A34ShoppingCartFinalPrice = new decimal[1] ;
         T000615_n34ShoppingCartFinalPrice = new bool[] {false} ;
         T000616_A20CustomerName = new string[] {""} ;
         T000616_A21CustomerAddress = new string[] {""} ;
         T000616_A23CustomerPhone = new string[] {""} ;
         T000616_A8CountryId = new short[1] ;
         T000617_A9CountryName = new string[] {""} ;
         T000618_A16ShoppingCartId = new short[1] ;
         T00067_A16ShoppingCartId = new short[1] ;
         T00067_A33ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         T00067_A11CustomerId = new short[1] ;
         T000619_A16ShoppingCartId = new short[1] ;
         T000620_A16ShoppingCartId = new short[1] ;
         T00066_A16ShoppingCartId = new short[1] ;
         T00066_A33ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         T00066_A11CustomerId = new short[1] ;
         T000621_A16ShoppingCartId = new short[1] ;
         T000625_A34ShoppingCartFinalPrice = new decimal[1] ;
         T000625_n34ShoppingCartFinalPrice = new bool[] {false} ;
         T000626_A20CustomerName = new string[] {""} ;
         T000626_A21CustomerAddress = new string[] {""} ;
         T000626_A23CustomerPhone = new string[] {""} ;
         T000626_A8CountryId = new short[1] ;
         T000627_A9CountryName = new string[] {""} ;
         T000628_A16ShoppingCartId = new short[1] ;
         Z13ProductName = "";
         Z7CategoryName = "";
         T000629_A16ShoppingCartId = new short[1] ;
         T000629_A13ProductName = new string[] {""} ;
         T000629_A27ProductPrice = new decimal[1] ;
         T000629_A36QtyProduct = new short[1] ;
         T000629_A7CategoryName = new string[] {""} ;
         T000629_A12ProductId = new short[1] ;
         T000629_A6CategoryId = new short[1] ;
         T00064_A13ProductName = new string[] {""} ;
         T00064_A27ProductPrice = new decimal[1] ;
         T00064_A6CategoryId = new short[1] ;
         T00065_A7CategoryName = new string[] {""} ;
         T000630_A13ProductName = new string[] {""} ;
         T000630_A27ProductPrice = new decimal[1] ;
         T000630_A6CategoryId = new short[1] ;
         T000631_A7CategoryName = new string[] {""} ;
         T000632_A16ShoppingCartId = new short[1] ;
         T000632_A12ProductId = new short[1] ;
         T00063_A16ShoppingCartId = new short[1] ;
         T00063_A36QtyProduct = new short[1] ;
         T00063_A12ProductId = new short[1] ;
         T00062_A16ShoppingCartId = new short[1] ;
         T00062_A36QtyProduct = new short[1] ;
         T00062_A12ProductId = new short[1] ;
         T000636_A13ProductName = new string[] {""} ;
         T000636_A27ProductPrice = new decimal[1] ;
         T000636_A6CategoryId = new short[1] ;
         T000637_A7CategoryName = new string[] {""} ;
         T000638_A16ShoppingCartId = new short[1] ;
         T000638_A12ProductId = new short[1] ;
         Gridshoppingcart_productRow = new GXWebRow();
         subGridshoppingcart_product_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i33ShoppingCartDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.shoppingcart__default(),
            new Object[][] {
                new Object[] {
               T00062_A16ShoppingCartId, T00062_A36QtyProduct, T00062_A12ProductId
               }
               , new Object[] {
               T00063_A16ShoppingCartId, T00063_A36QtyProduct, T00063_A12ProductId
               }
               , new Object[] {
               T00064_A13ProductName, T00064_A27ProductPrice, T00064_A6CategoryId
               }
               , new Object[] {
               T00065_A7CategoryName
               }
               , new Object[] {
               T00066_A16ShoppingCartId, T00066_A33ShoppingCartDate, T00066_A11CustomerId
               }
               , new Object[] {
               T00067_A16ShoppingCartId, T00067_A33ShoppingCartDate, T00067_A11CustomerId
               }
               , new Object[] {
               T00068_A20CustomerName, T00068_A21CustomerAddress, T00068_A23CustomerPhone, T00068_A8CountryId
               }
               , new Object[] {
               T00069_A9CountryName
               }
               , new Object[] {
               T000611_A34ShoppingCartFinalPrice, T000611_n34ShoppingCartFinalPrice
               }
               , new Object[] {
               T000613_A16ShoppingCartId, T000613_A33ShoppingCartDate, T000613_A20CustomerName, T000613_A9CountryName, T000613_A21CustomerAddress, T000613_A23CustomerPhone, T000613_A11CustomerId, T000613_A8CountryId, T000613_A34ShoppingCartFinalPrice, T000613_n34ShoppingCartFinalPrice
               }
               , new Object[] {
               T000615_A34ShoppingCartFinalPrice, T000615_n34ShoppingCartFinalPrice
               }
               , new Object[] {
               T000616_A20CustomerName, T000616_A21CustomerAddress, T000616_A23CustomerPhone, T000616_A8CountryId
               }
               , new Object[] {
               T000617_A9CountryName
               }
               , new Object[] {
               T000618_A16ShoppingCartId
               }
               , new Object[] {
               T000619_A16ShoppingCartId
               }
               , new Object[] {
               T000620_A16ShoppingCartId
               }
               , new Object[] {
               T000621_A16ShoppingCartId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000625_A34ShoppingCartFinalPrice, T000625_n34ShoppingCartFinalPrice
               }
               , new Object[] {
               T000626_A20CustomerName, T000626_A21CustomerAddress, T000626_A23CustomerPhone, T000626_A8CountryId
               }
               , new Object[] {
               T000627_A9CountryName
               }
               , new Object[] {
               T000628_A16ShoppingCartId
               }
               , new Object[] {
               T000629_A16ShoppingCartId, T000629_A13ProductName, T000629_A27ProductPrice, T000629_A36QtyProduct, T000629_A7CategoryName, T000629_A12ProductId, T000629_A6CategoryId
               }
               , new Object[] {
               T000630_A13ProductName, T000630_A27ProductPrice, T000630_A6CategoryId
               }
               , new Object[] {
               T000631_A7CategoryName
               }
               , new Object[] {
               T000632_A16ShoppingCartId, T000632_A12ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000636_A13ProductName, T000636_A27ProductPrice, T000636_A6CategoryId
               }
               , new Object[] {
               T000637_A7CategoryName
               }
               , new Object[] {
               T000638_A16ShoppingCartId, T000638_A12ProductId
               }
            }
         );
         AV14Pgmname = "ShoppingCart";
         Z33ShoppingCartDate = DateTimeUtil.Today( context);
         A33ShoppingCartDate = DateTimeUtil.Today( context);
         i33ShoppingCartDate = DateTimeUtil.Today( context);
      }

      private short nIsMod_10 ;
      private short wcpOAV9ShoppingCartId ;
      private short Z16ShoppingCartId ;
      private short Z11CustomerId ;
      private short N11CustomerId ;
      private short Z12ProductId ;
      private short Z36QtyProduct ;
      private short nRcdDeleted_10 ;
      private short nRcdExists_10 ;
      private short GxWebError ;
      private short A16ShoppingCartId ;
      private short A11CustomerId ;
      private short A8CountryId ;
      private short A12ProductId ;
      private short A6CategoryId ;
      private short AV9ShoppingCartId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short subGridshoppingcart_product_Backcolorstyle ;
      private short A36QtyProduct ;
      private short subGridshoppingcart_product_Allowselection ;
      private short subGridshoppingcart_product_Allowhovering ;
      private short subGridshoppingcart_product_Allowcollapsing ;
      private short subGridshoppingcart_product_Collapsed ;
      private short nBlankRcdCount10 ;
      private short RcdFound10 ;
      private short nBlankRcdUsr10 ;
      private short AV7Insert_CustomerId ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short GX_JID ;
      private short Z8CountryId ;
      private short nIsDirty_9 ;
      private short Z6CategoryId ;
      private short nIsDirty_10 ;
      private short subGridshoppingcart_product_Backstyle ;
      private short gxajaxcallmode ;
      private int nRC_GXsfl_88 ;
      private int nGXsfl_88_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtShoppingCartId_Enabled ;
      private int edtShoppingCartDate_Enabled ;
      private int edtShoppingCartDateDelivery_Enabled ;
      private int edtCustomerId_Enabled ;
      private int imgprompt_11_Visible ;
      private int edtCustomerName_Enabled ;
      private int edtCountryId_Enabled ;
      private int edtCountryName_Enabled ;
      private int edtCustomerAddress_Enabled ;
      private int edtCustomerPhone_Enabled ;
      private int edtShoppingCartFinalPrice_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductPrice_Enabled ;
      private int edtQtyProduct_Enabled ;
      private int edtTotalProduct_Enabled ;
      private int edtCategoryId_Enabled ;
      private int edtCategoryName_Enabled ;
      private int subGridshoppingcart_product_Selectedindex ;
      private int subGridshoppingcart_product_Selectioncolor ;
      private int subGridshoppingcart_product_Hoveringcolor ;
      private int fRowAdded ;
      private int AV15GXV1 ;
      private int subGridshoppingcart_product_Backcolor ;
      private int subGridshoppingcart_product_Allbackcolor ;
      private int imgprompt_12_Visible ;
      private int defedtProductId_Enabled ;
      private int idxLst ;
      private long GRIDSHOPPINGCART_PRODUCT_nFirstRecordOnPage ;
      private decimal O34ShoppingCartFinalPrice ;
      private decimal O35TotalProduct ;
      private decimal A34ShoppingCartFinalPrice ;
      private decimal A27ProductPrice ;
      private decimal A35TotalProduct ;
      private decimal B34ShoppingCartFinalPrice ;
      private decimal s34ShoppingCartFinalPrice ;
      private decimal T35TotalProduct ;
      private decimal Z34ShoppingCartFinalPrice ;
      private decimal Z27ProductPrice ;
      private string sPrefix ;
      private string sGXsfl_88_idx="0001" ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtShoppingCartDate_Internalname ;
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
      private string edtShoppingCartId_Internalname ;
      private string edtShoppingCartId_Jsonclick ;
      private string edtShoppingCartDate_Jsonclick ;
      private string edtShoppingCartDateDelivery_Internalname ;
      private string edtShoppingCartDateDelivery_Jsonclick ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_11_Internalname ;
      private string imgprompt_11_Link ;
      private string edtCustomerName_Internalname ;
      private string A20CustomerName ;
      private string edtCustomerName_Jsonclick ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string edtCountryName_Internalname ;
      private string A9CountryName ;
      private string edtCountryName_Jsonclick ;
      private string edtCustomerAddress_Internalname ;
      private string edtCustomerPhone_Internalname ;
      private string gxphoneLink ;
      private string A23CustomerPhone ;
      private string edtCustomerPhone_Jsonclick ;
      private string edtShoppingCartFinalPrice_Internalname ;
      private string edtShoppingCartFinalPrice_Jsonclick ;
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
      private string subGridshoppingcart_product_Header ;
      private string A13ProductName ;
      private string A7CategoryName ;
      private string sMode10 ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductPrice_Internalname ;
      private string edtQtyProduct_Internalname ;
      private string edtTotalProduct_Internalname ;
      private string edtCategoryId_Internalname ;
      private string edtCategoryName_Internalname ;
      private string sStyleString ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode9 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string Z20CustomerName ;
      private string Z23CustomerPhone ;
      private string Z9CountryName ;
      private string Z13ProductName ;
      private string Z7CategoryName ;
      private string imgprompt_12_Internalname ;
      private string sGXsfl_88_fel_idx="0001" ;
      private string subGridshoppingcart_product_Class ;
      private string subGridshoppingcart_product_Linesclass ;
      private string imgprompt_12_Link ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtProductPrice_Jsonclick ;
      private string edtQtyProduct_Jsonclick ;
      private string edtTotalProduct_Jsonclick ;
      private string edtCategoryId_Jsonclick ;
      private string edtCategoryName_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridshoppingcart_product_Internalname ;
      private DateTime Z33ShoppingCartDate ;
      private DateTime A33ShoppingCartDate ;
      private DateTime A38ShoppingCartDateDelivery ;
      private DateTime i33ShoppingCartDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n34ShoppingCartFinalPrice ;
      private bool bGXsfl_88_Refreshing=false ;
      private bool returnInSub ;
      private string A21CustomerAddress ;
      private string Z21CustomerAddress ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridshoppingcart_productContainer ;
      private GXWebRow Gridshoppingcart_productRow ;
      private GXWebColumn Gridshoppingcart_productColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T000611_A34ShoppingCartFinalPrice ;
      private bool[] T000611_n34ShoppingCartFinalPrice ;
      private string[] T00068_A20CustomerName ;
      private string[] T00068_A21CustomerAddress ;
      private string[] T00068_A23CustomerPhone ;
      private short[] T00068_A8CountryId ;
      private string[] T00069_A9CountryName ;
      private short[] T000613_A16ShoppingCartId ;
      private DateTime[] T000613_A33ShoppingCartDate ;
      private string[] T000613_A20CustomerName ;
      private string[] T000613_A9CountryName ;
      private string[] T000613_A21CustomerAddress ;
      private string[] T000613_A23CustomerPhone ;
      private short[] T000613_A11CustomerId ;
      private short[] T000613_A8CountryId ;
      private decimal[] T000613_A34ShoppingCartFinalPrice ;
      private bool[] T000613_n34ShoppingCartFinalPrice ;
      private decimal[] T000615_A34ShoppingCartFinalPrice ;
      private bool[] T000615_n34ShoppingCartFinalPrice ;
      private string[] T000616_A20CustomerName ;
      private string[] T000616_A21CustomerAddress ;
      private string[] T000616_A23CustomerPhone ;
      private short[] T000616_A8CountryId ;
      private string[] T000617_A9CountryName ;
      private short[] T000618_A16ShoppingCartId ;
      private short[] T00067_A16ShoppingCartId ;
      private DateTime[] T00067_A33ShoppingCartDate ;
      private short[] T00067_A11CustomerId ;
      private short[] T000619_A16ShoppingCartId ;
      private short[] T000620_A16ShoppingCartId ;
      private short[] T00066_A16ShoppingCartId ;
      private DateTime[] T00066_A33ShoppingCartDate ;
      private short[] T00066_A11CustomerId ;
      private short[] T000621_A16ShoppingCartId ;
      private decimal[] T000625_A34ShoppingCartFinalPrice ;
      private bool[] T000625_n34ShoppingCartFinalPrice ;
      private string[] T000626_A20CustomerName ;
      private string[] T000626_A21CustomerAddress ;
      private string[] T000626_A23CustomerPhone ;
      private short[] T000626_A8CountryId ;
      private string[] T000627_A9CountryName ;
      private short[] T000628_A16ShoppingCartId ;
      private short[] T000629_A16ShoppingCartId ;
      private string[] T000629_A13ProductName ;
      private decimal[] T000629_A27ProductPrice ;
      private short[] T000629_A36QtyProduct ;
      private string[] T000629_A7CategoryName ;
      private short[] T000629_A12ProductId ;
      private short[] T000629_A6CategoryId ;
      private string[] T00064_A13ProductName ;
      private decimal[] T00064_A27ProductPrice ;
      private short[] T00064_A6CategoryId ;
      private string[] T00065_A7CategoryName ;
      private string[] T000630_A13ProductName ;
      private decimal[] T000630_A27ProductPrice ;
      private short[] T000630_A6CategoryId ;
      private string[] T000631_A7CategoryName ;
      private short[] T000632_A16ShoppingCartId ;
      private short[] T000632_A12ProductId ;
      private short[] T00063_A16ShoppingCartId ;
      private short[] T00063_A36QtyProduct ;
      private short[] T00063_A12ProductId ;
      private short[] T00062_A16ShoppingCartId ;
      private short[] T00062_A36QtyProduct ;
      private short[] T00062_A12ProductId ;
      private string[] T000636_A13ProductName ;
      private decimal[] T000636_A27ProductPrice ;
      private short[] T000636_A6CategoryId ;
      private string[] T000637_A7CategoryName ;
      private short[] T000638_A16ShoppingCartId ;
      private short[] T000638_A12ProductId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV10TrnContext ;
      private SdtTransactionContext_Attribute AV11TrnContextAtt ;
   }

   public class shoppingcart__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new UpdateCursor(def[27])
         ,new UpdateCursor(def[28])
         ,new UpdateCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000613;
          prmT000613 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000611;
          prmT000611 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT00068;
          prmT00068 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmT00069;
          prmT00069 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000615;
          prmT000615 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000616;
          prmT000616 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmT000617;
          prmT000617 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000618;
          prmT000618 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT00067;
          prmT00067 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000619;
          prmT000619 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000620;
          prmT000620 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT00066;
          prmT00066 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000621;
          prmT000621 = new Object[] {
          new ParDef("@ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmT000622;
          prmT000622 = new Object[] {
          new ParDef("@ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0) ,
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000623;
          prmT000623 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000628;
          prmT000628 = new Object[] {
          };
          Object[] prmT000629;
          prmT000629 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00064;
          prmT00064 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00065;
          prmT00065 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000630;
          prmT000630 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000631;
          prmT000631 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000632;
          prmT000632 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00063;
          prmT00063 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00062;
          prmT00062 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000633;
          prmT000633 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@QtyProduct",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000634;
          prmT000634 = new Object[] {
          new ParDef("@QtyProduct",GXType.Int16,4,0) ,
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000635;
          prmT000635 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000638;
          prmT000638 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000625;
          prmT000625 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmT000626;
          prmT000626 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmT000627;
          prmT000627 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000636;
          prmT000636 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000637;
          prmT000637 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT [ShoppingCartId], [QtyProduct], [ProductId] FROM [ShoppingCartProduct] WITH (UPDLOCK) WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT [ShoppingCartId], [QtyProduct], [ProductId] FROM [ShoppingCartProduct] WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT [ProductName], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00065", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00066", "SELECT [ShoppingCartId], [ShoppingCartDate], [CustomerId] FROM [ShoppingCart] WITH (UPDLOCK) WHERE [ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00067", "SELECT [ShoppingCartId], [ShoppingCartDate], [CustomerId] FROM [ShoppingCart] WHERE [ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00068", "SELECT [CustomerName], [CustomerAddress], [CustomerPhone], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00069", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000611", "SELECT COALESCE( T1.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM (SELECT SUM(CASE  WHEN T4.[CategoryName] = 'Entretenimiento' THEN ( T3.[ProductPrice] * CAST(0.9 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 20, 10)) WHEN T4.[CategoryName] = 'Joyería' THEN ( T3.[ProductPrice] * CAST(1.05 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 20, 10)) ELSE T3.[ProductPrice] * CAST(T2.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T2.[ShoppingCartId] FROM (([ShoppingCartProduct] T2 WITH (UPDLOCK) INNER JOIN [Product] T3 ON T3.[ProductId] = T2.[ProductId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T3.[CategoryId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000613", "SELECT TM1.[ShoppingCartId], TM1.[ShoppingCartDate], T3.[CustomerName], T4.[CountryName], T3.[CustomerAddress], T3.[CustomerPhone], TM1.[CustomerId], T3.[CountryId], COALESCE( T2.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM ((([ShoppingCart] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoryName] = 'Entretenimiento' THEN ( T6.[ProductPrice] * CAST(0.9 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 20, 10)) WHEN T7.[CategoryName] = 'Joyería' THEN ( T6.[ProductPrice] * CAST(1.05 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 20, 10)) ELSE T6.[ProductPrice] * CAST(T5.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T5.[ShoppingCartId] FROM (([ShoppingCartProduct] T5 INNER JOIN [Product] T6 ON T6.[ProductId] = T5.[ProductId]) INNER JOIN [Category] T7 ON T7.[CategoryId] = T6.[CategoryId]) GROUP BY T5.[ShoppingCartId] ) T2 ON T2.[ShoppingCartId] = TM1.[ShoppingCartId]) INNER JOIN [Customer] T3 ON T3.[CustomerId] = TM1.[CustomerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) WHERE TM1.[ShoppingCartId] = @ShoppingCartId ORDER BY TM1.[ShoppingCartId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000615", "SELECT COALESCE( T1.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM (SELECT SUM(CASE  WHEN T4.[CategoryName] = 'Entretenimiento' THEN ( T3.[ProductPrice] * CAST(0.9 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 20, 10)) WHEN T4.[CategoryName] = 'Joyería' THEN ( T3.[ProductPrice] * CAST(1.05 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 20, 10)) ELSE T3.[ProductPrice] * CAST(T2.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T2.[ShoppingCartId] FROM (([ShoppingCartProduct] T2 WITH (UPDLOCK) INNER JOIN [Product] T3 ON T3.[ProductId] = T2.[ProductId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T3.[CategoryId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000616", "SELECT [CustomerName], [CustomerAddress], [CustomerPhone], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000617", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000618", "SELECT [ShoppingCartId] FROM [ShoppingCart] WHERE [ShoppingCartId] = @ShoppingCartId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000618,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000619", "SELECT TOP 1 [ShoppingCartId] FROM [ShoppingCart] WHERE ( [ShoppingCartId] > @ShoppingCartId) ORDER BY [ShoppingCartId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000619,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000620", "SELECT TOP 1 [ShoppingCartId] FROM [ShoppingCart] WHERE ( [ShoppingCartId] < @ShoppingCartId) ORDER BY [ShoppingCartId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000620,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000621", "INSERT INTO [ShoppingCart]([ShoppingCartDate], [CustomerId]) VALUES(@ShoppingCartDate, @CustomerId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000621)
             ,new CursorDef("T000622", "UPDATE [ShoppingCart] SET [ShoppingCartDate]=@ShoppingCartDate, [CustomerId]=@CustomerId  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK,prmT000622)
             ,new CursorDef("T000623", "DELETE FROM [ShoppingCart]  WHERE [ShoppingCartId] = @ShoppingCartId", GxErrorMask.GX_NOMASK,prmT000623)
             ,new CursorDef("T000625", "SELECT COALESCE( T1.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM (SELECT SUM(CASE  WHEN T4.[CategoryName] = 'Entretenimiento' THEN ( T3.[ProductPrice] * CAST(0.9 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 20, 10)) WHEN T4.[CategoryName] = 'Joyería' THEN ( T3.[ProductPrice] * CAST(1.05 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 20, 10)) ELSE T3.[ProductPrice] * CAST(T2.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T2.[ShoppingCartId] FROM (([ShoppingCartProduct] T2 WITH (UPDLOCK) INNER JOIN [Product] T3 ON T3.[ProductId] = T2.[ProductId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T3.[CategoryId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000625,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000626", "SELECT [CustomerName], [CustomerAddress], [CustomerPhone], [CountryId] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000626,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000627", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000627,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000628", "SELECT [ShoppingCartId] FROM [ShoppingCart] ORDER BY [ShoppingCartId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000628,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000629", "SELECT T1.[ShoppingCartId], T2.[ProductName], T2.[ProductPrice], T1.[QtyProduct], T3.[CategoryName], T1.[ProductId], T2.[CategoryId] FROM (([ShoppingCartProduct] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Category] T3 ON T3.[CategoryId] = T2.[CategoryId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId and T1.[ProductId] = @ProductId ORDER BY T1.[ShoppingCartId], T1.[ProductId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000629,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000630", "SELECT [ProductName], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000630,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000631", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000631,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000632", "SELECT [ShoppingCartId], [ProductId] FROM [ShoppingCartProduct] WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000632,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000633", "INSERT INTO [ShoppingCartProduct]([ShoppingCartId], [QtyProduct], [ProductId]) VALUES(@ShoppingCartId, @QtyProduct, @ProductId)", GxErrorMask.GX_NOMASK,prmT000633)
             ,new CursorDef("T000634", "UPDATE [ShoppingCartProduct] SET [QtyProduct]=@QtyProduct  WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000634)
             ,new CursorDef("T000635", "DELETE FROM [ShoppingCartProduct]  WHERE [ShoppingCartId] = @ShoppingCartId AND [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000635)
             ,new CursorDef("T000636", "SELECT [ProductName], [ProductPrice], [CategoryId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000636,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000637", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000637,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000638", "SELECT [ShoppingCartId], [ProductId] FROM [ShoppingCartProduct] WHERE [ShoppingCartId] = @ShoppingCartId ORDER BY [ShoppingCartId], [ProductId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000638,11, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 10 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
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
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 26 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 31 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 32 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
