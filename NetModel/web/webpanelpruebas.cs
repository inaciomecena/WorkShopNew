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
   public class webpanelpruebas : GXDataArea
   {
      public webpanelpruebas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public webpanelpruebas( IGxContext context )
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
         PA112( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START112( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20235192212240", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("webpanelpruebas.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vVBLOBBEFORE", AV12vBlobBefore);
         GxWebStd.gx_hidden_field( context, "vBAN", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ban), 4, 0, ",", "")));
         GXCCtlgxBlob = "vVBLOB" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, AV11vBlob);
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
            WE112( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT112( ) ;
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
         return formatLink("webpanelpruebas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WebPanelPruebas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Web Panel Pruebas" ;
      }

      protected void WB110( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 30, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtscript_Internalname, lblTxtscript_Caption, "", "", lblTxtscript_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WebPanelPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, lblTextblock1_Caption, "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WebPanelPruebas.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnquery_Internalname, "", "Guardar", bttBtnquery_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'BTNCONF\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebPanelPruebas.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavVblob_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVblob_Internalname, "v Blob", "col-sm-3 ImageLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            ClassString = "Image";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            edtavVblob_Filetype = "tmp";
            AssignProp("", false, edtavVblob_Internalname, "Filetype", edtavVblob_Filetype, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11vBlob)) )
            {
               gxblobfileaux.Source = AV11vBlob;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavVblob_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavVblob_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV11vBlob = gxblobfileaux.GetURI();
                  AssignProp("", false, edtavVblob_Internalname, "URL", context.PathToRelativeUrl( AV11vBlob), true);
                  edtavVblob_Filetype = gxblobfileaux.GetExtension();
                  AssignProp("", false, edtavVblob_Internalname, "Filetype", edtavVblob_Filetype, true);
               }
               AssignProp("", false, edtavVblob_Internalname, "URL", context.PathToRelativeUrl( AV11vBlob), true);
            }
            GxWebStd.gx_blob_field( context, edtavVblob_Internalname, StringUtil.RTrim( AV11vBlob), context.PathToRelativeUrl( AV11vBlob), (String.IsNullOrEmpty(StringUtil.RTrim( edtavVblob_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavVblob_Filetype)) ? AV11vBlob : edtavVblob_Filetype)) : edtavVblob_Contenttype), false, "", edtavVblob_Parameters, 0, edtavVblob_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtavVblob_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "", "", "HLP_WebPanelPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVruta_Internalname, "v Ruta", "col-sm-3 AttributeLabel", 0, true, "");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavVruta_Internalname, AV17vRuta, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", 0, edtavVruta_Visible, edtavVruta_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WebPanelPruebas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START112( )
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
            Form.Meta.addItem("description", "Web Panel Pruebas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP110( ) ;
      }

      protected void WS112( )
      {
         START112( ) ;
         EVT112( ) ;
      }

      protected void EVT112( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11112 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'BTNCONF'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'btnconf' */
                              E12112 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13112 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
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

      protected void WE112( )
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

      protected void PA112( )
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
               GX_FocusControl = edtavVblob_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         RF112( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF112( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13112 ();
            WB110( ) ;
         }
      }

      protected void send_integrity_lvl_hashes112( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP110( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11112 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV11vBlob = cgiGet( edtavVblob_Internalname);
            AV17vRuta = cgiGet( edtavVruta_Internalname);
            AssignAttri("", false, "AV17vRuta", AV17vRuta);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11vBlob)) )
            {
               GXCCtlgxBlob = "vVBLOB" + "_gxBlob";
               AV11vBlob = cgiGet( GXCCtlgxBlob);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11112 ();
         if (returnInSub) return;
      }

      protected void E11112( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavVruta_Visible = 0;
         AssignProp("", false, edtavVruta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVruta_Visible), 5, 0), true);
         AV18vRutaUrl = AV8HttpRequest.BaseURL;
         lblTxtscript_Caption = "<link rel=\"stylesheet\" type=\"text/css\" href=\""+AV18vRutaUrl+"StyleLoadImage.css\">"+StringUtil.NewLine( )+"<script type=\"text/javascript\"> $(document).ready(function(){$(\"#BTNQUERY\").click(function(){"+StringUtil.NewLine( )+"var n=$(\"#ImgTarget\").attr(\"href\");$(\"#"+edtavVruta_Internalname+"\").val(n)});"+StringUtil.NewLine( )+"});</script>";
         AssignProp("", false, lblTxtscript_Internalname, "Caption", lblTxtscript_Caption, true);
         AV20vSrc = "";
         AV15vHref = "";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV5BranchImage)) && String.IsNullOrEmpty(StringUtil.RTrim( AV23Branchimage_GXI)) ) )
         {
            AV20vSrc = "src=\"" + AV24Userimg_GXI + "\"";
            AV15vHref = "href=\"" + AV24Userimg_GXI + "\"";
         }
         lblTextblock1_Caption = "<div class=\"gx-multimedia-upload\" id=\"Image_CT\">"+StringUtil.NewLine( )+"<a id=\"ImgEditIcon\" class=\"action change-action\" gxfocusable=\"1\" onfocus=\"gx.evt.onfocus(this, 79,"+"'',false,'',0)"+"\" onchange=\";gx.evt.onchange(this, event)\" onblur=\";gx.evt.onblur(this,79);\">Search</a><a id=\"ImgDeleteIcon\" gxfocusable=\"1\"  class=\"action clear-action\"></a>"+StringUtil.NewLine( )+"<a id=\"ImgTarget\" target=\"_blank\" class=\"gx-multimedia-empty\" "+AV15vHref+"><img id=\"ImageSearch\" alt=\"\" class=\"\" "+AV20vSrc+">"+StringUtil.NewLine( )+"<span id=\"SpanImagePH\" class=\"gx-image-placeholder\"></span></a><div id=\"Image_CT_fields\" class=\"fields-ct \" data-gx-tpl-applied-multimedia-upload=\"\">"+StringUtil.NewLine( )+"<div class=\"row\"><div class=\"col-sm-4\"><div class=\"row\"><div class=\"col-sm-12\"><label class=\"option\">"+StringUtil.NewLine( )+"<input type=\"radio\" value=\"file\" name=\"ImageOption\" checked=\"\">Cargar Imagen:</label></div><div class=\"col-sm-12\">"+StringUtil.NewLine( )+"<label class=\"option\"><input type=\"radio\" value=\"uri\" name=\"ImageOption\">Dirección (URL):</label>"+StringUtil.NewLine( )+"</div></div></div><div class=\"col-sm-8\"><input type=\"text\" id=\"IMAGE_GXI\" name=\"IMAGE_GXI\" value=\"\" spellcheck=\"false\" maxlength=\"254\" class=\"field Attribute form-control\" onfocus=\"gx.evt.onfocus(this, 79,"+"'',false,'',0)"+"\" onchange=\";gx.evt.onchange(this, event)\" onblur=\";gx.evt.onblur(this,79);\">"+StringUtil.NewLine( )+"<input type=\"file\" class=\"field Attribute field-selected\" id=\"IMAGESEARCH\" name=\"IMAGESEARCH\" accept=\"image/*\" onfocus=\"gx.evt.onfocus(this, 79,"+"'',false,'',0)"+"\" onchange=\";gx.evt.onchange(this, event)\" onblur=\";gx.evt.onblur(this,79);\" data-gx-context=\"[&quot;&quot;,false]\">"+StringUtil.NewLine( )+"</div></div><div class=\"row\"><div class=\"col-sm-12\"></div>"+StringUtil.NewLine( )+"</div></div></div>";
         AssignProp("", false, lblTextblock1_Internalname, "Caption", lblTextblock1_Caption, true);
      }

      protected void E12112( )
      {
         /* 'btnconf' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17vRuta, AV12vBlobBefore) == 0 )
         {
            AV11vBlob = "";
            AssignProp("", false, edtavVblob_Internalname, "URL", context.PathToRelativeUrl( AV11vBlob), true);
         }
         else
         {
            AV12vBlobBefore = AV17vRuta;
            AssignAttri("", false, "AV12vBlobBefore", AV12vBlobBefore);
            AV19vSear = (short)(StringUtil.StringSearch( AV17vRuta, "base64,", 1)+7);
            AV9tRoute = StringUtil.Substring( AV17vRuta, AV19vSear, StringUtil.Len( AV17vRuta));
            if ( AV19vSear > 7 )
            {
               AV11vBlob=context.FileFromBase64( AV9tRoute) ;
            }
            else
            {
               AV11vBlob = "";
               AssignProp("", false, edtavVblob_Internalname, "URL", context.PathToRelativeUrl( AV11vBlob), true);
            }
         }
         GX_msglist.addItem(AV17vRuta);
         new pguardarusuario(context ).execute( ref  AV11vBlob, ref  AV6ban) ;
         AssignProp("", false, edtavVblob_Internalname, "URL", context.PathToRelativeUrl( AV11vBlob), true);
         AssignAttri("", false, "AV6ban", StringUtil.LTrimStr( (decimal)(AV6ban), 4, 0));
         if ( AV6ban == 1 )
         {
            GX_msglist.addItem("guardo");
         }
         else
         {
            GX_msglist.addItem("fallo");
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E13112( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA112( ) ;
         WS112( ) ;
         WE112( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202351922122413", true, true);
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
         context.AddJavascriptSource("webpanelpruebas.js", "?202351922122413", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTxtscript_Internalname = "TXTSCRIPT";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         bttBtnquery_Internalname = "BTNQUERY";
         edtavVblob_Internalname = "vVBLOB";
         edtavVruta_Internalname = "vVRUTA";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavVruta_Enabled = 1;
         edtavVruta_Visible = 1;
         edtavVblob_Jsonclick = "";
         edtavVblob_Parameters = "";
         edtavVblob_Contenttype = "";
         edtavVblob_Filetype = "";
         edtavVblob_Enabled = 1;
         lblTextblock1_Caption = "Imagen";
         lblTxtscript_Caption = "Script";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Web Panel Pruebas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'BTNCONF'","{handler:'E12112',iparms:[{av:'AV17vRuta',fld:'vVRUTA',pic:''},{av:'AV12vBlobBefore',fld:'vVBLOBBEFORE',pic:''},{av:'AV6ban',fld:'vBAN',pic:'ZZZ9'}]");
         setEventMetadata("'BTNCONF'",",oparms:[{av:'AV12vBlobBefore',fld:'vVBLOBBEFORE',pic:''},{av:'AV11vBlob',fld:'vVBLOB',pic:''},{av:'AV6ban',fld:'vBAN',pic:'ZZZ9'}]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV12vBlobBefore = "";
         GXCCtlgxBlob = "";
         AV11vBlob = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTxtscript_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnquery_Jsonclick = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         AV17vRuta = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV18vRutaUrl = "";
         AV8HttpRequest = new GxHttpRequest( context);
         AV20vSrc = "";
         AV15vHref = "";
         AV5BranchImage = "";
         AV23Branchimage_GXI = "";
         AV24Userimg_GXI = "";
         AV9tRoute = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV6ban ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV19vSear ;
      private short nGXWrapped ;
      private int edtavVblob_Enabled ;
      private int edtavVruta_Visible ;
      private int edtavVruta_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXCCtlgxBlob ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTxtscript_Internalname ;
      private string lblTxtscript_Caption ;
      private string lblTxtscript_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Caption ;
      private string lblTextblock1_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnquery_Internalname ;
      private string bttBtnquery_Jsonclick ;
      private string edtavVblob_Internalname ;
      private string edtavVblob_Filetype ;
      private string edtavVblob_Contenttype ;
      private string edtavVblob_Parameters ;
      private string edtavVblob_Jsonclick ;
      private string edtavVruta_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV12vBlobBefore ;
      private string AV17vRuta ;
      private string AV9tRoute ;
      private string AV18vRutaUrl ;
      private string AV20vSrc ;
      private string AV15vHref ;
      private string AV23Branchimage_GXI ;
      private string AV24Userimg_GXI ;
      private string AV5BranchImage ;
      private string AV11vBlob ;
      private GxFile gxblobfileaux ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HttpRequest ;
      private GXWebForm Form ;
   }

}
