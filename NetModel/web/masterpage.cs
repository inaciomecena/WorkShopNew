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
   public class masterpage : GXMasterPage
   {
      public masterpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public masterpage( IGxContext context )
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
            PA072( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS072( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE072( ) ;
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
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
      }

      protected void RenderHtmlCloseForm072( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((string)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.AddJavascriptSource("masterpage.js", "?202352020532236", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "MasterPage" ;
      }

      public override string GetPgmdesc( )
      {
         return "Master Page" ;
      }

      protected void WB070( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtscrip1_Internalname, lblTxtscrip1_Caption, "", "", lblTxtscrip1_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_MasterPage.htm");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtscript2_Internalname, lblTxtscript2_Caption, "", "", lblTxtscript2_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_MasterPage.htm");
         }
         wbLoad = true;
      }

      protected void START072( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP070( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS072( )
      {
         START072( ) ;
         EVT072( ) ;
      }

      protected void EVT072( )
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
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E12072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
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
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE072( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm072( ) ;
            }
         }
      }

      protected void PA072( )
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
         RF072( ) ;
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

      protected void RF072( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12072 ();
            WB070( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes072( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP070( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11072 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
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
         E11072 ();
         if (returnInSub) return;
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         AV5vRuta = AV6HttpRequest.BaseURL;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<meta content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\" name=\"viewport\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/bower_components/font-awesome/css/font-awesome.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/bower_components/Ionicons/css/ionicons.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/dist/css/AdminLTE.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/dist/css/skins/_all-skins.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/bower_components/morris.js/morris.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/bower_components/jvectormap/jquery-jvectormap.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/bower_components/bootstrap-daterangepicker/daterangepicker.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"MyMaster/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css\">"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic\">"+StringUtil.NewLine( )+"<script>window.onload = function(){document.body.className = \"form-horizontal Form form-horizontal-fx hold-transition skin-blue sidebar-mini\";}</script>";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/jquery/dist/jquery.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/jquery-ui/jquery-ui.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/raphael/raphael.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/plugins/jvectormap/jquery-jvectormap-world-mill-en.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/jquery-knob/dist/jquery.knob.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/moment/min/moment.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/bootstrap-daterangepicker/daterangepicker.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/jquery-slimscroll/jquery.slimscroll.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/bower_components/fastclick/lib/fastclick.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/dist/js/adminlte.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"MyMaster/dist/js/demo.js") ;
         AV7vScript = "<div class=\"wrapper\">" + StringUtil.NewLine( ) + "<header class=\"main-header\">" + StringUtil.NewLine( ) + "<a href=\"index2.html\" class=\"logo\">" + StringUtil.NewLine( ) + "<span class=\"logo-mini\"><b>A</b>LT</span>" + StringUtil.NewLine( ) + "<span class=\"logo-lg\"><b>Painel</b>Shop</span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<nav class=\"navbar navbar-static-top\">" + StringUtil.NewLine( ) + "<a href=\"#\" class=\"sidebar-toggle\" data-toggle=\"push-menu\" role=\"button\">" + StringUtil.NewLine( ) + " <span class=\"sr-only\"></span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<div class=\"navbar-custom-menu\">" + StringUtil.NewLine( ) + "<ul class=\"nav navbar-nav\">" + StringUtil.NewLine( ) + "<li class=\"dropdown notifications-menu\">" + StringUtil.NewLine( ) + "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">" + StringUtil.NewLine( ) + "<i class=\"fa fa-bell-o\"></i>" + StringUtil.NewLine( ) + "<span class=\"label label-warning\">5</span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "<ul class=\"dropdown-menu\">" + StringUtil.NewLine( ) + "<li class=\"header\">Tienes 5 Notifica��es</li>" + StringUtil.NewLine( ) + "<li>" + StringUtil.NewLine( ) + "<ul class=\"menu\">" + StringUtil.NewLine( ) + "<li>" + StringUtil.NewLine( ) + "<a href=\"#\">" + StringUtil.NewLine( ) + "<i class=\"fa fa-users text-aqua\"></i> 5 new members joined today" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "<li class=\"footer\"><a href=\"#\">Ver Tudo</a></li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</li>" + StringUtil.NewLine( ) + "</ul>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "</nav>" + StringUtil.NewLine( ) + "</header>" + StringUtil.NewLine( ) + "<aside class=\"main-sidebar\" style=\"max-height: 100%;\">" + StringUtil.NewLine( ) + "<section class=\"sidebar\">" + StringUtil.NewLine( ) + "<div class=\"user-panel\">" + StringUtil.NewLine( ) + "<div class=\"pull-left image\">" + StringUtil.NewLine( ) + "<img src=\"MyMaster/dist/img/avatar5.png\" class=\"img-circle\" alt=\"User Image\">" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "<div class=\"pull-left info\">" + StringUtil.NewLine( ) + "<p>In�cio Mecena</p>" + StringUtil.NewLine( ) + "<a href=\"#\"><i class=\"fa fa-circle text-success\"></i> Online</a>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "</div>" + StringUtil.NewLine( ) + "<ul class=\"sidebar-menu\" data-widget=\"tree\">" + StringUtil.NewLine( ) + "<li class=\"header\">SOFTWARE</li>";
         /* Using cursor H00072 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A5MenXEst = H00072_A5MenXEst[0];
            n5MenXEst = H00072_n5MenXEst[0];
            A2MenuXDesc = H00072_A2MenuXDesc[0];
            n2MenuXDesc = H00072_n2MenuXDesc[0];
            A4MenXUrl = H00072_A4MenXUrl[0];
            n4MenXUrl = H00072_n4MenXUrl[0];
            A3MenuXPosi = H00072_A3MenuXPosi[0];
            n3MenuXPosi = H00072_n3MenuXPosi[0];
            AV9vScript11 += "<li class=\"active treeview\">" + StringUtil.NewLine( ) + "<a href=\"" + AV5vRuta + StringUtil.Trim( A4MenXUrl) + "\">" + StringUtil.NewLine( ) + "<i class=\"fa fa-dashboard\"></i> <span>" + StringUtil.Trim( A2MenuXDesc) + "</span>" + StringUtil.NewLine( ) + "<span class=\"pull-right-container\">" + StringUtil.NewLine( ) + "<i class=\"fa fa-angle-left pull-right\"></i>" + StringUtil.NewLine( ) + "</span>" + StringUtil.NewLine( ) + "</a>" + StringUtil.NewLine( ) + "</li>";
            AssignAttri("", true, "AV9vScript11", AV9vScript11);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV7vScript += AV9vScript11 + "</ul>" + StringUtil.NewLine( ) + "</section>" + StringUtil.NewLine( ) + "</aside>" + StringUtil.NewLine( ) + "<div class=\"content-wrapper\" >" + StringUtil.NewLine( ) + "<section class=\"content-header\">" + StringUtil.NewLine( ) + "<ol class=\"breadcrumb\" style=\"position:static;\">" + StringUtil.NewLine( ) + "<li><a href=\"#\"><i class=\"fa fa-dashboard\"></i> Position</a></li>" + StringUtil.NewLine( ) + "<li class=\"active\">" + (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption + "</li>" + StringUtil.NewLine( ) + "</ol>" + StringUtil.NewLine( ) + "</section>" + StringUtil.NewLine( ) + "<section class=\"content\" >";
         AV8vScript2 = "  </section></div></div>";
         lblTxtscrip1_Caption = AV7vScript;
         AssignProp("", true, lblTxtscrip1_Internalname, "Caption", lblTxtscrip1_Caption, true);
         lblTxtscript2_Caption = AV8vScript2;
         AssignProp("", true, lblTxtscript2_Internalname, "Caption", lblTxtscript2_Caption, true);
      }

      protected void nextLoad( )
      {
      }

      protected void E12072( )
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
         PA072( ) ;
         WS072( ) ;
         WE072( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void master_styles( )
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
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?202352020532253", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("masterpage.js", "?202352020532253", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTxtscrip1_Internalname = "TXTSCRIP1_MPAGE";
         lblTxtscript2_Internalname = "TXTSCRIPT2_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         lblTxtscript2_Caption = "Script2";
         lblTxtscrip1_Caption = "Script1";
         Contholder1.setDataArea(getDataAreaObject());
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
         setEventMetadata("REFRESH_MPAGE","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH_MPAGE",",oparms:[]}");
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
         Contholder1 = new GXDataAreaControl();
         GXKey = "";
         sPrefix = "";
         lblTxtscrip1_Jsonclick = "";
         lblTxtscript2_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5vRuta = "";
         AV6HttpRequest = new GxHttpRequest( context);
         AV7vScript = "";
         scmdbuf = "";
         H00072_A1MenuXid = new short[1] ;
         H00072_A5MenXEst = new string[] {""} ;
         H00072_n5MenXEst = new bool[] {false} ;
         H00072_A2MenuXDesc = new string[] {""} ;
         H00072_n2MenuXDesc = new bool[] {false} ;
         H00072_A4MenXUrl = new string[] {""} ;
         H00072_n4MenXUrl = new bool[] {false} ;
         H00072_A3MenuXPosi = new short[1] ;
         H00072_n3MenuXPosi = new bool[] {false} ;
         A5MenXEst = "";
         A2MenuXDesc = "";
         A4MenXUrl = "";
         AV9vScript11 = "";
         AV8vScript2 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.masterpage__default(),
            new Object[][] {
                new Object[] {
               H00072_A1MenuXid, H00072_A5MenXEst, H00072_n5MenXEst, H00072_A2MenuXDesc, H00072_n2MenuXDesc, H00072_A4MenXUrl, H00072_n4MenXUrl, H00072_A3MenuXPosi, H00072_n3MenuXPosi
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short initialized ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A3MenuXPosi ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int idxLst ;
      private string GXKey ;
      private string sPrefix ;
      private string lblTxtscrip1_Internalname ;
      private string lblTxtscrip1_Caption ;
      private string lblTxtscrip1_Jsonclick ;
      private string lblTxtscript2_Internalname ;
      private string lblTxtscript2_Caption ;
      private string lblTxtscript2_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string A5MenXEst ;
      private string sDynURL ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n5MenXEst ;
      private bool n2MenuXDesc ;
      private bool n4MenXUrl ;
      private bool n3MenuXPosi ;
      private string AV7vScript ;
      private string AV9vScript11 ;
      private string AV8vScript2 ;
      private string AV5vRuta ;
      private string A2MenuXDesc ;
      private string A4MenXUrl ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contholder1 ;
      private IDataStoreProvider pr_default ;
      private short[] H00072_A1MenuXid ;
      private string[] H00072_A5MenXEst ;
      private bool[] H00072_n5MenXEst ;
      private string[] H00072_A2MenuXDesc ;
      private bool[] H00072_n2MenuXDesc ;
      private string[] H00072_A4MenXUrl ;
      private bool[] H00072_n4MenXUrl ;
      private short[] H00072_A3MenuXPosi ;
      private bool[] H00072_n3MenuXPosi ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV6HttpRequest ;
      private GXWebForm Form ;
   }

   public class masterpage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00072;
          prmH00072 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00072", "SELECT [MenuXid], [MenXEst], [MenuXDesc], [MenXUrl], [MenuXPosi] FROM [Menu] WHERE [MenXEst] = 'A' ORDER BY [MenuXPosi] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00072,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
