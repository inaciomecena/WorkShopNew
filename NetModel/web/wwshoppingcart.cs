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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wwshoppingcart : GXDataArea
   {
      public wwshoppingcart( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wwshoppingcart( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_39 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_39"), "."));
               nGXsfl_39_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_39_idx"), "."));
               sGXsfl_39_idx = GetPar( "sGXsfl_39_idx");
               AV13Update = GetPar( "Update");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
               AV11ShoppingCartDate = context.localUtil.ParseDateParm( GetPar( "ShoppingCartDate"));
               AV12ShoppingCartDateDelivery = context.localUtil.ParseDateParm( GetPar( "ShoppingCartDateDelivery"));
               AV14ADVANCED_LABEL_TEMPLATE = GetPar( "ADVANCED_LABEL_TEMPLATE");
               AV13Update = GetPar( "Update");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV11ShoppingCartDate, AV12ShoppingCartDateDelivery, AV14ADVANCED_LABEL_TEMPLATE, AV13Update) ;
               AddString( context.getJSONResponse( )) ;
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
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA0G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0G2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 204480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2023521830786", false, true);
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwshoppingcart.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vSHOPPINGCARTDATE", context.localUtil.Format(AV11ShoppingCartDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vSHOPPINGCARTDATEDELIVERY", context.localUtil.Format(AV12ShoppingCartDateDelivery, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
         GxWebStd.gx_hidden_field( context, "SHOPPINGCARTDATEDELIVERYFILTERCONTAINER_Class", StringUtil.RTrim( divShoppingcartdatedeliveryfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0G2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwshoppingcart.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWShoppingCart" ;
      }

      public override string GetPgmdesc( )
      {
         return "Carrinho de Compras" ;
      }

      protected void WB0G0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "BodyContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "TableTopSearch", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", bttBtntoggle_Caption, bttBtntoggle_Jsonclick, 7, bttBtntoggle_Tooltiptext, "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110g1_client"+"'", TempTags, "", 2, "HLP_WWShoppingCart.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Carrinho de Compras", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, 0, "HLP_WWShoppingCart.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-5 col-sm-push-3 WWActionsCell", "Right", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "BtnAdd";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWShoppingCart.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-sm-pull-5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavShoppingcartdate_Internalname, "Shopping Cart Date", "col-sm-3 DateFilterSearchAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_39_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavShoppingcartdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavShoppingcartdate_Internalname, context.localUtil.Format(AV11ShoppingCartDate, "99/99/99"), context.localUtil.Format( AV11ShoppingCartDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavShoppingcartdate_Jsonclick, 0, "DateFilterSearchAttribute", "", "", "", "", 1, edtavShoppingcartdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWShoppingCart.htm");
            GxWebStd.gx_bitmap( context, edtavShoppingcartdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavShoppingcartdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWShoppingCart.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-md-2 WWAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterscontainer_Internalname, 1, 0, "px", 0, "px", divFilterscontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divShoppingcartdatedeliveryfiltercontainer_Internalname, 1, 0, "px", 0, "px", divShoppingcartdatedeliveryfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblshoppingcartdatedeliveryfilter_Internalname, lblLblshoppingcartdatedeliveryfilter_Caption, "", "", lblLblshoppingcartdatedeliveryfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120g1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_WWShoppingCart.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavShoppingcartdatedelivery_Internalname, "Shopping Cart Date Delivery", "col-sm-3 FilterComboAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'" + sGXsfl_39_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavShoppingcartdatedelivery_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavShoppingcartdatedelivery_Internalname, context.localUtil.Format(AV12ShoppingCartDateDelivery, "99/99/99"), context.localUtil.Format( AV12ShoppingCartDateDelivery, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavShoppingcartdatedelivery_Jsonclick, 0, "FilterComboAttribute", "", "", "", "", 1, edtavShoppingcartdatedelivery_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWShoppingCart.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", divGridcell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "ContainerFluid WWAdvancedContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"39\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Cart Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Date") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Delivery Date") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Cliente Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Customer") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Address") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "País Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Country") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Phone") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Cart Total") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridContainer = new GXWebGrid( context);
               }
               else
               {
                  GridContainer.Clear();
               }
               GridContainer.SetWrapped(nGXWrapped);
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16ShoppingCartId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A33ShoppingCartDate, "99/99/99"));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtShoppingCartDate_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A38ShoppingCartDateDelivery, "99/99/99"));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11CustomerId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A20CustomerName));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCustomerName_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A21CustomerAddress);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A9CountryName));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCountryName_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A23CustomerPhone));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A34ShoppingCartFinalPrice, 12, 2, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV13Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 39 )
         {
            wbEnd = 0;
            nRC_GXsfl_39 = (int)(nGXsfl_39_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 39 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0G2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
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
         wbErr = false;
         STRUP0G0( ) ;
      }

      protected void WS0G2( )
      {
         START0G2( ) ;
         EVT0G2( ) ;
      }

      protected void EVT0G2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E130G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_39_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
                              SubsflControlProps_392( ) ;
                              A16ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( edtShoppingCartId_Internalname), ",", "."));
                              A33ShoppingCartDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtShoppingCartDate_Internalname), 0));
                              A38ShoppingCartDateDelivery = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtShoppingCartDateDelivery_Internalname), 0));
                              A11CustomerId = (short)(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ",", "."));
                              A20CustomerName = cgiGet( edtCustomerName_Internalname);
                              A21CustomerAddress = cgiGet( edtCustomerAddress_Internalname);
                              A8CountryId = (short)(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ",", "."));
                              A9CountryName = cgiGet( edtCountryName_Internalname);
                              A23CustomerPhone = cgiGet( edtCustomerPhone_Internalname);
                              A34ShoppingCartFinalPrice = context.localUtil.CToN( cgiGet( edtShoppingCartFinalPrice_Internalname), ",", ".");
                              n34ShoppingCartFinalPrice = false;
                              AV13Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV13Update);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E140G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E150G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E160G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Shoppingcartdate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vSHOPPINGCARTDATE"), 0) != AV11ShoppingCartDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Shoppingcartdatedelivery Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vSHOPPINGCARTDATEDELIVERY"), 0) != AV12ShoppingCartDateDelivery )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0G2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0G2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavShoppingcartdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_392( ) ;
         while ( nGXsfl_39_idx <= nRC_GXsfl_39 )
         {
            sendrow_392( ) ;
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       DateTime AV11ShoppingCartDate ,
                                       DateTime AV12ShoppingCartDateDelivery ,
                                       string AV14ADVANCED_LABEL_TEMPLATE ,
                                       string AV13Update )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E150G2 ();
         GRID_nCurrentRecord = 0;
         RF0G2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SHOPPINGCARTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A16ShoppingCartId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SHOPPINGCARTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16ShoppingCartId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV17Pgmname = "WWShoppingCart";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_39_Refreshing);
      }

      protected void RF0G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E150G2 ();
         nGXsfl_39_idx = 1;
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         bGXsfl_39_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_392( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11ShoppingCartDate ,
                                                 AV12ShoppingCartDateDelivery ,
                                                 A33ShoppingCartDate } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor H000G3 */
            pr_default.execute(0, new Object[] {AV11ShoppingCartDate, AV12ShoppingCartDateDelivery, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A23CustomerPhone = H000G3_A23CustomerPhone[0];
               A9CountryName = H000G3_A9CountryName[0];
               A8CountryId = H000G3_A8CountryId[0];
               A21CustomerAddress = H000G3_A21CustomerAddress[0];
               A20CustomerName = H000G3_A20CustomerName[0];
               A11CustomerId = H000G3_A11CustomerId[0];
               A16ShoppingCartId = H000G3_A16ShoppingCartId[0];
               A34ShoppingCartFinalPrice = H000G3_A34ShoppingCartFinalPrice[0];
               n34ShoppingCartFinalPrice = H000G3_n34ShoppingCartFinalPrice[0];
               A33ShoppingCartDate = H000G3_A33ShoppingCartDate[0];
               A23CustomerPhone = H000G3_A23CustomerPhone[0];
               A8CountryId = H000G3_A8CountryId[0];
               A21CustomerAddress = H000G3_A21CustomerAddress[0];
               A20CustomerName = H000G3_A20CustomerName[0];
               A9CountryName = H000G3_A9CountryName[0];
               A34ShoppingCartFinalPrice = H000G3_A34ShoppingCartFinalPrice[0];
               n34ShoppingCartFinalPrice = H000G3_n34ShoppingCartFinalPrice[0];
               A38ShoppingCartDateDelivery = DateTimeUtil.DAdd(A33ShoppingCartDate,+((int)(5)));
               E160G2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 39;
            WB0G0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0G2( )
      {
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SHOPPINGCARTID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(A16ShoppingCartId), "ZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11ShoppingCartDate ,
                                              AV12ShoppingCartDateDelivery ,
                                              A33ShoppingCartDate } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor H000G5 */
         pr_default.execute(1, new Object[] {AV11ShoppingCartDate, AV12ShoppingCartDateDelivery});
         GRID_nRecordCount = H000G5_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11ShoppingCartDate, AV12ShoppingCartDateDelivery, AV14ADVANCED_LABEL_TEMPLATE, AV13Update) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11ShoppingCartDate, AV12ShoppingCartDateDelivery, AV14ADVANCED_LABEL_TEMPLATE, AV13Update) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11ShoppingCartDate, AV12ShoppingCartDateDelivery, AV14ADVANCED_LABEL_TEMPLATE, AV13Update) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11ShoppingCartDate, AV12ShoppingCartDateDelivery, AV14ADVANCED_LABEL_TEMPLATE, AV13Update) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11ShoppingCartDate, AV12ShoppingCartDateDelivery, AV14ADVANCED_LABEL_TEMPLATE, AV13Update) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void subgrid_varsfromstate( )
      {
         if ( GridState.FilterCount >= 1 )
         {
            AV11ShoppingCartDate = context.localUtil.CToD( GridState.FilterValues("Shoppingcartdate"), 2);
            AssignAttri("", false, "AV11ShoppingCartDate", context.localUtil.Format(AV11ShoppingCartDate, "99/99/99"));
            AV12ShoppingCartDateDelivery = context.localUtil.CToD( GridState.FilterValues("Shoppingcartdatedelivery"), 2);
            AssignAttri("", false, "AV12ShoppingCartDateDelivery", context.localUtil.Format(AV12ShoppingCartDateDelivery, "99/99/99"));
         }
         if ( GridState.CurrentPage > 0 )
         {
            GridPageCount = subGrid_fnc_Pagecount( );
            if ( ( GridPageCount > 0 ) && ( GridPageCount < GridState.CurrentPage ) )
            {
               subgrid_gotopage( GridPageCount) ;
            }
            else
            {
               subgrid_gotopage( ((GridPageCount<0) ? 0 : GridState.CurrentPage)) ;
            }
         }
      }

      protected void subgrid_varstostate( )
      {
         GridState.CurrentPage = subGrid_fnc_Currentpage( );
         GridState.ClearFilterValues();
         GridState.AddFilterValue("ShoppingCartDate", context.localUtil.Format(AV11ShoppingCartDate, "99/99/99"));
         GridState.AddFilterValue("ShoppingCartDateDelivery", context.localUtil.Format(AV12ShoppingCartDateDelivery, "99/99/99"));
      }

      protected void before_start_formulas( )
      {
         AV17Pgmname = "WWShoppingCart";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E140G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), ",", "."));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavShoppingcartdate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Shopping Cart Date"}), 1, "vSHOPPINGCARTDATE");
               GX_FocusControl = edtavShoppingcartdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11ShoppingCartDate = DateTime.MinValue;
               AssignAttri("", false, "AV11ShoppingCartDate", context.localUtil.Format(AV11ShoppingCartDate, "99/99/99"));
            }
            else
            {
               AV11ShoppingCartDate = context.localUtil.CToD( cgiGet( edtavShoppingcartdate_Internalname), 2);
               AssignAttri("", false, "AV11ShoppingCartDate", context.localUtil.Format(AV11ShoppingCartDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavShoppingcartdatedelivery_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Shopping Cart Date Delivery"}), 1, "vSHOPPINGCARTDATEDELIVERY");
               GX_FocusControl = edtavShoppingcartdatedelivery_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12ShoppingCartDateDelivery = DateTime.MinValue;
               AssignAttri("", false, "AV12ShoppingCartDateDelivery", context.localUtil.Format(AV12ShoppingCartDateDelivery, "99/99/99"));
            }
            else
            {
               AV12ShoppingCartDateDelivery = context.localUtil.CToD( cgiGet( edtavShoppingcartdatedelivery_Internalname), 2);
               AssignAttri("", false, "AV12ShoppingCartDateDelivery", context.localUtil.Format(AV12ShoppingCartDateDelivery, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vSHOPPINGCARTDATE"), 2) ) != DateTimeUtil.ResetTime ( AV11ShoppingCartDate ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vSHOPPINGCARTDATEDELIVERY"), 2) ) != DateTimeUtil.ResetTime ( AV12ShoppingCartDateDelivery ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E140G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E140G2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV17Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV17Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV13Update = "Modifica";
         AssignAttri("", false, edtavUpdate_Internalname, AV13Update);
         Form.Caption = "Carrinho de Compras";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
         AssignAttri("", false, "AV14ADVANCED_LABEL_TEMPLATE", AV14ADVANCED_LABEL_TEMPLATE);
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GridState.LoadGridState();
      }

      protected void E150G2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GridState.SaveGridState();
         if ( (DateTime.MinValue==AV12ShoppingCartDateDelivery) )
         {
            lblLblshoppingcartdatedeliveryfilter_Caption = "Delivery Date";
            AssignProp("", false, lblLblshoppingcartdatedeliveryfilter_Internalname, "Caption", lblLblshoppingcartdatedeliveryfilter_Caption, true);
         }
         else
         {
            lblLblshoppingcartdatedeliveryfilter_Caption = StringUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "Delivery Date", context.localUtil.DToC( AV12ShoppingCartDateDelivery, 0, "-"), "", "", "", "", "", "", "");
            AssignProp("", false, lblLblshoppingcartdatedeliveryfilter_Internalname, "Caption", lblLblshoppingcartdatedeliveryfilter_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      private void E160G2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         edtavUpdate_Link = formatLink("shoppingcart.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A16ShoppingCartId,4,0))}, new string[] {"Mode","ShoppingCartId"}) ;
         edtShoppingCartDate_Link = formatLink("viewshoppingcart.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A16ShoppingCartId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ShoppingCartId","TabCode"}) ;
         edtCustomerName_Link = formatLink("viewcustomer.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A11CustomerId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CustomerId","TabCode"}) ;
         edtCountryName_Link = formatLink("viewcountry.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A8CountryId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CountryId","TabCode"}) ;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 39;
         }
         sendrow_392( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_39_Refreshing )
         {
            DoAjaxLoad(39, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E130G2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         CallWebObject(formatLink("shoppingcart.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","ShoppingCartId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV17Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "ShoppingCart";
         AV6Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0G2( ) ;
         WS0G2( ) ;
         WE0G2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023521830944", true, true);
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
         context.AddJavascriptSource("wwshoppingcart.js", "?2023521830944", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_392( )
      {
         edtShoppingCartId_Internalname = "SHOPPINGCARTID_"+sGXsfl_39_idx;
         edtShoppingCartDate_Internalname = "SHOPPINGCARTDATE_"+sGXsfl_39_idx;
         edtShoppingCartDateDelivery_Internalname = "SHOPPINGCARTDATEDELIVERY_"+sGXsfl_39_idx;
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_39_idx;
         edtCustomerName_Internalname = "CUSTOMERNAME_"+sGXsfl_39_idx;
         edtCustomerAddress_Internalname = "CUSTOMERADDRESS_"+sGXsfl_39_idx;
         edtCountryId_Internalname = "COUNTRYID_"+sGXsfl_39_idx;
         edtCountryName_Internalname = "COUNTRYNAME_"+sGXsfl_39_idx;
         edtCustomerPhone_Internalname = "CUSTOMERPHONE_"+sGXsfl_39_idx;
         edtShoppingCartFinalPrice_Internalname = "SHOPPINGCARTFINALPRICE_"+sGXsfl_39_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtShoppingCartId_Internalname = "SHOPPINGCARTID_"+sGXsfl_39_fel_idx;
         edtShoppingCartDate_Internalname = "SHOPPINGCARTDATE_"+sGXsfl_39_fel_idx;
         edtShoppingCartDateDelivery_Internalname = "SHOPPINGCARTDATEDELIVERY_"+sGXsfl_39_fel_idx;
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_39_fel_idx;
         edtCustomerName_Internalname = "CUSTOMERNAME_"+sGXsfl_39_fel_idx;
         edtCustomerAddress_Internalname = "CUSTOMERADDRESS_"+sGXsfl_39_fel_idx;
         edtCountryId_Internalname = "COUNTRYID_"+sGXsfl_39_fel_idx;
         edtCountryName_Internalname = "COUNTRYNAME_"+sGXsfl_39_fel_idx;
         edtCustomerPhone_Internalname = "CUSTOMERPHONE_"+sGXsfl_39_fel_idx;
         edtShoppingCartFinalPrice_Internalname = "SHOPPINGCARTFINALPRICE_"+sGXsfl_39_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         SubsflControlProps_392( ) ;
         WB0G0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_39_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_39_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_39_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtShoppingCartId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16ShoppingCartId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16ShoppingCartId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtShoppingCartId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtShoppingCartDate_Internalname,context.localUtil.Format(A33ShoppingCartDate, "99/99/99"),context.localUtil.Format( A33ShoppingCartDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtShoppingCartDate_Link,(string)"",(string)"",(string)"",(string)edtShoppingCartDate_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtShoppingCartDateDelivery_Internalname,context.localUtil.Format(A38ShoppingCartDateDelivery, "99/99/99"),context.localUtil.Format( A38ShoppingCartDateDelivery, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtShoppingCartDateDelivery_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11CustomerId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A11CustomerId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerName_Internalname,StringUtil.RTrim( A20CustomerName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCustomerName_Link,(string)"",(string)"",(string)"",(string)edtCustomerName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerAddress_Internalname,(string)A21CustomerAddress,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A21CustomerAddress),(string)"_blank",(string)"",(string)"",(string)edtCustomerAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCountryId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A8CountryId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCountryId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCountryName_Internalname,StringUtil.RTrim( A9CountryName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCountryName_Link,(string)"",(string)"",(string)"",(string)edtCountryName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A23CustomerPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerPhone_Internalname,StringUtil.RTrim( A23CustomerPhone),StringUtil.RTrim( context.localUtil.Format( A23CustomerPhone, "(99) 9999-9999")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtCustomerPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtShoppingCartFinalPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A34ShoppingCartFinalPrice, 12, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A34ShoppingCartFinalPrice, "$ ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtShoppingCartFinalPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV13Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"TextActionAttribute",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0G2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtntoggle_Internalname = "BTNTOGGLE";
         lblTitletext_Internalname = "TITLETEXT";
         bttBtninsert_Internalname = "BTNINSERT";
         edtavShoppingcartdate_Internalname = "vSHOPPINGCARTDATE";
         divTabletop_Internalname = "TABLETOP";
         lblLblshoppingcartdatedeliveryfilter_Internalname = "LBLSHOPPINGCARTDATEDELIVERYFILTER";
         edtavShoppingcartdatedelivery_Internalname = "vSHOPPINGCARTDATEDELIVERY";
         divShoppingcartdatedeliveryfiltercontainer_Internalname = "SHOPPINGCARTDATEDELIVERYFILTERCONTAINER";
         divFilterscontainer_Internalname = "FILTERSCONTAINER";
         edtShoppingCartId_Internalname = "SHOPPINGCARTID";
         edtShoppingCartDate_Internalname = "SHOPPINGCARTDATE";
         edtShoppingCartDateDelivery_Internalname = "SHOPPINGCARTDATEDELIVERY";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerName_Internalname = "CUSTOMERNAME";
         edtCustomerAddress_Internalname = "CUSTOMERADDRESS";
         edtCountryId_Internalname = "COUNTRYID";
         edtCountryName_Internalname = "COUNTRYNAME";
         edtCustomerPhone_Internalname = "CUSTOMERPHONE";
         edtShoppingCartFinalPrice_Internalname = "SHOPPINGCARTFINALPRICE";
         edtavUpdate_Internalname = "vUPDATE";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavUpdate_Jsonclick = "";
         edtShoppingCartFinalPrice_Jsonclick = "";
         edtCustomerPhone_Jsonclick = "";
         edtCountryName_Jsonclick = "";
         edtCountryId_Jsonclick = "";
         edtCustomerAddress_Jsonclick = "";
         edtCustomerName_Jsonclick = "";
         edtCustomerId_Jsonclick = "";
         edtShoppingCartDateDelivery_Jsonclick = "";
         edtShoppingCartDate_Jsonclick = "";
         edtShoppingCartId_Jsonclick = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtCountryName_Link = "";
         edtCustomerName_Link = "";
         edtShoppingCartDate_Link = "";
         subGrid_Header = "";
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         divGridcell_Class = "col-xs-12 col-sm-9 col-md-10 WWGridCell";
         edtavShoppingcartdatedelivery_Jsonclick = "";
         edtavShoppingcartdatedelivery_Enabled = 1;
         lblLblshoppingcartdatedeliveryfilter_Caption = "Delivery Date";
         edtavShoppingcartdate_Jsonclick = "";
         edtavShoppingcartdate_Enabled = 1;
         bttBtntoggle_Class = "HideFiltersButton";
         bttBtntoggle_Tooltiptext = "Hide Filters";
         bttBtntoggle_Caption = "Hide Filters";
         divShoppingcartdatedeliveryfiltercontainer_Class = "AdvancedContainerItem";
         divFilterscontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Carrinho de Compras";
         subGrid_Rows = 10;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11ShoppingCartDate',fld:'vSHOPPINGCARTDATE',pic:''},{av:'AV13Update',fld:'vUPDATE',pic:''},{av:'AV12ShoppingCartDateDelivery',fld:'vSHOPPINGCARTDATEDELIVERY',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblLblshoppingcartdatedeliveryfilter_Caption',ctrl:'LBLSHOPPINGCARTDATEDELIVERYFILTER',prop:'Caption'}]}");
         setEventMetadata("'TOGGLE'","{handler:'E110G1',iparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'},{av:'divGridcell_Class',ctrl:'GRIDCELL',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Caption'},{ctrl:'BTNTOGGLE',prop:'Tooltiptext'}]}");
         setEventMetadata("LBLSHOPPINGCARTDATEDELIVERYFILTER.CLICK","{handler:'E120G1',iparms:[{av:'divShoppingcartdatedeliveryfiltercontainer_Class',ctrl:'SHOPPINGCARTDATEDELIVERYFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSHOPPINGCARTDATEDELIVERYFILTER.CLICK",",oparms:[{av:'divShoppingcartdatedeliveryfiltercontainer_Class',ctrl:'SHOPPINGCARTDATEDELIVERYFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E160G2',iparms:[{av:'A16ShoppingCartId',fld:'SHOPPINGCARTID',pic:'ZZZ9',hsh:true},{av:'A11CustomerId',fld:'CUSTOMERID',pic:'ZZZ9'},{av:'A8CountryId',fld:'COUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtShoppingCartDate_Link',ctrl:'SHOPPINGCARTDATE',prop:'Link'},{av:'edtCustomerName_Link',ctrl:'CUSTOMERNAME',prop:'Link'},{av:'edtCountryName_Link',ctrl:'COUNTRYNAME',prop:'Link'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E130G2',iparms:[{av:'A16ShoppingCartId',fld:'SHOPPINGCARTID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11ShoppingCartDate',fld:'vSHOPPINGCARTDATE',pic:''},{av:'AV13Update',fld:'vUPDATE',pic:''},{av:'AV12ShoppingCartDateDelivery',fld:'vSHOPPINGCARTDATEDELIVERY',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'lblLblshoppingcartdatedeliveryfilter_Caption',ctrl:'LBLSHOPPINGCARTDATEDELIVERYFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11ShoppingCartDate',fld:'vSHOPPINGCARTDATE',pic:''},{av:'AV13Update',fld:'vUPDATE',pic:''},{av:'AV12ShoppingCartDateDelivery',fld:'vSHOPPINGCARTDATEDELIVERY',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'lblLblshoppingcartdatedeliveryfilter_Caption',ctrl:'LBLSHOPPINGCARTDATEDELIVERYFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11ShoppingCartDate',fld:'vSHOPPINGCARTDATE',pic:''},{av:'AV13Update',fld:'vUPDATE',pic:''},{av:'AV12ShoppingCartDateDelivery',fld:'vSHOPPINGCARTDATEDELIVERY',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'lblLblshoppingcartdatedeliveryfilter_Caption',ctrl:'LBLSHOPPINGCARTDATEDELIVERYFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11ShoppingCartDate',fld:'vSHOPPINGCARTDATE',pic:''},{av:'AV13Update',fld:'vUPDATE',pic:''},{av:'AV12ShoppingCartDateDelivery',fld:'vSHOPPINGCARTDATEDELIVERY',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'lblLblshoppingcartdatedeliveryfilter_Caption',ctrl:'LBLSHOPPINGCARTDATEDELIVERYFILTER',prop:'Caption'}]}");
         setEventMetadata("VALIDV_SHOPPINGCARTDATE","{handler:'Validv_Shoppingcartdate',iparms:[]");
         setEventMetadata("VALIDV_SHOPPINGCARTDATE",",oparms:[]}");
         setEventMetadata("VALIDV_SHOPPINGCARTDATEDELIVERY","{handler:'Validv_Shoppingcartdatedelivery',iparms:[]");
         setEventMetadata("VALIDV_SHOPPINGCARTDATEDELIVERY",",oparms:[]}");
         setEventMetadata("VALID_SHOPPINGCARTID","{handler:'Valid_Shoppingcartid',iparms:[]");
         setEventMetadata("VALID_SHOPPINGCARTID",",oparms:[]}");
         setEventMetadata("VALID_SHOPPINGCARTDATE","{handler:'Valid_Shoppingcartdate',iparms:[]");
         setEventMetadata("VALID_SHOPPINGCARTDATE",",oparms:[]}");
         setEventMetadata("VALID_CUSTOMERID","{handler:'Valid_Customerid',iparms:[]");
         setEventMetadata("VALID_CUSTOMERID",",oparms:[]}");
         setEventMetadata("VALID_COUNTRYID","{handler:'Valid_Countryid',iparms:[]");
         setEventMetadata("VALID_COUNTRYID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Update',iparms:[]");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV13Update = "";
         AV11ShoppingCartDate = DateTime.MinValue;
         AV12ShoppingCartDateDelivery = DateTime.MinValue;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         lblTitletext_Jsonclick = "";
         bttBtninsert_Jsonclick = "";
         lblLblshoppingcartdatedeliveryfilter_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A33ShoppingCartDate = DateTime.MinValue;
         A38ShoppingCartDateDelivery = DateTime.MinValue;
         A20CustomerName = "";
         A21CustomerAddress = "";
         A9CountryName = "";
         A23CustomerPhone = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GridState = new GXGridStateHandler(context,"Grid",GetPgmname(),subgrid_varsfromstate,subgrid_varstostate);
         AV17Pgmname = "";
         scmdbuf = "";
         H000G3_A23CustomerPhone = new string[] {""} ;
         H000G3_A9CountryName = new string[] {""} ;
         H000G3_A8CountryId = new short[1] ;
         H000G3_A21CustomerAddress = new string[] {""} ;
         H000G3_A20CustomerName = new string[] {""} ;
         H000G3_A11CustomerId = new short[1] ;
         H000G3_A16ShoppingCartId = new short[1] ;
         H000G3_A34ShoppingCartFinalPrice = new decimal[1] ;
         H000G3_n34ShoppingCartFinalPrice = new bool[] {false} ;
         H000G3_A33ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         H000G5_AGRID_nRecordCount = new long[1] ;
         GridRow = new GXWebRow();
         AV9TrnContext = new SdtTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV6Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         gxphoneLink = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwshoppingcart__default(),
            new Object[][] {
                new Object[] {
               H000G3_A23CustomerPhone, H000G3_A9CountryName, H000G3_A8CountryId, H000G3_A21CustomerAddress, H000G3_A20CustomerName, H000G3_A11CustomerId, H000G3_A16ShoppingCartId, H000G3_A34ShoppingCartFinalPrice, H000G3_n34ShoppingCartFinalPrice, H000G3_A33ShoppingCartDate
               }
               , new Object[] {
               H000G5_AGRID_nRecordCount
               }
            }
         );
         AV17Pgmname = "WWShoppingCart";
         /* GeneXus formulas. */
         AV17Pgmname = "WWShoppingCart";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short A16ShoppingCartId ;
      private short A11CustomerId ;
      private short A8CountryId ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int nRC_GXsfl_39 ;
      private int nGXsfl_39_idx=1 ;
      private int subGrid_Rows ;
      private int edtavShoppingcartdate_Enabled ;
      private int edtavShoppingcartdatedelivery_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavUpdate_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GridPageCount ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A34ShoppingCartFinalPrice ;
      private string divFilterscontainer_Class ;
      private string divShoppingcartdatedeliveryfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV13Update ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTabletop_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string bttBtntoggle_Class ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Caption ;
      private string bttBtntoggle_Jsonclick ;
      private string bttBtntoggle_Tooltiptext ;
      private string lblTitletext_Internalname ;
      private string lblTitletext_Jsonclick ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string edtavShoppingcartdate_Internalname ;
      private string edtavShoppingcartdate_Jsonclick ;
      private string divFilterscontainer_Internalname ;
      private string divShoppingcartdatedeliveryfiltercontainer_Internalname ;
      private string lblLblshoppingcartdatedeliveryfilter_Internalname ;
      private string lblLblshoppingcartdatedeliveryfilter_Caption ;
      private string lblLblshoppingcartdatedeliveryfilter_Jsonclick ;
      private string edtavShoppingcartdatedelivery_Internalname ;
      private string edtavShoppingcartdatedelivery_Jsonclick ;
      private string divGridcell_Internalname ;
      private string divGridcell_Class ;
      private string divGridtable_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtShoppingCartDate_Link ;
      private string A20CustomerName ;
      private string edtCustomerName_Link ;
      private string A9CountryName ;
      private string edtCountryName_Link ;
      private string A23CustomerPhone ;
      private string edtavUpdate_Link ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtShoppingCartId_Internalname ;
      private string edtShoppingCartDate_Internalname ;
      private string edtShoppingCartDateDelivery_Internalname ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerName_Internalname ;
      private string edtCustomerAddress_Internalname ;
      private string edtCountryId_Internalname ;
      private string edtCountryName_Internalname ;
      private string edtCustomerPhone_Internalname ;
      private string edtShoppingCartFinalPrice_Internalname ;
      private string edtavUpdate_Internalname ;
      private string AV17Pgmname ;
      private string scmdbuf ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string ROClassString ;
      private string edtShoppingCartId_Jsonclick ;
      private string edtShoppingCartDate_Jsonclick ;
      private string edtShoppingCartDateDelivery_Jsonclick ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerName_Jsonclick ;
      private string edtCustomerAddress_Jsonclick ;
      private string edtCountryId_Jsonclick ;
      private string edtCountryName_Jsonclick ;
      private string gxphoneLink ;
      private string edtCustomerPhone_Jsonclick ;
      private string edtShoppingCartFinalPrice_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private DateTime AV11ShoppingCartDate ;
      private DateTime AV12ShoppingCartDateDelivery ;
      private DateTime A33ShoppingCartDate ;
      private DateTime A38ShoppingCartDateDelivery ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n34ShoppingCartFinalPrice ;
      private bool bGXsfl_39_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string A21CustomerAddress ;
      private GXWebGrid GridContainer ;
      private GXGridStateHandler GridState ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000G3_A23CustomerPhone ;
      private string[] H000G3_A9CountryName ;
      private short[] H000G3_A8CountryId ;
      private string[] H000G3_A21CustomerAddress ;
      private string[] H000G3_A20CustomerName ;
      private short[] H000G3_A11CustomerId ;
      private short[] H000G3_A16ShoppingCartId ;
      private decimal[] H000G3_A34ShoppingCartFinalPrice ;
      private bool[] H000G3_n34ShoppingCartFinalPrice ;
      private DateTime[] H000G3_A33ShoppingCartDate ;
      private long[] H000G5_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxSession AV6Session ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class wwshoppingcart__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000G3( IGxContext context ,
                                             DateTime AV11ShoppingCartDate ,
                                             DateTime AV12ShoppingCartDateDelivery ,
                                             DateTime A33ShoppingCartDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.[CustomerPhone], T3.[CountryName], T2.[CountryId], T2.[CustomerAddress], T2.[CustomerName], T1.[CustomerId], T1.[ShoppingCartId], COALESCE( T4.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice, T1.[ShoppingCartDate]";
         sFromString = " FROM ((([ShoppingCart] T1 INNER JOIN [Customer] T2 ON T2.[CustomerId] = T1.[CustomerId]) INNER JOIN [Country] T3 ON T3.[CountryId] = T2.[CountryId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoryName] = 'Entretenimiento' THEN ( T6.[ProductPrice] * CAST(0.9 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 20, 10)) WHEN T7.[CategoryName] = 'Joyería' THEN ( T6.[ProductPrice] * CAST(1.05 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 20, 10)) ELSE T6.[ProductPrice] * CAST(T5.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T5.[ShoppingCartId] FROM (([ShoppingCartProduct] T5 INNER JOIN [Product] T6 ON T6.[ProductId] = T5.[ProductId]) INNER JOIN [Category] T7 ON T7.[CategoryId] = T6.[CategoryId]) GROUP BY T5.[ShoppingCartId] ) T4 ON T4.[ShoppingCartId] = T1.[ShoppingCartId])";
         sOrderString = "";
         if ( ! (DateTime.MinValue==AV11ShoppingCartDate) )
         {
            AddWhere(sWhereString, "(T1.[ShoppingCartDate] >= @AV11ShoppingCartDate)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV12ShoppingCartDateDelivery) )
         {
            AddWhere(sWhereString, "(( DATEADD( dd,5, T1.[ShoppingCartDate])) >= @AV12ShoppingCartDateDelivery)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         sOrderString += " ORDER BY T1.[ShoppingCartDate]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000G5( IGxContext context ,
                                             DateTime AV11ShoppingCartDate ,
                                             DateTime AV12ShoppingCartDateDelivery ,
                                             DateTime A33ShoppingCartDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([ShoppingCart] T1 INNER JOIN [Customer] T2 ON T2.[CustomerId] = T1.[CustomerId]) INNER JOIN [Country] T3 ON T3.[CountryId] = T2.[CountryId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoryName] = 'Entretenimiento' THEN ( T6.[ProductPrice] * CAST(0.9 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 20, 10)) WHEN T7.[CategoryName] = 'Joyería' THEN ( T6.[ProductPrice] * CAST(1.05 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 20, 10)) ELSE T6.[ProductPrice] * CAST(T5.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T5.[ShoppingCartId] FROM (([ShoppingCartProduct] T5 INNER JOIN [Product] T6 ON T6.[ProductId] = T5.[ProductId]) INNER JOIN [Category] T7 ON T7.[CategoryId] = T6.[CategoryId]) GROUP BY T5.[ShoppingCartId] ) T4 ON T4.[ShoppingCartId] = T1.[ShoppingCartId])";
         if ( ! (DateTime.MinValue==AV11ShoppingCartDate) )
         {
            AddWhere(sWhereString, "(T1.[ShoppingCartDate] >= @AV11ShoppingCartDate)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV12ShoppingCartDateDelivery) )
         {
            AddWhere(sWhereString, "(( DATEADD( dd,5, T1.[ShoppingCartDate])) >= @AV12ShoppingCartDateDelivery)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000G3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] );
               case 1 :
                     return conditional_H000G5(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH000G3;
          prmH000G3 = new Object[] {
          new ParDef("@AV11ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@AV12ShoppingCartDateDelivery",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000G5;
          prmH000G5 = new Object[] {
          new ParDef("@AV11ShoppingCartDate",GXType.Date,8,0) ,
          new ParDef("@AV12ShoppingCartDateDelivery",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000G5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G5,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
