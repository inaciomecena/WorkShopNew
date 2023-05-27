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
   public class shoppingcartgeneral : GXWebComponent
   {
      public shoppingcartgeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
      }

      public shoppingcartgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_ShoppingCartId )
      {
         this.A16ShoppingCartId = aP0_ShoppingCartId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ShoppingCartId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A16ShoppingCartId = (short)(NumberUtil.Val( GetPar( "ShoppingCartId"), "."));
                  AssignAttri(sPrefix, false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A16ShoppingCartId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "ShoppingCartId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ShoppingCartId");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ShoppingCartGeneral";
               context.Gx_err = 0;
               /* Using cursor H000O3 */
               pr_default.execute(0, new Object[] {A16ShoppingCartId});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A34ShoppingCartFinalPrice = H000O3_A34ShoppingCartFinalPrice[0];
                  n34ShoppingCartFinalPrice = H000O3_n34ShoppingCartFinalPrice[0];
                  AssignAttri(sPrefix, false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
               }
               else
               {
                  A34ShoppingCartFinalPrice = 0;
                  n34ShoppingCartFinalPrice = false;
                  AssignAttri(sPrefix, false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
               }
               pr_default.close(0);
               WS0O2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Shopping Cart General") ;
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 204480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202352622351245", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 204480), false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("shoppingcartgeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A16ShoppingCartId,4,0))}, new string[] {"ShoppingCartId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ShoppingCartGeneral");
         forbiddenHiddens.Add("CustomerId", context.localUtil.Format( (decimal)(A11CustomerId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("shoppingcartgeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA16ShoppingCartId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA16ShoppingCartId), 4, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm0O2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "ShoppingCartGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Shopping Cart General" ;
      }

      protected void WB0O0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "shoppingcartgeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewActionsCell", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group WWViewActions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modifica", bttBtnupdate_Jsonclick, 7, "Modifica", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110o1_client"+"'", TempTags, "", 2, "HLP_ShoppingCartGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtShoppingCartId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtShoppingCartId_Internalname, "Cart Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtShoppingCartId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16ShoppingCartId), 4, 0, ",", "")), StringUtil.LTrim( ((edtShoppingCartId_Enabled!=0) ? context.localUtil.Format( (decimal)(A16ShoppingCartId), "ZZZ9") : context.localUtil.Format( (decimal)(A16ShoppingCartId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtShoppingCartId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtShoppingCartDate_Internalname, "Cart Date", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtShoppingCartDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtShoppingCartDate_Internalname, context.localUtil.Format(A33ShoppingCartDate, "99/99/99"), context.localUtil.Format( A33ShoppingCartDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartDate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtShoppingCartDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ShoppingCartGeneral.htm");
            GxWebStd.gx_bitmap( context, edtShoppingCartDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtShoppingCartDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtShoppingCartDateDelivery_Internalname, "Date Delivery", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtShoppingCartDateDelivery_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtShoppingCartDateDelivery_Internalname, context.localUtil.Format(A38ShoppingCartDateDelivery, "99/99/99"), context.localUtil.Format( A38ShoppingCartDateDelivery, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartDateDelivery_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtShoppingCartDateDelivery_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ShoppingCartGeneral.htm");
            GxWebStd.gx_bitmap( context, edtShoppingCartDateDelivery_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtShoppingCartDateDelivery_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCustomerId_Internalname, "Cliente Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCustomerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11CustomerId), 4, 0, ",", "")), StringUtil.LTrim( ((edtCustomerId_Enabled!=0) ? context.localUtil.Format( (decimal)(A11CustomerId), "ZZZ9") : context.localUtil.Format( (decimal)(A11CustomerId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCustomerId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCustomerName_Internalname, "Nome", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCustomerName_Internalname, StringUtil.RTrim( A20CustomerName), StringUtil.RTrim( context.localUtil.Format( A20CustomerName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtCustomerName_Link, "", "", "", edtCustomerName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCustomerName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCustomerAddress_Internalname, "Endereço", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtCustomerAddress_Internalname, A21CustomerAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A21CustomerAddress), "", 0, 1, edtCustomerAddress_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCountryId_Internalname, "País Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ",", "")), StringUtil.LTrim( ((edtCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A8CountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A8CountryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCountryName_Internalname, "País", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, StringUtil.RTrim( A9CountryName), StringUtil.RTrim( context.localUtil.Format( A9CountryName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtCountryName_Link, "", "", "", edtCountryName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtShoppingCartFinalPrice_Internalname, "Final", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtShoppingCartFinalPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A34ShoppingCartFinalPrice, 13, 2, ",", "")), StringUtil.LTrim( ((edtShoppingCartFinalPrice_Enabled!=0) ? context.localUtil.Format( A34ShoppingCartFinalPrice, "R$ ZZZZZZ9.99") : context.localUtil.Format( A34ShoppingCartFinalPrice, "R$ ZZZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShoppingCartFinalPrice_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtShoppingCartFinalPrice_Enabled, 0, "text", "", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ShoppingCartGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCustomerPhone_Internalname, "Telefone", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A23CustomerPhone);
            }
            GxWebStd.gx_single_line_edit( context, edtCustomerPhone_Internalname, StringUtil.RTrim( A23CustomerPhone), StringUtil.RTrim( context.localUtil.Format( A23CustomerPhone, "(99) 9999-9999")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCustomerPhone_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCustomerPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_ShoppingCartGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0O2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 17_0_9-159740", 0) ;
               }
               Form.Meta.addItem("description", "Shopping Cart General", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0O0( ) ;
            }
         }
      }

      protected void WS0O2( )
      {
         START0O2( ) ;
         EVT0O2( ) ;
      }

      protected void EVT0O2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E120O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E130O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE0O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0O2( ) ;
            }
         }
      }

      protected void PA0O2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
         RF0O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ShoppingCartGeneral";
         context.Gx_err = 0;
      }

      protected void RF0O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000O5 */
            pr_default.execute(1, new Object[] {A16ShoppingCartId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A23CustomerPhone = H000O5_A23CustomerPhone[0];
               AssignAttri(sPrefix, false, "A23CustomerPhone", A23CustomerPhone);
               A9CountryName = H000O5_A9CountryName[0];
               AssignAttri(sPrefix, false, "A9CountryName", A9CountryName);
               A8CountryId = H000O5_A8CountryId[0];
               AssignAttri(sPrefix, false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
               A21CustomerAddress = H000O5_A21CustomerAddress[0];
               AssignAttri(sPrefix, false, "A21CustomerAddress", A21CustomerAddress);
               A20CustomerName = H000O5_A20CustomerName[0];
               AssignAttri(sPrefix, false, "A20CustomerName", A20CustomerName);
               A11CustomerId = H000O5_A11CustomerId[0];
               AssignAttri(sPrefix, false, "A11CustomerId", StringUtil.LTrimStr( (decimal)(A11CustomerId), 4, 0));
               A34ShoppingCartFinalPrice = H000O5_A34ShoppingCartFinalPrice[0];
               n34ShoppingCartFinalPrice = H000O5_n34ShoppingCartFinalPrice[0];
               AssignAttri(sPrefix, false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
               A33ShoppingCartDate = H000O5_A33ShoppingCartDate[0];
               AssignAttri(sPrefix, false, "A33ShoppingCartDate", context.localUtil.Format(A33ShoppingCartDate, "99/99/99"));
               A23CustomerPhone = H000O5_A23CustomerPhone[0];
               AssignAttri(sPrefix, false, "A23CustomerPhone", A23CustomerPhone);
               A8CountryId = H000O5_A8CountryId[0];
               AssignAttri(sPrefix, false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
               A21CustomerAddress = H000O5_A21CustomerAddress[0];
               AssignAttri(sPrefix, false, "A21CustomerAddress", A21CustomerAddress);
               A20CustomerName = H000O5_A20CustomerName[0];
               AssignAttri(sPrefix, false, "A20CustomerName", A20CustomerName);
               A9CountryName = H000O5_A9CountryName[0];
               AssignAttri(sPrefix, false, "A9CountryName", A9CountryName);
               A34ShoppingCartFinalPrice = H000O5_A34ShoppingCartFinalPrice[0];
               n34ShoppingCartFinalPrice = H000O5_n34ShoppingCartFinalPrice[0];
               AssignAttri(sPrefix, false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
               A38ShoppingCartDateDelivery = DateTimeUtil.DAdd(A33ShoppingCartDate,+((int)(5)));
               AssignAttri(sPrefix, false, "A38ShoppingCartDateDelivery", context.localUtil.Format(A38ShoppingCartDateDelivery, "99/99/99"));
               /* Execute user event: Load */
               E130O2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB0O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0O2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ShoppingCartGeneral";
         context.Gx_err = 0;
         /* Using cursor H000O7 */
         pr_default.execute(2, new Object[] {A16ShoppingCartId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A34ShoppingCartFinalPrice = H000O7_A34ShoppingCartFinalPrice[0];
            n34ShoppingCartFinalPrice = H000O7_n34ShoppingCartFinalPrice[0];
            AssignAttri(sPrefix, false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         }
         else
         {
            A34ShoppingCartFinalPrice = 0;
            n34ShoppingCartFinalPrice = false;
            AssignAttri(sPrefix, false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
         }
         pr_default.close(2);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120O2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA16ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA16ShoppingCartId"), ",", "."));
            /* Read variables values. */
            A33ShoppingCartDate = context.localUtil.CToD( cgiGet( edtShoppingCartDate_Internalname), 2);
            AssignAttri(sPrefix, false, "A33ShoppingCartDate", context.localUtil.Format(A33ShoppingCartDate, "99/99/99"));
            A38ShoppingCartDateDelivery = context.localUtil.CToD( cgiGet( edtShoppingCartDateDelivery_Internalname), 2);
            AssignAttri(sPrefix, false, "A38ShoppingCartDateDelivery", context.localUtil.Format(A38ShoppingCartDateDelivery, "99/99/99"));
            A11CustomerId = (short)(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A11CustomerId", StringUtil.LTrimStr( (decimal)(A11CustomerId), 4, 0));
            A20CustomerName = cgiGet( edtCustomerName_Internalname);
            AssignAttri(sPrefix, false, "A20CustomerName", A20CustomerName);
            A21CustomerAddress = cgiGet( edtCustomerAddress_Internalname);
            AssignAttri(sPrefix, false, "A21CustomerAddress", A21CustomerAddress);
            A8CountryId = (short)(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            A9CountryName = cgiGet( edtCountryName_Internalname);
            AssignAttri(sPrefix, false, "A9CountryName", A9CountryName);
            A34ShoppingCartFinalPrice = context.localUtil.CToN( cgiGet( edtShoppingCartFinalPrice_Internalname), ",", ".");
            n34ShoppingCartFinalPrice = false;
            AssignAttri(sPrefix, false, "A34ShoppingCartFinalPrice", StringUtil.LTrimStr( A34ShoppingCartFinalPrice, 10, 2));
            A23CustomerPhone = cgiGet( edtCustomerPhone_Internalname);
            AssignAttri(sPrefix, false, "A23CustomerPhone", A23CustomerPhone);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ShoppingCartGeneral");
            A11CustomerId = (short)(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A11CustomerId", StringUtil.LTrimStr( (decimal)(A11CustomerId), 4, 0));
            forbiddenHiddens.Add("CustomerId", context.localUtil.Format( (decimal)(A11CustomerId), "ZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("shoppingcartgeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E120O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120O2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E130O2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtCustomerName_Link = formatLink("viewcustomer.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A11CustomerId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CustomerId","TabCode"}) ;
         AssignProp(sPrefix, false, edtCustomerName_Internalname, "Link", edtCustomerName_Link, true);
         edtCountryName_Link = formatLink("viewcountry.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A8CountryId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CountryId","TabCode"}) ;
         AssignProp(sPrefix, false, edtCountryName_Internalname, "Link", edtCountryName_Link, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "ShoppingCart";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "ShoppingCartId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6ShoppingCartId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A16ShoppingCartId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
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
         PA0O2( ) ;
         WS0O2( ) ;
         WE0O2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA16ShoppingCartId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0O2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "shoppingcartgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0O2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A16ShoppingCartId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
         }
         wcpOA16ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA16ShoppingCartId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A16ShoppingCartId != wcpOA16ShoppingCartId ) ) )
         {
            setjustcreated();
         }
         wcpOA16ShoppingCartId = A16ShoppingCartId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA16ShoppingCartId = cgiGet( sPrefix+"A16ShoppingCartId_CTRL");
         if ( StringUtil.Len( sCtrlA16ShoppingCartId) > 0 )
         {
            A16ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( sCtrlA16ShoppingCartId), ",", "."));
            AssignAttri(sPrefix, false, "A16ShoppingCartId", StringUtil.LTrimStr( (decimal)(A16ShoppingCartId), 4, 0));
         }
         else
         {
            A16ShoppingCartId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A16ShoppingCartId_PARM"), ",", "."));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0O2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A16ShoppingCartId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16ShoppingCartId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA16ShoppingCartId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A16ShoppingCartId_CTRL", StringUtil.RTrim( sCtrlA16ShoppingCartId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202352622351362", true, true);
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
         context.AddJavascriptSource("shoppingcartgeneral.js", "?202352622351362", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         edtShoppingCartId_Internalname = sPrefix+"SHOPPINGCARTID";
         edtShoppingCartDate_Internalname = sPrefix+"SHOPPINGCARTDATE";
         edtShoppingCartDateDelivery_Internalname = sPrefix+"SHOPPINGCARTDATEDELIVERY";
         edtCustomerId_Internalname = sPrefix+"CUSTOMERID";
         edtCustomerName_Internalname = sPrefix+"CUSTOMERNAME";
         edtCustomerAddress_Internalname = sPrefix+"CUSTOMERADDRESS";
         edtCountryId_Internalname = sPrefix+"COUNTRYID";
         edtCountryName_Internalname = sPrefix+"COUNTRYNAME";
         edtShoppingCartFinalPrice_Internalname = sPrefix+"SHOPPINGCARTFINALPRICE";
         edtCustomerPhone_Internalname = sPrefix+"CUSTOMERPHONE";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtCustomerPhone_Jsonclick = "";
         edtCustomerPhone_Enabled = 0;
         edtShoppingCartFinalPrice_Jsonclick = "";
         edtShoppingCartFinalPrice_Enabled = 0;
         edtCountryName_Jsonclick = "";
         edtCountryName_Link = "";
         edtCountryName_Enabled = 0;
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 0;
         edtCustomerAddress_Enabled = 0;
         edtCustomerName_Jsonclick = "";
         edtCustomerName_Link = "";
         edtCustomerName_Enabled = 0;
         edtCustomerId_Jsonclick = "";
         edtCustomerId_Enabled = 0;
         edtShoppingCartDateDelivery_Jsonclick = "";
         edtShoppingCartDateDelivery_Enabled = 0;
         edtShoppingCartDate_Jsonclick = "";
         edtShoppingCartDate_Enabled = 0;
         edtShoppingCartId_Jsonclick = "";
         edtShoppingCartId_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A16ShoppingCartId',fld:'SHOPPINGCARTID',pic:'ZZZ9'},{av:'A11CustomerId',fld:'CUSTOMERID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E110O1',iparms:[{av:'A16ShoppingCartId',fld:'SHOPPINGCARTID',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("VALID_SHOPPINGCARTID","{handler:'Valid_Shoppingcartid',iparms:[]");
         setEventMetadata("VALID_SHOPPINGCARTID",",oparms:[]}");
         setEventMetadata("VALID_SHOPPINGCARTDATE","{handler:'Valid_Shoppingcartdate',iparms:[]");
         setEventMetadata("VALID_SHOPPINGCARTDATE",",oparms:[]}");
         setEventMetadata("VALID_CUSTOMERID","{handler:'Valid_Customerid',iparms:[]");
         setEventMetadata("VALID_CUSTOMERID",",oparms:[]}");
         setEventMetadata("VALID_COUNTRYID","{handler:'Valid_Countryid',iparms:[]");
         setEventMetadata("VALID_COUNTRYID",",oparms:[]}");
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
         sPrefix = "";
         AV13Pgmname = "";
         scmdbuf = "";
         H000O3_A34ShoppingCartFinalPrice = new decimal[1] ;
         H000O3_n34ShoppingCartFinalPrice = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         A33ShoppingCartDate = DateTime.MinValue;
         A38ShoppingCartDateDelivery = DateTime.MinValue;
         A20CustomerName = "";
         A21CustomerAddress = "";
         A9CountryName = "";
         gxphoneLink = "";
         A23CustomerPhone = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H000O5_A16ShoppingCartId = new short[1] ;
         H000O5_A23CustomerPhone = new string[] {""} ;
         H000O5_A9CountryName = new string[] {""} ;
         H000O5_A8CountryId = new short[1] ;
         H000O5_A21CustomerAddress = new string[] {""} ;
         H000O5_A20CustomerName = new string[] {""} ;
         H000O5_A11CustomerId = new short[1] ;
         H000O5_A34ShoppingCartFinalPrice = new decimal[1] ;
         H000O5_n34ShoppingCartFinalPrice = new bool[] {false} ;
         H000O5_A33ShoppingCartDate = new DateTime[] {DateTime.MinValue} ;
         H000O7_A34ShoppingCartFinalPrice = new decimal[1] ;
         H000O7_n34ShoppingCartFinalPrice = new bool[] {false} ;
         hsh = "";
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA16ShoppingCartId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.shoppingcartgeneral__default(),
            new Object[][] {
                new Object[] {
               H000O3_A34ShoppingCartFinalPrice, H000O3_n34ShoppingCartFinalPrice
               }
               , new Object[] {
               H000O5_A16ShoppingCartId, H000O5_A23CustomerPhone, H000O5_A9CountryName, H000O5_A8CountryId, H000O5_A21CustomerAddress, H000O5_A20CustomerName, H000O5_A11CustomerId, H000O5_A34ShoppingCartFinalPrice, H000O5_n34ShoppingCartFinalPrice, H000O5_A33ShoppingCartDate
               }
               , new Object[] {
               H000O7_A34ShoppingCartFinalPrice, H000O7_n34ShoppingCartFinalPrice
               }
            }
         );
         AV13Pgmname = "ShoppingCartGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ShoppingCartGeneral";
         context.Gx_err = 0;
      }

      private short A16ShoppingCartId ;
      private short wcpOA16ShoppingCartId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short A11CustomerId ;
      private short wbEnd ;
      private short wbStart ;
      private short A8CountryId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6ShoppingCartId ;
      private short nGXWrapped ;
      private int edtShoppingCartId_Enabled ;
      private int edtShoppingCartDate_Enabled ;
      private int edtShoppingCartDateDelivery_Enabled ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerName_Enabled ;
      private int edtCustomerAddress_Enabled ;
      private int edtCountryId_Enabled ;
      private int edtCountryName_Enabled ;
      private int edtShoppingCartFinalPrice_Enabled ;
      private int edtCustomerPhone_Enabled ;
      private int idxLst ;
      private decimal A34ShoppingCartFinalPrice ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string scmdbuf ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtShoppingCartId_Internalname ;
      private string edtShoppingCartId_Jsonclick ;
      private string edtShoppingCartDate_Internalname ;
      private string edtShoppingCartDate_Jsonclick ;
      private string edtShoppingCartDateDelivery_Internalname ;
      private string edtShoppingCartDateDelivery_Jsonclick ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerName_Internalname ;
      private string A20CustomerName ;
      private string edtCustomerName_Link ;
      private string edtCustomerName_Jsonclick ;
      private string edtCustomerAddress_Internalname ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string edtCountryName_Internalname ;
      private string A9CountryName ;
      private string edtCountryName_Link ;
      private string edtCountryName_Jsonclick ;
      private string edtShoppingCartFinalPrice_Internalname ;
      private string edtShoppingCartFinalPrice_Jsonclick ;
      private string edtCustomerPhone_Internalname ;
      private string gxphoneLink ;
      private string A23CustomerPhone ;
      private string edtCustomerPhone_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private string sCtrlA16ShoppingCartId ;
      private DateTime A33ShoppingCartDate ;
      private DateTime A38ShoppingCartDateDelivery ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n34ShoppingCartFinalPrice ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A21CustomerAddress ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H000O3_A34ShoppingCartFinalPrice ;
      private bool[] H000O3_n34ShoppingCartFinalPrice ;
      private short[] H000O5_A16ShoppingCartId ;
      private string[] H000O5_A23CustomerPhone ;
      private string[] H000O5_A9CountryName ;
      private short[] H000O5_A8CountryId ;
      private string[] H000O5_A21CustomerAddress ;
      private string[] H000O5_A20CustomerName ;
      private short[] H000O5_A11CustomerId ;
      private decimal[] H000O5_A34ShoppingCartFinalPrice ;
      private bool[] H000O5_n34ShoppingCartFinalPrice ;
      private DateTime[] H000O5_A33ShoppingCartDate ;
      private decimal[] H000O7_A34ShoppingCartFinalPrice ;
      private bool[] H000O7_n34ShoppingCartFinalPrice ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class shoppingcartgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000O3;
          prmH000O3 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmH000O5;
          prmH000O5 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          Object[] prmH000O7;
          prmH000O7 = new Object[] {
          new ParDef("@ShoppingCartId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000O3", "SELECT COALESCE( T1.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM (SELECT SUM(CASE  WHEN T4.[CategoryName] = 'Entreterimento' THEN ( T3.[ProductPrice] - T3.[ProductPrice] * CAST(0.10 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 18, 10)) WHEN T4.[CategoryName] = 'Joalheria' THEN ( T3.[ProductPrice] + T3.[ProductPrice] * CAST(0.05 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 18, 10)) ELSE T3.[ProductPrice] * CAST(T2.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T2.[ShoppingCartId] FROM (([ShoppingCartProduct] T2 INNER JOIN [Product] T3 ON T3.[ProductId] = T2.[ProductId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T3.[CategoryId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000O3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000O5", "SELECT T1.[ShoppingCartId], T2.[CustomerPhone], T3.[CountryName], T2.[CountryId], T2.[CustomerAddress], T2.[CustomerName], T1.[CustomerId], COALESCE( T4.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice, T1.[ShoppingCartDate] FROM ((([ShoppingCart] T1 INNER JOIN [Customer] T2 ON T2.[CustomerId] = T1.[CustomerId]) INNER JOIN [Country] T3 ON T3.[CountryId] = T2.[CountryId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoryName] = 'Entreterimento' THEN ( T6.[ProductPrice] - T6.[ProductPrice] * CAST(0.10 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 18, 10)) WHEN T7.[CategoryName] = 'Joalheria' THEN ( T6.[ProductPrice] + T6.[ProductPrice] * CAST(0.05 AS decimal( 18, 10))) * CAST(T5.[QtyProduct] AS decimal( 18, 10)) ELSE T6.[ProductPrice] * CAST(T5.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T5.[ShoppingCartId] FROM (([ShoppingCartProduct] T5 INNER JOIN [Product] T6 ON T6.[ProductId] = T5.[ProductId]) INNER JOIN [Category] T7 ON T7.[CategoryId] = T6.[CategoryId]) GROUP BY T5.[ShoppingCartId] ) T4 ON T4.[ShoppingCartId] = T1.[ShoppingCartId]) WHERE T1.[ShoppingCartId] = @ShoppingCartId ORDER BY T1.[ShoppingCartId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000O5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000O7", "SELECT COALESCE( T1.[ShoppingCartFinalPrice], 0) AS ShoppingCartFinalPrice FROM (SELECT SUM(CASE  WHEN T4.[CategoryName] = 'Entreterimento' THEN ( T3.[ProductPrice] - T3.[ProductPrice] * CAST(0.10 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 18, 10)) WHEN T4.[CategoryName] = 'Joalheria' THEN ( T3.[ProductPrice] + T3.[ProductPrice] * CAST(0.05 AS decimal( 18, 10))) * CAST(T2.[QtyProduct] AS decimal( 18, 10)) ELSE T3.[ProductPrice] * CAST(T2.[QtyProduct] AS decimal( 18, 10)) END) AS ShoppingCartFinalPrice, T2.[ShoppingCartId] FROM (([ShoppingCartProduct] T2 INNER JOIN [Product] T3 ON T3.[ProductId] = T2.[ProductId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T3.[CategoryId]) GROUP BY T2.[ShoppingCartId] ) T1 WHERE T1.[ShoppingCartId] = @ShoppingCartId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000O7,1, GxCacheFrequency.OFF ,true,true )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
