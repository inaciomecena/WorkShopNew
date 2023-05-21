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
   public class wp_principal : GXMasterPage
   {
      public wp_principal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public wp_principal( IGxContext context )
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
            PA1P2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS1P2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE1P2( ) ;
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

      protected void RenderHtmlCloseForm1P2( )
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
         context.AddJavascriptSource("wp_principal.js", "?20235211524358", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "WP_Principal" ;
      }

      public override string GetPgmdesc( )
      {
         return "Master Page" ;
      }

      protected void WB1P0( )
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
            GxWebStd.gx_label_ctrl( context, lblTxtscrip1_Internalname, lblTxtscrip1_Caption, "", "", lblTxtscrip1_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_Principal.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTxtscript2_Internalname, lblTxtscript2_Caption, "", "", lblTxtscript2_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_Principal.htm");
         }
         wbLoad = true;
      }

      protected void START1P2( )
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
         STRUP1P0( ) ;
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

      protected void WS1P2( )
      {
         START1P2( ) ;
         EVT1P2( ) ;
      }

      protected void EVT1P2( )
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
                           E111P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E121P2 ();
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

      protected void WE1P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1P2( ) ;
            }
         }
      }

      protected void PA1P2( )
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
         RF1P2( ) ;
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

      protected void RF1P2( )
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
            E121P2 ();
            WB1P0( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes1P2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111P2 ();
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
         E111P2 ();
         if (returnInSub) return;
      }

      protected void E111P2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV5vRuta = AV6HttpRequest.BaseURL;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<meta charset=\"utf-8\">"+StringUtil.NewLine( )+"<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">"+StringUtil.NewLine( )+"<title>AdminLTE 3 | Dashboard</title>"+StringUtil.NewLine( )+"<!-- Google Font: Source Sans Pro -->"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback\">"+StringUtil.NewLine( )+"<!-- Font Awesome -->"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"plugins/fontawesome-free/css/all.min.css\">"+StringUtil.NewLine( )+"<!-- Ionicons -->"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\"https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css\">"+StringUtil.NewLine( )+"<!-- Tempusdominus Bootstrap 4 -->"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"TemaInacio/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css\">"+StringUtil.NewLine( )+"<!-- iCheck -->"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"TemaInacio/plugins/icheck-bootstrap/icheck-bootstrap.min.css\">"+StringUtil.NewLine( )+"<!-- JQVMap -->"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"TemaInacio/plugins/jqvmap/jqvmap.min.css\">"+StringUtil.NewLine( )+"<!-- Theme style -->"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"TemaInacio/dist/css/adminlte.min.css\">"+StringUtil.NewLine( )+"<!-- overlayScrollbars -->"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"TemaInacio/plugins/overlayScrollbars/css/OverlayScrollbars.min.css\">"+StringUtil.NewLine( )+"<!-- Daterange picker -->"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"TemaInacio/plugins/daterangepicker/daterangepicker.css\">"+StringUtil.NewLine( )+"<!-- summernote -->"+StringUtil.NewLine( )+"<link rel=\"stylesheet\" href=\""+AV5vRuta+"TemaInacio/plugins/summernote/summernote-bs4.min.css\">";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/jquery/jquery.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/jquery-ui/jquery-ui.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/bootstrap/js/bootstrap.bundle.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/chart.js/Chart.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/sparklines/sparkline.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/jqvmap/jquery.vmap.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/jqvmap/maps/jquery.vmap.usa.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/jquery-knob/jquery.knob.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/moment/moment.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/daterangepicker/daterangepicker.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/summernote/summernote-bs4.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/dist/js/adminlte.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/dist/js/demo.js") ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Add(AV5vRuta+"TemaInacio/dist/js/pages/dashboard.js") ;
         AV7vScript = "<section class=\"content\">" + StringUtil.NewLine( ) + "<div class=\"container-fluid\">" + StringUtil.NewLine( ) + " <!-- Small boxes (Stat box) -->" + StringUtil.NewLine( ) + " <div class=\"row\">" + StringUtil.NewLine( ) + "<div class=\"col-lg-3 col-6\">" + StringUtil.NewLine( ) + " <!-- small box -->" + StringUtil.NewLine( ) + " <div class=\"small-box bg-info\">" + StringUtil.NewLine( ) + "<div class=\"inner\">" + StringUtil.NewLine( ) + " <h3>150</h3>" + StringUtil.NewLine( ) + "              <p>New Orders</p>" + StringUtil.NewLine( ) + "            </div>" + StringUtil.NewLine( ) + "            <div class=\"icon\">" + StringUtil.NewLine( ) + "              <i class=\"ion ion-bag\"></i>" + StringUtil.NewLine( ) + "            </div>" + StringUtil.NewLine( ) + "            <a href=\"#\" class=\"small-box-footer\">More info <i class=\"fas fa-arrow-circle-right\"></i></a>" + StringUtil.NewLine( ) + "          </div>" + StringUtil.NewLine( ) + "        </div>" + StringUtil.NewLine( ) + "        <!-- ./col -->" + StringUtil.NewLine( ) + "        <div class=\"col-lg-3 col-6\">" + StringUtil.NewLine( ) + "          <!-- small box -->" + StringUtil.NewLine( ) + "          <div class=\"small-box bg-success\">" + StringUtil.NewLine( ) + "            <div class=\"inner\">" + StringUtil.NewLine( ) + "              <h3>53<sup style=\"font-size: 20px\">%</sup></h3>" + StringUtil.NewLine( ) + "              <p>Bounce Rate</p>" + StringUtil.NewLine( ) + "            </div>" + StringUtil.NewLine( ) + "            <div class=\"icon\">" + StringUtil.NewLine( ) + "              <i class=\"ion ion-stats-bars\"></i>" + StringUtil.NewLine( ) + "            </div>" + StringUtil.NewLine( ) + "            <a href=\"#\" class=\"small-box-footer\">More info <i class=\"fas fa-arrow-circle-right\"></i></a>" + StringUtil.NewLine( ) + "          </div>" + StringUtil.NewLine( ) + "        </div>" + StringUtil.NewLine( ) + "        <!-- ./col -->" + StringUtil.NewLine( ) + "        <div class=\"col-lg-3 col-6\">" + StringUtil.NewLine( ) + "          <!-- small box -->" + StringUtil.NewLine( ) + "          <div class=\"small-box bg-warning\">" + StringUtil.NewLine( ) + "            <div class=\"inner\">" + StringUtil.NewLine( ) + "              <h3>44</h3>" + StringUtil.NewLine( ) + "              <p>User Registrations</p>" + StringUtil.NewLine( ) + "            </div>" + StringUtil.NewLine( ) + "            <div class=\"icon\">" + StringUtil.NewLine( ) + "             <i class=\"ion ion-person-add\"></i>" + StringUtil.NewLine( ) + "            </div>" + StringUtil.NewLine( ) + "            <a href=\"#\" class=\"small-box-footer\">More info <i class=\"fas fa-arrow-circle-right\"></i></a>" + StringUtil.NewLine( ) + "          </div>" + StringUtil.NewLine( ) + "        </div>" + StringUtil.NewLine( ) + "        <!-- ./col -->" + StringUtil.NewLine( ) + "        <div class=\"col-lg-3 col-6\">" + StringUtil.NewLine( ) + "          <!-- small box -->" + StringUtil.NewLine( ) + "         <div class=\"small-box bg-danger\">" + StringUtil.NewLine( ) + "           <div class=\"inner\">" + StringUtil.NewLine( ) + "             <h3>65</h3>" + StringUtil.NewLine( ) + "              <p>Unique Visitors</p>" + StringUtil.NewLine( ) + "            </div>" + StringUtil.NewLine( ) + "            <div class=\"icon\">" + StringUtil.NewLine( ) + "             <i class=\"ion ion-pie-graph\"></i>" + StringUtil.NewLine( ) + "             </div>" + StringUtil.NewLine( ) + "             <a href=\"#\" class=\"small-box-footer\">More info <i class=\"fas fa-arrow-circle-right\"></i></a>" + StringUtil.NewLine( ) + "           </div>" + StringUtil.NewLine( ) + "        </div>" + StringUtil.NewLine( ) + "         <!-- ./col -->" + StringUtil.NewLine( ) + "       </div>" + StringUtil.NewLine( ) + "       <!-- /.row -->" + StringUtil.NewLine( ) + "      <!-- Main row -->" + StringUtil.NewLine( ) + "       <div class=\"row\">" + StringUtil.NewLine( ) + "          <!-- Left col -->" + StringUtil.NewLine( ) + "          <section class=\"col-lg-7 connectedSortable\">" + StringUtil.NewLine( ) + "           <!-- Custom tabs (Charts with tabs)-->" + StringUtil.NewLine( ) + "            <div class=\"card\">" + StringUtil.NewLine( ) + "             <div class=\"card-header\">" + StringUtil.NewLine( ) + "               <h3 class=\"card-title\">" + StringUtil.NewLine( ) + "                 <i class=\"fas fa-chart-pie mr-1\"></i>" + StringUtil.NewLine( ) + "                Sales" + StringUtil.NewLine( ) + "               </h3>" + StringUtil.NewLine( ) + "              <div class=\"card-tools\">" + StringUtil.NewLine( ) + "                <ul class=\"nav nav-pills ml-auto\">" + StringUtil.NewLine( ) + "                  <li class=\"nav-item\">" + StringUtil.NewLine( ) + "                    <a class=\"nav-link active\" href=\"#revenue-chart\" data-toggle=\"tab\">Area</a>" + StringUtil.NewLine( ) + "                  </li>" + StringUtil.NewLine( ) + "                  <li class=\"nav-item\">" + StringUtil.NewLine( ) + "                    <a class=\"nav-link\" href=\"#sales-chart\" data-toggle=\"tab\">Donut</a>" + StringUtil.NewLine( ) + "                  </li>" + StringUtil.NewLine( ) + "                </ul>" + StringUtil.NewLine( ) + "              </div>" + StringUtil.NewLine( ) + "            </div><!-- /.card-header -->" + StringUtil.NewLine( ) + "            <div class=\"card-body\">" + StringUtil.NewLine( ) + "             <div class=\"tab-content p-0\">" + StringUtil.NewLine( ) + "               <!-- Morris chart - Sales -->" + StringUtil.NewLine( ) + "               <div class=\"chart tab-pane active\" id=\"revenue-chart\"" + StringUtil.NewLine( ) + "                    style=\"position: relative; height: 300px;\">" + StringUtil.NewLine( ) + "                   <canvas id=\"revenue-chart-canvas\" height=\"300\" style=\"height: 300px;\"></canvas>" + StringUtil.NewLine( ) + "               </div>" + StringUtil.NewLine( ) + "               <div class=\"chart tab-pane\" id=\"sales-chart\" style=\"position: relative; height: 300px;\">" + StringUtil.NewLine( ) + "                 <canvas id=\"sales-chart-canvas\" height=\"300\" style=\"height: 300px;\"></canvas>" + StringUtil.NewLine( ) + "               </div>" + StringUtil.NewLine( ) + "             </div>" + StringUtil.NewLine( ) + "           </div><!-- /.card-body -->" + StringUtil.NewLine( ) + "        </div>" + StringUtil.NewLine( ) + "         <!-- /.card -->" + StringUtil.NewLine( ) + "         <!-- TO DO List -->" + StringUtil.NewLine( ) + "         <div class=\"card\">" + StringUtil.NewLine( ) + "           <div class=\"card-header\">" + StringUtil.NewLine( ) + "            <h3 class=\"card-title\">" + StringUtil.NewLine( ) + "              <i class=\"ion ion-clipboard mr-1\"></i>" + StringUtil.NewLine( ) + "              To Do List" + StringUtil.NewLine( ) + "             </h3>" + StringUtil.NewLine( ) + "             <div class=\"card-tools\">" + StringUtil.NewLine( ) + "               <ul class=\"pagination pagination-sm\">" + StringUtil.NewLine( ) + "                 <li class=\"page-item\"><a href=\"#\" class=\"page-link\">&laquo;</a></li>" + StringUtil.NewLine( ) + "                 <li class=\"page-item\"><a href=\"#\" class=\"page-link\">1</a></li>" + StringUtil.NewLine( ) + "                 <li class=\"page-item\"><a href=\"#\" class=\"page-link\">2</a></li>" + StringUtil.NewLine( ) + "                 <li class=\"page-item\"><a href=\"#\" class=\"page-link\">3</a></li>" + StringUtil.NewLine( ) + "                 <li class=\"page-item\"><a href=\"#\" class=\"page-link\">&raquo;</a></li>" + StringUtil.NewLine( ) + "               </ul>" + StringUtil.NewLine( ) + "             </div>" + StringUtil.NewLine( ) + "           </div>" + StringUtil.NewLine( ) + "           <!-- /.card-header -->" + StringUtil.NewLine( ) + "           <div class=\"card-body\">" + StringUtil.NewLine( ) + "             <ul class=\"todo-list\" data-widget=\"todo-list\">" + StringUtil.NewLine( ) + "               <li>" + StringUtil.NewLine( ) + "                 <!-- drag handle -->" + StringUtil.NewLine( ) + "                 <span class=\"handle\">" + StringUtil.NewLine( ) + "                  <i class=\"fas fa-ellipsis-v\"></i>" + StringUtil.NewLine( ) + "                  <i class=\"fas fa-ellipsis-v\"></i>" + StringUtil.NewLine( ) + "                 </span>" + StringUtil.NewLine( ) + "                 <!-- checkbox -->" + StringUtil.NewLine( ) + "                 <div  class=\"icheck-primary d-inline ml-2\">" + StringUtil.NewLine( ) + "                   <input type=\"checkbox\" value=\"\" name=\"todo1\" id=\"todoCheck1\">" + StringUtil.NewLine( ) + "                   <label for=\"todoCheck1\"></label>" + StringUtil.NewLine( ) + "                 </div>" + StringUtil.NewLine( ) + "                   <!-- todo text -->" + StringUtil.NewLine( ) + "                   <span class=\"text\">Design a nice theme</span>" + StringUtil.NewLine( ) + "                    <!-- Emphasis label -->" + StringUtil.NewLine( ) + "                    <small class=\"badge badge-danger\"><i class=\"far fa-clock\"></i> 2 mins</small>" + StringUtil.NewLine( ) + "                    <!-- General tools such as edit or delete-->" + StringUtil.NewLine( ) + "                   <div class=\"tools\">" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-edit\"></i>" + StringUtil.NewLine( ) + "                      <i class=\"fas fa-trash-o\"></i>" + StringUtil.NewLine( ) + "                   </div>" + StringUtil.NewLine( ) + "                 </li>" + StringUtil.NewLine( ) + "                 <li>" + StringUtil.NewLine( ) + "                   <span class=\"handle\">" + StringUtil.NewLine( ) + "                      <i class=\"fas fa-ellipsis-v\"></i>" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-ellipsis-v\"></i>" + StringUtil.NewLine( ) + "                    </span>" + StringUtil.NewLine( ) + "                   <div  class=\"icheck-primary d-inline ml-2\">" + StringUtil.NewLine( ) + "                     <input type=\"checkbox\" value=\"\" name=\"todo2\" id=\"todoCheck2\" checked>" + StringUtil.NewLine( ) + "                     <label for=\"todoCheck2\"></label>" + StringUtil.NewLine( ) + "                   </div>" + StringUtil.NewLine( ) + "                   <span class=\"text\">Make the theme responsive</span>" + StringUtil.NewLine( ) + "                   <small class=\"badge badge-info\"><i class=\"far fa-clock\"></i> 4 hours</small>" + StringUtil.NewLine( ) + "                   <div class=\"tools\">" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-edit\"></i>" + StringUtil.NewLine( ) + "                    <i class=\"fas fa-trash-o\"></i>" + StringUtil.NewLine( ) + "                  </div>" + StringUtil.NewLine( ) + "                 </li>" + StringUtil.NewLine( ) + "                 <li>" + StringUtil.NewLine( ) + "                   <span class=\"handle\">" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-ellipsis-v\"></i>" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-ellipsis-v\"></i>" + StringUtil.NewLine( ) + "                   </span>" + StringUtil.NewLine( ) + "                   <div  class=\"icheck-primary d-inline ml-2\">" + StringUtil.NewLine( ) + "                     <input type=\"checkbox\" value=\"\" name=\"todo3\" id=\"todoCheck3\">" + StringUtil.NewLine( ) + "                     <label for=\"todoCheck3\"></label>" + StringUtil.NewLine( ) + "                   </div>" + StringUtil.NewLine( ) + "                   <span class=\"text\">Let theme shine like a star</span>" + StringUtil.NewLine( ) + "                   <small class=\"badge badge-warning\"><i class=\"far fa-clock\"></i> 1 day</small>" + StringUtil.NewLine( ) + "                   <div class=\"tools\">" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-edit\"></i>" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-trash-o\"></i>" + StringUtil.NewLine( ) + "                   </div>" + StringUtil.NewLine( ) + "                 </li>" + StringUtil.NewLine( ) + "                 <li>" + StringUtil.NewLine( ) + "                   <span class=\"handle\">" + StringUtil.NewLine( ) + "                      <i class=\"fas fa-ellipsis-v\"></i>" + StringUtil.NewLine( ) + "                    <i class=\"fas fa-ellipsis-v\"></i>" + StringUtil.NewLine( ) + "                   </span>" + StringUtil.NewLine( ) + "                   <div  class=\"icheck-primary d-inline ml-2\">" + StringUtil.NewLine( ) + "                     <input type=\"checkbox\" value=\"\" name=\"todo4\" id=\"todoCheck4\">" + StringUtil.NewLine( ) + "                     <label for=\"todoCheck4\"></label>" + StringUtil.NewLine( ) + "                   </div>" + StringUtil.NewLine( ) + "                   <span class=\"text\">Let theme shine like a star</span>" + StringUtil.NewLine( ) + "                   <small class=\"badge badge-success\"><i class=\"far fa-clock\"></i> 3 days</small>" + StringUtil.NewLine( ) + "                   <div class=\"tools\">" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-edit\"></i>" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-trash-o\"></i>" + StringUtil.NewLine( ) + "                    </div>" + StringUtil.NewLine( ) + "                  </li>" + StringUtil.NewLine( ) + "                 <li>" + StringUtil.NewLine( ) + "                    <span class=\"handle\">" + StringUtil.NewLine( ) + "                      <i class=\"fas fa-ellipsis-v\"></i>" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-ellipsis-v\"></i>" + StringUtil.NewLine( ) + "                   </span>" + StringUtil.NewLine( ) + "                   <div  class=\"icheck-primary d-inline ml-2\">" + StringUtil.NewLine( ) + "                     <input type=\"checkbox\" value=\"\" name=\"todo5\" id=\"todoCheck5\">" + StringUtil.NewLine( ) + "                     <label for=\"todoCheck5\"></label>" + StringUtil.NewLine( ) + "                   </div>" + StringUtil.NewLine( ) + "                   <span class=\"text\">Check your messages and notifications</span>" + StringUtil.NewLine( ) + "                   <small class=\"badge badge-primary\"><i class=\"far fa-clock\"></i> 1 week</small>" + StringUtil.NewLine( ) + "                    <div class=\"tools\">" + StringUtil.NewLine( ) + "                      <i class=\"fas fa-edit\"></i>" + StringUtil.NewLine( ) + "                      <i class=\"fas fa-trash-o\"></i>" + StringUtil.NewLine( ) + "                    </div>" + StringUtil.NewLine( ) + "                  </li>" + StringUtil.NewLine( ) + "                 <li>" + StringUtil.NewLine( ) + "                   <span class=\"handle\">" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-ellipsis-v\"></i>" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-ellipsis-v\"></i>" + StringUtil.NewLine( ) + "                    </span>" + StringUtil.NewLine( ) + "                    <div  class=\"icheck-primary d-inline ml-2\">" + StringUtil.NewLine( ) + "                     <input type=\"checkbox\" value=\"\" name=\"todo6\" id=\"todoCheck6\">" + StringUtil.NewLine( ) + "                      <label for=\"todoCheck6\"></label>" + StringUtil.NewLine( ) + "                    </div>" + StringUtil.NewLine( ) + "                    <span class=\"text\">Let theme shine like a star</span>" + StringUtil.NewLine( ) + "                    <small class=\"badge badge-secondary\"><i class=\"far fa-clock\"></i> 1 month</small>" + StringUtil.NewLine( ) + "                   <div class=\"tools\">" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-edit\"></i>" + StringUtil.NewLine( ) + "                     <i class=\"fas fa-trash-o\"></i>" + StringUtil.NewLine( ) + "                   </div>" + StringUtil.NewLine( ) + "                 </li>" + StringUtil.NewLine( ) + "                </ul>" + StringUtil.NewLine( ) + "             </div>" + StringUtil.NewLine( ) + "              <!-- /.card-body -->" + StringUtil.NewLine( ) + "             <div class=\"card-footer clearfix\">" + StringUtil.NewLine( ) + "               <button type=\"button\" class=\"btn btn-primary float-right\"><i class=\"fas fa-plus\"></i> Add item</button>" + StringUtil.NewLine( ) + "             </div>" + StringUtil.NewLine( ) + "           </div>" + StringUtil.NewLine( ) + "            <!-- /.card -->" + StringUtil.NewLine( ) + "         </section>" + StringUtil.NewLine( ) + "          <!-- /.Left col -->" + StringUtil.NewLine( ) + "          <!-- right col (We are only adding the ID to make the widgets sortable)-->" + StringUtil.NewLine( ) + "         <section class=\"col-lg-5 connectedSortable\">" + StringUtil.NewLine( ) + "                <!-- /. tools -->" + StringUtil.NewLine( ) + "             </div>" + StringUtil.NewLine( ) + "            <!-- /.card-header -->" + StringUtil.NewLine( ) + "             <div class=\"card-body pt-0\">" + StringUtil.NewLine( ) + "               <!--The calendar -->" + StringUtil.NewLine( ) + "               <div id=\"calendar\" style=\"width: 100%\"></div>" + StringUtil.NewLine( ) + "             </div>" + StringUtil.NewLine( ) + "             <!-- /.card-body -->" + StringUtil.NewLine( ) + "           </div>" + StringUtil.NewLine( ) + "           <!-- /.card -->" + StringUtil.NewLine( ) + "       </section>" + StringUtil.NewLine( ) + "        <!-- right col -->" + StringUtil.NewLine( ) + "      </div>" + StringUtil.NewLine( ) + "      <!-- /.row (main row) -->" + StringUtil.NewLine( ) + "    </div><!-- /.container-fluid -->" + StringUtil.NewLine( ) + "  </section>";
         AV8vScript2 = "  </section></div></div>";
         lblTxtscrip1_Caption = AV7vScript;
         AssignProp("", true, lblTxtscrip1_Internalname, "Caption", lblTxtscrip1_Caption, true);
         lblTxtscript2_Caption = AV8vScript2;
         AssignProp("", true, lblTxtscript2_Internalname, "Caption", lblTxtscript2_Caption, true);
      }

      protected void nextLoad( )
      {
      }

      protected void E121P2( )
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
         PA1P2( ) ;
         WS1P2( ) ;
         WE1P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?20235211524374", true, true);
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
            context.AddJavascriptSource("wp_principal.js", "?20235211524375", false, true);
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
         AV8vScript2 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short initialized ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
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
      private string sDynURL ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV7vScript ;
      private string AV8vScript2 ;
      private string AV5vRuta ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contholder1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV6HttpRequest ;
      private GXWebForm Form ;
   }

}
