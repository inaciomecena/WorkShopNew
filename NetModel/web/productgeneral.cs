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
   public class productgeneral : GXWebComponent
   {
      public productgeneral( )
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

      public productgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_ProductId )
      {
         this.A12ProductId = aP0_ProductId;
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
               gxfirstwebparm = GetFirstPar( "ProductId");
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
                  A12ProductId = (short)(NumberUtil.Val( GetPar( "ProductId"), "."));
                  AssignAttri(sPrefix, false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A12ProductId});
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
                  gxfirstwebparm = GetFirstPar( "ProductId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ProductId");
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
            PA1I2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ProductGeneral";
               context.Gx_err = 0;
               WS1I2( ) ;
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
            context.SendWebValue( "Product General") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202352115132857", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("productgeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A12ProductId,4,0))}, new string[] {"ProductId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ProductGeneral");
         forbiddenHiddens.Add("CategoryId", context.localUtil.Format( (decimal)(A6CategoryId), "ZZZ9"));
         forbiddenHiddens.Add("SellerId", context.localUtil.Format( (decimal)(A10SellerId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("productgeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA12ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA12ProductId), 4, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm1I2( )
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
         return "ProductGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Product General" ;
      }

      protected void WB1I0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "productgeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modifica", bttBtnupdate_Jsonclick, 7, "Modifica", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e111i1_client"+"'", TempTags, "", 2, "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 7, "Eliminar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e121i1_client"+"'", TempTags, "", 2, "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductId_Internalname, "Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ",", "")), StringUtil.LTrim( ((edtProductId_Enabled!=0) ? context.localUtil.Format( (decimal)(A12ProductId), "ZZZ9") : context.localUtil.Format( (decimal)(A12ProductId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductName_Internalname, "do Produto", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductName_Internalname, StringUtil.RTrim( A13ProductName), StringUtil.RTrim( context.localUtil.Format( A13ProductName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductDescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductDescription_Internalname, "do Produto", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductDescription_Internalname, StringUtil.RTrim( A26ProductDescription), StringUtil.RTrim( context.localUtil.Format( A26ProductDescription, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductDescription_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductDescription_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductPrice_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductPrice_Internalname, "Preço", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 11, 2, ",", "")), StringUtil.LTrim( ((edtProductPrice_Enabled!=0) ? context.localUtil.Format( A27ProductPrice, "R$ ZZZZ9.99") : context.localUtil.Format( A27ProductPrice, "R$ ZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductPrice_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductPrice_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductCountryID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductCountryID_Internalname, "ID", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductCountryID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14ProductCountryID), 4, 0, ",", "")), StringUtil.LTrim( ((edtProductCountryID_Enabled!=0) ? context.localUtil.Format( (decimal)(A14ProductCountryID), "ZZZ9") : context.localUtil.Format( (decimal)(A14ProductCountryID), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCountryID_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductCountryID_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductCountryName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductCountryName_Internalname, "Nome", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductCountryName_Internalname, StringUtil.RTrim( A39ProductCountryName), StringUtil.RTrim( context.localUtil.Format( A39ProductCountryName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCountryName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductCountryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCategoryId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCategoryId_Internalname, "Categoria Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CategoryId), 4, 0, ",", "")), StringUtil.LTrim( ((edtCategoryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A6CategoryId), "ZZZ9") : context.localUtil.Format( (decimal)(A6CategoryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCategoryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCategoryName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCategoryName_Internalname, "Noma da Categoria", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCategoryName_Internalname, StringUtil.RTrim( A7CategoryName), StringUtil.RTrim( context.localUtil.Format( A7CategoryName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtCategoryName_Link, "", "", "", edtCategoryName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCategoryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSellerId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSellerId_Internalname, "Vendedor Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSellerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SellerId), 4, 0, ",", "")), StringUtil.LTrim( ((edtSellerId_Enabled!=0) ? context.localUtil.Format( (decimal)(A10SellerId), "ZZZ9") : context.localUtil.Format( (decimal)(A10SellerId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSellerId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtSellerId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ProductGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtSellerName_Internalname, "Vendedor Nome", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSellerName_Internalname, StringUtil.RTrim( A18SellerName), StringUtil.RTrim( context.localUtil.Format( A18SellerName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSellerName_Link, "", "", "", edtSellerName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtSellerName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ProductGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ",", "")), StringUtil.LTrim( ((edtCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A8CountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A8CountryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ProductGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, StringUtil.RTrim( A9CountryName), StringUtil.RTrim( context.localUtil.Format( A9CountryName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtCountryName_Link, "", "", "", edtCountryName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImagestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Foto", "col-sm-3 ReadonlyAttributeLabel ReadonlyResponsiveImageAttributeLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
            StyleString = "";
            A28ProductPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.PathToRelativeUrl( A28ProductPhoto));
            GxWebStd.gx_bitmap( context, imgProductPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A28ProductPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Foto", "col-sm-3 ReadonlyAttributeLabel ReadonlyResponsiveImageAttributeLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
            StyleString = "";
            A19SellerPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001SellerPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.PathToRelativeUrl( A19SellerPhoto));
            GxWebStd.gx_bitmap( context, imgSellerPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A19SellerPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_ProductGeneral.htm");
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

      protected void START1I2( )
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
               Form.Meta.addItem("description", "Product General", 0) ;
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
               STRUP1I0( ) ;
            }
         }
      }

      protected void WS1I2( )
      {
         START1I2( ) ;
         EVT1I2( ) ;
      }

      protected void EVT1I2( )
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
                                 STRUP1I0( ) ;
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
                                 STRUP1I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E131I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E141I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1I0( ) ;
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
                                 STRUP1I0( ) ;
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

      protected void WE1I2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1I2( ) ;
            }
         }
      }

      protected void PA1I2( )
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
         RF1I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ProductGeneral";
         context.Gx_err = 0;
      }

      protected void RF1I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H001I2 */
            pr_default.execute(0, new Object[] {A12ProductId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A40001SellerPhoto_GXI = H001I2_A40001SellerPhoto_GXI[0];
               AssignProp(sPrefix, false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
               AssignProp(sPrefix, false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
               A40000ProductPhoto_GXI = H001I2_A40000ProductPhoto_GXI[0];
               AssignProp(sPrefix, false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), true);
               AssignProp(sPrefix, false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
               A9CountryName = H001I2_A9CountryName[0];
               AssignAttri(sPrefix, false, "A9CountryName", A9CountryName);
               A8CountryId = H001I2_A8CountryId[0];
               AssignAttri(sPrefix, false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
               A18SellerName = H001I2_A18SellerName[0];
               AssignAttri(sPrefix, false, "A18SellerName", A18SellerName);
               A10SellerId = H001I2_A10SellerId[0];
               AssignAttri(sPrefix, false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
               A7CategoryName = H001I2_A7CategoryName[0];
               AssignAttri(sPrefix, false, "A7CategoryName", A7CategoryName);
               A6CategoryId = H001I2_A6CategoryId[0];
               AssignAttri(sPrefix, false, "A6CategoryId", StringUtil.LTrimStr( (decimal)(A6CategoryId), 4, 0));
               A39ProductCountryName = H001I2_A39ProductCountryName[0];
               AssignAttri(sPrefix, false, "A39ProductCountryName", A39ProductCountryName);
               A14ProductCountryID = H001I2_A14ProductCountryID[0];
               AssignAttri(sPrefix, false, "A14ProductCountryID", StringUtil.LTrimStr( (decimal)(A14ProductCountryID), 4, 0));
               A27ProductPrice = H001I2_A27ProductPrice[0];
               AssignAttri(sPrefix, false, "A27ProductPrice", StringUtil.LTrimStr( A27ProductPrice, 8, 2));
               A26ProductDescription = H001I2_A26ProductDescription[0];
               AssignAttri(sPrefix, false, "A26ProductDescription", A26ProductDescription);
               A13ProductName = H001I2_A13ProductName[0];
               AssignAttri(sPrefix, false, "A13ProductName", A13ProductName);
               A19SellerPhoto = H001I2_A19SellerPhoto[0];
               AssignAttri(sPrefix, false, "A19SellerPhoto", A19SellerPhoto);
               AssignProp(sPrefix, false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
               AssignProp(sPrefix, false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
               A28ProductPhoto = H001I2_A28ProductPhoto[0];
               AssignAttri(sPrefix, false, "A28ProductPhoto", A28ProductPhoto);
               AssignProp(sPrefix, false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), true);
               AssignProp(sPrefix, false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
               A40001SellerPhoto_GXI = H001I2_A40001SellerPhoto_GXI[0];
               AssignProp(sPrefix, false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
               AssignProp(sPrefix, false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
               A8CountryId = H001I2_A8CountryId[0];
               AssignAttri(sPrefix, false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
               A18SellerName = H001I2_A18SellerName[0];
               AssignAttri(sPrefix, false, "A18SellerName", A18SellerName);
               A19SellerPhoto = H001I2_A19SellerPhoto[0];
               AssignAttri(sPrefix, false, "A19SellerPhoto", A19SellerPhoto);
               AssignProp(sPrefix, false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
               AssignProp(sPrefix, false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
               A9CountryName = H001I2_A9CountryName[0];
               AssignAttri(sPrefix, false, "A9CountryName", A9CountryName);
               A7CategoryName = H001I2_A7CategoryName[0];
               AssignAttri(sPrefix, false, "A7CategoryName", A7CategoryName);
               A39ProductCountryName = H001I2_A39ProductCountryName[0];
               AssignAttri(sPrefix, false, "A39ProductCountryName", A39ProductCountryName);
               /* Execute user event: Load */
               E141I2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB1I0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1I2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ProductGeneral";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E131I2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA12ProductId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA12ProductId"), ",", "."));
            /* Read variables values. */
            A13ProductName = cgiGet( edtProductName_Internalname);
            AssignAttri(sPrefix, false, "A13ProductName", A13ProductName);
            A26ProductDescription = cgiGet( edtProductDescription_Internalname);
            AssignAttri(sPrefix, false, "A26ProductDescription", A26ProductDescription);
            A27ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ",", ".");
            AssignAttri(sPrefix, false, "A27ProductPrice", StringUtil.LTrimStr( A27ProductPrice, 8, 2));
            A14ProductCountryID = (short)(context.localUtil.CToN( cgiGet( edtProductCountryID_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A14ProductCountryID", StringUtil.LTrimStr( (decimal)(A14ProductCountryID), 4, 0));
            A39ProductCountryName = cgiGet( edtProductCountryName_Internalname);
            AssignAttri(sPrefix, false, "A39ProductCountryName", A39ProductCountryName);
            A6CategoryId = (short)(context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A6CategoryId", StringUtil.LTrimStr( (decimal)(A6CategoryId), 4, 0));
            A7CategoryName = cgiGet( edtCategoryName_Internalname);
            AssignAttri(sPrefix, false, "A7CategoryName", A7CategoryName);
            A10SellerId = (short)(context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
            A18SellerName = cgiGet( edtSellerName_Internalname);
            AssignAttri(sPrefix, false, "A18SellerName", A18SellerName);
            A8CountryId = (short)(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            A9CountryName = cgiGet( edtCountryName_Internalname);
            AssignAttri(sPrefix, false, "A9CountryName", A9CountryName);
            A28ProductPhoto = cgiGet( imgProductPhoto_Internalname);
            AssignAttri(sPrefix, false, "A28ProductPhoto", A28ProductPhoto);
            A19SellerPhoto = cgiGet( imgSellerPhoto_Internalname);
            AssignAttri(sPrefix, false, "A19SellerPhoto", A19SellerPhoto);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ProductGeneral");
            A6CategoryId = (short)(context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A6CategoryId", StringUtil.LTrimStr( (decimal)(A6CategoryId), 4, 0));
            forbiddenHiddens.Add("CategoryId", context.localUtil.Format( (decimal)(A6CategoryId), "ZZZ9"));
            A10SellerId = (short)(context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
            forbiddenHiddens.Add("SellerId", context.localUtil.Format( (decimal)(A10SellerId), "ZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("productgeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E131I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E131I2( )
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

      protected void E141I2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtCategoryName_Link = formatLink("viewcategory.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A6CategoryId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CategoryId","TabCode"}) ;
         AssignProp(sPrefix, false, edtCategoryName_Internalname, "Link", edtCategoryName_Link, true);
         edtSellerName_Link = formatLink("viewseller.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A10SellerId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"SellerId","TabCode"}) ;
         AssignProp(sPrefix, false, edtSellerName_Internalname, "Link", edtSellerName_Link, true);
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
         AV7TrnContext.gxTpr_Transactionname = "Product";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "ProductId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6ProductId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A12ProductId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
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
         PA1I2( ) ;
         WS1I2( ) ;
         WE1I2( ) ;
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
         sCtrlA12ProductId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA1I2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "productgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA1I2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A12ProductId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
         }
         wcpOA12ProductId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA12ProductId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A12ProductId != wcpOA12ProductId ) ) )
         {
            setjustcreated();
         }
         wcpOA12ProductId = A12ProductId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA12ProductId = cgiGet( sPrefix+"A12ProductId_CTRL");
         if ( StringUtil.Len( sCtrlA12ProductId) > 0 )
         {
            A12ProductId = (short)(context.localUtil.CToN( cgiGet( sCtrlA12ProductId), ",", "."));
            AssignAttri(sPrefix, false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
         }
         else
         {
            A12ProductId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A12ProductId_PARM"), ",", "."));
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
         PA1I2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS1I2( ) ;
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
         WS1I2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A12ProductId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA12ProductId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A12ProductId_CTRL", StringUtil.RTrim( sCtrlA12ProductId));
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
         WE1I2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202352115133012", true, true);
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
         context.AddJavascriptSource("productgeneral.js", "?202352115133013", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtProductId_Internalname = sPrefix+"PRODUCTID";
         edtProductName_Internalname = sPrefix+"PRODUCTNAME";
         edtProductDescription_Internalname = sPrefix+"PRODUCTDESCRIPTION";
         edtProductPrice_Internalname = sPrefix+"PRODUCTPRICE";
         edtProductCountryID_Internalname = sPrefix+"PRODUCTCOUNTRYID";
         edtProductCountryName_Internalname = sPrefix+"PRODUCTCOUNTRYNAME";
         edtCategoryId_Internalname = sPrefix+"CATEGORYID";
         edtCategoryName_Internalname = sPrefix+"CATEGORYNAME";
         edtSellerId_Internalname = sPrefix+"SELLERID";
         edtSellerName_Internalname = sPrefix+"SELLERNAME";
         edtCountryId_Internalname = sPrefix+"COUNTRYID";
         edtCountryName_Internalname = sPrefix+"COUNTRYNAME";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         imgProductPhoto_Internalname = sPrefix+"PRODUCTPHOTO";
         imgSellerPhoto_Internalname = sPrefix+"SELLERPHOTO";
         divImagestable_Internalname = sPrefix+"IMAGESTABLE";
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
         edtCountryName_Jsonclick = "";
         edtCountryName_Link = "";
         edtCountryName_Enabled = 0;
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 0;
         edtSellerName_Jsonclick = "";
         edtSellerName_Link = "";
         edtSellerName_Enabled = 0;
         edtSellerId_Jsonclick = "";
         edtSellerId_Enabled = 0;
         edtCategoryName_Jsonclick = "";
         edtCategoryName_Link = "";
         edtCategoryName_Enabled = 0;
         edtCategoryId_Jsonclick = "";
         edtCategoryId_Enabled = 0;
         edtProductCountryName_Jsonclick = "";
         edtProductCountryName_Enabled = 0;
         edtProductCountryID_Jsonclick = "";
         edtProductCountryID_Enabled = 0;
         edtProductPrice_Jsonclick = "";
         edtProductPrice_Enabled = 0;
         edtProductDescription_Jsonclick = "";
         edtProductDescription_Enabled = 0;
         edtProductName_Jsonclick = "";
         edtProductName_Enabled = 0;
         edtProductId_Jsonclick = "";
         edtProductId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A12ProductId',fld:'PRODUCTID',pic:'ZZZ9'},{av:'A6CategoryId',fld:'CATEGORYID',pic:'ZZZ9'},{av:'A10SellerId',fld:'SELLERID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E111I1',iparms:[{av:'A12ProductId',fld:'PRODUCTID',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E121I1',iparms:[{av:'A12ProductId',fld:'PRODUCTID',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTCOUNTRYID","{handler:'Valid_Productcountryid',iparms:[]");
         setEventMetadata("VALID_PRODUCTCOUNTRYID",",oparms:[]}");
         setEventMetadata("VALID_CATEGORYID","{handler:'Valid_Categoryid',iparms:[]");
         setEventMetadata("VALID_CATEGORYID",",oparms:[]}");
         setEventMetadata("VALID_SELLERID","{handler:'Valid_Sellerid',iparms:[]");
         setEventMetadata("VALID_SELLERID",",oparms:[]}");
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
         bttBtndelete_Jsonclick = "";
         A13ProductName = "";
         A26ProductDescription = "";
         A39ProductCountryName = "";
         A7CategoryName = "";
         A18SellerName = "";
         A9CountryName = "";
         A28ProductPhoto = "";
         A40000ProductPhoto_GXI = "";
         sImgUrl = "";
         A19SellerPhoto = "";
         A40001SellerPhoto_GXI = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H001I2_A12ProductId = new short[1] ;
         H001I2_A40001SellerPhoto_GXI = new string[] {""} ;
         H001I2_A40000ProductPhoto_GXI = new string[] {""} ;
         H001I2_A9CountryName = new string[] {""} ;
         H001I2_A8CountryId = new short[1] ;
         H001I2_A18SellerName = new string[] {""} ;
         H001I2_A10SellerId = new short[1] ;
         H001I2_A7CategoryName = new string[] {""} ;
         H001I2_A6CategoryId = new short[1] ;
         H001I2_A39ProductCountryName = new string[] {""} ;
         H001I2_A14ProductCountryID = new short[1] ;
         H001I2_A27ProductPrice = new decimal[1] ;
         H001I2_A26ProductDescription = new string[] {""} ;
         H001I2_A13ProductName = new string[] {""} ;
         H001I2_A19SellerPhoto = new string[] {""} ;
         H001I2_A28ProductPhoto = new string[] {""} ;
         hsh = "";
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA12ProductId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productgeneral__default(),
            new Object[][] {
                new Object[] {
               H001I2_A12ProductId, H001I2_A40001SellerPhoto_GXI, H001I2_A40000ProductPhoto_GXI, H001I2_A9CountryName, H001I2_A8CountryId, H001I2_A18SellerName, H001I2_A10SellerId, H001I2_A7CategoryName, H001I2_A6CategoryId, H001I2_A39ProductCountryName,
               H001I2_A14ProductCountryID, H001I2_A27ProductPrice, H001I2_A26ProductDescription, H001I2_A13ProductName, H001I2_A19SellerPhoto, H001I2_A28ProductPhoto
               }
            }
         );
         AV13Pgmname = "ProductGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ProductGeneral";
         context.Gx_err = 0;
      }

      private short A12ProductId ;
      private short wcpOA12ProductId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short A6CategoryId ;
      private short A10SellerId ;
      private short wbEnd ;
      private short wbStart ;
      private short A14ProductCountryID ;
      private short A8CountryId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6ProductId ;
      private short nGXWrapped ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductDescription_Enabled ;
      private int edtProductPrice_Enabled ;
      private int edtProductCountryID_Enabled ;
      private int edtProductCountryName_Enabled ;
      private int edtCategoryId_Enabled ;
      private int edtCategoryName_Enabled ;
      private int edtSellerId_Enabled ;
      private int edtSellerName_Enabled ;
      private int edtCountryId_Enabled ;
      private int edtCountryName_Enabled ;
      private int idxLst ;
      private decimal A27ProductPrice ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
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
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtProductId_Internalname ;
      private string edtProductId_Jsonclick ;
      private string edtProductName_Internalname ;
      private string A13ProductName ;
      private string edtProductName_Jsonclick ;
      private string edtProductDescription_Internalname ;
      private string A26ProductDescription ;
      private string edtProductDescription_Jsonclick ;
      private string edtProductPrice_Internalname ;
      private string edtProductPrice_Jsonclick ;
      private string edtProductCountryID_Internalname ;
      private string edtProductCountryID_Jsonclick ;
      private string edtProductCountryName_Internalname ;
      private string A39ProductCountryName ;
      private string edtProductCountryName_Jsonclick ;
      private string edtCategoryId_Internalname ;
      private string edtCategoryId_Jsonclick ;
      private string edtCategoryName_Internalname ;
      private string A7CategoryName ;
      private string edtCategoryName_Link ;
      private string edtCategoryName_Jsonclick ;
      private string edtSellerId_Internalname ;
      private string edtSellerId_Jsonclick ;
      private string edtSellerName_Internalname ;
      private string A18SellerName ;
      private string edtSellerName_Link ;
      private string edtSellerName_Jsonclick ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string edtCountryName_Internalname ;
      private string A9CountryName ;
      private string edtCountryName_Link ;
      private string edtCountryName_Jsonclick ;
      private string divImagestable_Internalname ;
      private string sImgUrl ;
      private string imgProductPhoto_Internalname ;
      private string imgSellerPhoto_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string hsh ;
      private string sCtrlA12ProductId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A28ProductPhoto_IsBlob ;
      private bool A19SellerPhoto_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A40000ProductPhoto_GXI ;
      private string A40001SellerPhoto_GXI ;
      private string A28ProductPhoto ;
      private string A19SellerPhoto ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H001I2_A12ProductId ;
      private string[] H001I2_A40001SellerPhoto_GXI ;
      private string[] H001I2_A40000ProductPhoto_GXI ;
      private string[] H001I2_A9CountryName ;
      private short[] H001I2_A8CountryId ;
      private string[] H001I2_A18SellerName ;
      private short[] H001I2_A10SellerId ;
      private string[] H001I2_A7CategoryName ;
      private short[] H001I2_A6CategoryId ;
      private string[] H001I2_A39ProductCountryName ;
      private short[] H001I2_A14ProductCountryID ;
      private decimal[] H001I2_A27ProductPrice ;
      private string[] H001I2_A26ProductDescription ;
      private string[] H001I2_A13ProductName ;
      private string[] H001I2_A19SellerPhoto ;
      private string[] H001I2_A28ProductPhoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class productgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH001I2;
          prmH001I2 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001I2", "SELECT T1.[ProductId], T2.[SellerPhoto_GXI], T1.[ProductPhoto_GXI], T3.[CountryName], T2.[CountryId], T2.[SellerName], T1.[SellerId], T4.[CategoryName], T1.[CategoryId], T5.[CountryName] AS ProductCountryName, T1.[ProductCountryID] AS ProductCountryID, T1.[ProductPrice], T1.[ProductDescription], T1.[ProductName], T2.[SellerPhoto], T1.[ProductPhoto] FROM (((([Product] T1 INNER JOIN [Seller] T2 ON T2.[SellerId] = T1.[SellerId]) INNER JOIN [Country] T3 ON T3.[CountryId] = T2.[CountryId]) INNER JOIN [Category] T4 ON T4.[CategoryId] = T1.[CategoryId]) INNER JOIN [Country] T5 ON T5.[CountryId] = T1.[ProductCountryID]) WHERE T1.[ProductId] = @ProductId ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001I2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 50);
                ((string[]) buf[13])[0] = rslt.getString(14, 20);
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(2));
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(3));
                return;
       }
    }

 }

}
