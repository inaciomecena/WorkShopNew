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
   public class sellersandproducts : GXDataArea
   {
      public sellersandproducts( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public sellersandproducts( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_32 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_32"), "."));
               nGXsfl_32_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_32_idx"), "."));
               sGXsfl_32_idx = GetPar( "sGXsfl_32_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               A10SellerId = (short)(NumberUtil.Val( GetPar( "SellerId"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( A10SellerId) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid2") == 0 )
            {
               nRC_GXsfl_15 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."));
               nGXsfl_15_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."));
               sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid2_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid2") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid2_refresh( ) ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         PA0M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0M2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202351822114959", false, true);
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sellersandproducts.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, ",", "")));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE0M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0M2( ) ;
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
         return formatLink("sellersandproducts.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SellersAndProducts" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sellers And Products" ;
      }

      protected void WB0M0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Sellers And Products", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_SellersAndProducts.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable5_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid2Container.SetIsFreestyle(true);
            Grid2Container.SetWrapped(nGXWrapped);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid2Container"+"DivS\" data-gxgridid=\"15\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid2_Internalname, subGrid2_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               Grid2Container.AddObjectProperty("GridName", "Grid2");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid2Container = new GXWebGrid( context);
               }
               else
               {
                  Grid2Container.Clear();
               }
               Grid2Container.SetIsFreestyle(true);
               Grid2Container.SetWrapped(nGXWrapped);
               Grid2Container.AddObjectProperty("GridName", "Grid2");
               Grid2Container.AddObjectProperty("Header", subGrid2_Header);
               Grid2Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               Grid2Container.AddObjectProperty("Class", "FreeStyleGrid");
               Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("CmpContext", "");
               Grid2Container.AddObjectProperty("InMasterPage", "false");
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", context.convertURL( A19SellerPhoto));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", StringUtil.RTrim( A18SellerName));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Qty), 4, 0, ".", "")));
               Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavQty_Enabled), 5, 0, ".", "")));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectedindex), 4, 0, ".", "")));
               Grid2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowselection), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectioncolor), 9, 0, ".", "")));
               Grid2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowhovering), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Hoveringcolor), 9, 0, ".", "")));
               Grid2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowcollapsing), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
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
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 32 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! isAjaxCallMode( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0M2( )
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
            Form.Meta.addItem("description", "Sellers And Products", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0M0( ) ;
      }

      protected void WS0M2( )
      {
         START0M2( ) ;
         EVT0M2( ) ;
      }

      protected void EVT0M2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) )
                           {
                              nGXsfl_15_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              A19SellerPhoto = cgiGet( edtSellerPhoto_Internalname);
                              AssignProp("", false, edtSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), !bGXsfl_15_Refreshing);
                              AssignProp("", false, edtSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
                              A18SellerName = cgiGet( edtSellerName_Internalname);
                              AV5Qty = (short)(context.localUtil.CToN( cgiGet( edtavQty_Internalname), ",", "."));
                              AssignAttri("", false, edtavQty_Internalname, StringUtil.LTrimStr( (decimal)(AV5Qty), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E110M2 ();
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
                                 }
                              }
                              else
                              {
                                 sEvtType = StringUtil.Right( sEvt, 4);
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                                 if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 )
                                 {
                                    nGXsfl_32_idx = (int)(NumberUtil.Val( sEvtType, "."));
                                    sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0") + sGXsfl_15_idx;
                                    SubsflControlProps_323( ) ;
                                    A12ProductId = (short)(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", "."));
                                    A13ProductName = cgiGet( edtProductName_Internalname);
                                    A28ProductPhoto = cgiGet( edtProductPhoto_Internalname);
                                    AssignProp("", false, edtProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40003ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), !bGXsfl_32_Refreshing);
                                    AssignProp("", false, edtProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
                                    A7CategoryName = cgiGet( edtCategoryName_Internalname);
                                    A27ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ",", ".");
                                    sEvtType = StringUtil.Right( sEvt, 1);
                                    if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                                    {
                                       sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                       if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                       {
                                          context.wbHandled = 1;
                                          dynload_actions( ) ;
                                          E120M3 ();
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0M2( )
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

      protected void PA0M2( )
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

      protected void gxnrGrid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid2Container)) ;
         /* End function gxnrGrid2_newrow */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_323( ) ;
         while ( nGXsfl_32_idx <= nRC_GXsfl_32 )
         {
            sendrow_323( ) ;
            nGXsfl_32_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_32_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_32_idx+1);
            sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0") + sGXsfl_15_idx;
            SubsflControlProps_323( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( short A10SellerId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0M3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void gxgrGrid2_refresh( )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID2_nCurrentRecord = 0;
         RF0M2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid2_refresh */
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
         RF0M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavQty_Enabled = 0;
         AssignProp("", false, edtavQty_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavQty_Enabled), 5, 0), !bGXsfl_15_Refreshing);
      }

      protected void RF0M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid2Container.ClearRows();
         }
         wbStart = 15;
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
         Grid2Container.AddObjectProperty("GridName", "Grid2");
         Grid2Container.AddObjectProperty("CmpContext", "");
         Grid2Container.AddObjectProperty("InMasterPage", "false");
         Grid2Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Grid2Container.AddObjectProperty("Class", "FreeStyleGrid");
         Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
         Grid2Container.PageSize = subGrid2_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_152( ) ;
            /* Using cursor H000M3 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A10SellerId = H000M3_A10SellerId[0];
               A18SellerName = H000M3_A18SellerName[0];
               A40001SellerPhoto_GXI = H000M3_A40001SellerPhoto_GXI[0];
               AssignProp("", false, edtSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), !bGXsfl_15_Refreshing);
               AssignProp("", false, edtSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
               A40000GXC1 = H000M3_A40000GXC1[0];
               n40000GXC1 = H000M3_n40000GXC1[0];
               A19SellerPhoto = H000M3_A19SellerPhoto[0];
               AssignProp("", false, edtSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), !bGXsfl_15_Refreshing);
               AssignProp("", false, edtSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
               A40000GXC1 = H000M3_A40000GXC1[0];
               n40000GXC1 = H000M3_n40000GXC1[0];
               E110M2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 15;
            WB0M0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0M2( )
      {
      }

      protected void RF0M3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 32;
         nGXsfl_32_idx = 1;
         sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0") + sGXsfl_15_idx;
         SubsflControlProps_323( ) ;
         bGXsfl_32_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_323( ) ;
            /* Using cursor H000M4 */
            pr_default.execute(1, new Object[] {A10SellerId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A6CategoryId = H000M4_A6CategoryId[0];
               A27ProductPrice = H000M4_A27ProductPrice[0];
               A7CategoryName = H000M4_A7CategoryName[0];
               A40003ProductPhoto_GXI = H000M4_A40003ProductPhoto_GXI[0];
               AssignProp("", false, edtProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40003ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), !bGXsfl_32_Refreshing);
               AssignProp("", false, edtProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
               A13ProductName = H000M4_A13ProductName[0];
               A12ProductId = H000M4_A12ProductId[0];
               A28ProductPhoto = H000M4_A28ProductPhoto[0];
               AssignProp("", false, edtProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40003ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), !bGXsfl_32_Refreshing);
               AssignProp("", false, edtProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
               A7CategoryName = H000M4_A7CategoryName[0];
               E120M3 ();
               pr_default.readNext(1);
            }
            pr_default.close(1);
            wbEnd = 32;
            WB0M0( ) ;
         }
         bGXsfl_32_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0M3( )
      {
      }

      protected int subGrid2_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavQty_Enabled = 0;
         AssignProp("", false, edtavQty_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavQty_Enabled), 5, 0), !bGXsfl_15_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_15"), ",", "."));
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

      private void E110M2( )
      {
         /* Grid2_Load Routine */
         returnInSub = false;
         AV5Qty = 0;
         AssignAttri("", false, edtavQty_Internalname, StringUtil.LTrimStr( (decimal)(AV5Qty), 4, 0));
         AV5Qty = (short)(A40000GXC1);
         AssignAttri("", false, edtavQty_Internalname, StringUtil.LTrimStr( (decimal)(AV5Qty), 4, 0));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, Grid2Row);
         }
         /*  Sending Event outputs  */
      }

      private void E120M3( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 32;
         }
         sendrow_323( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_32_Refreshing )
         {
            DoAjaxLoad(32, Grid1Row);
         }
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
         PA0M2( ) ;
         WS0M2( ) ;
         WE0M2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202351822115027", true, true);
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
            context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("sellersandproducts.js", "?202351822115027", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_323( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_32_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_32_idx;
         edtProductPhoto_Internalname = "PRODUCTPHOTO_"+sGXsfl_32_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_32_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_32_idx;
      }

      protected void SubsflControlProps_fel_323( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_32_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_32_fel_idx;
         edtProductPhoto_Internalname = "PRODUCTPHOTO_"+sGXsfl_32_fel_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_32_fel_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_32_fel_idx;
      }

      protected void sendrow_323( )
      {
         SubsflControlProps_323( ) ;
         WB0M0( ) ;
         Grid1Row = GXWebRow.GetNew(context,Grid1Container);
         if ( subGrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
         }
         else if ( subGrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid1_Backstyle = 0;
            subGrid1_Backcolor = subGrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Uniform";
            }
         }
         else if ( subGrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
            subGrid1_Backcolor = (int)(0x0);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_32_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+""+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_32_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12ProductId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)32,(short)1,(short)-1,(short)0,(bool)false,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,StringUtil.RTrim( A13ProductName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)150,(string)"px",(short)30,(string)"px",(short)20,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)-1,(bool)false,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A28ProductPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40003ProductPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40003ProductPhoto_GXI : context.PathToRelativeUrl( A28ProductPhoto));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A28ProductPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoryName_Internalname,StringUtil.RTrim( A7CategoryName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoryName_Jsonclick,(short)0,(string)"",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)-1,(bool)false,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 10, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A27ProductPrice, "$ ZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductPrice_Jsonclick,(short)0,(string)"",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes0M3( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_32_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_32_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_32_idx+1);
         sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0") + sGXsfl_15_idx;
         SubsflControlProps_323( ) ;
         /* End function sendrow_323 */
      }

      protected void SubsflControlProps_152( )
      {
         edtSellerPhoto_Internalname = "SELLERPHOTO_"+sGXsfl_15_idx;
         edtSellerName_Internalname = "SELLERNAME_"+sGXsfl_15_idx;
         edtavQty_Internalname = "vQTY_"+sGXsfl_15_idx;
         subGrid1_Internalname = "GRID1_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtSellerPhoto_Internalname = "SELLERPHOTO_"+sGXsfl_15_fel_idx;
         edtSellerName_Internalname = "SELLERNAME_"+sGXsfl_15_fel_idx;
         edtavQty_Internalname = "vQTY_"+sGXsfl_15_fel_idx;
         subGrid1_Internalname = "GRID1_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         SubsflControlProps_152( ) ;
         WB0M0( ) ;
         Grid2Row = GXWebRow.GetNew(context,Grid2Container);
         if ( subGrid2_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid2_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
         }
         else if ( subGrid2_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid2_Backstyle = 0;
            subGrid2_Backcolor = subGrid2_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Uniform";
            }
         }
         else if ( subGrid2_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
            subGrid2_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrid2_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Even";
               }
            }
            else
            {
               subGrid2_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGrid2_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_15_idx+"\">") ;
         }
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid2table_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable2_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"Right",(string)"Middle",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"Seller Photo",(string)"col-sm-3 ImageAttributeLabel",(short)0,(bool)true,(string)""});
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A19SellerPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001SellerPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.PathToRelativeUrl( A19SellerPhoto));
         Grid2Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtSellerPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A19SellerPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Right",(string)"Middle",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"left",(string)"Middle",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtSellerName_Internalname,(string)"Seller Name",(string)"col-sm-3 ",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSellerName_Internalname,StringUtil.RTrim( A18SellerName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSellerName_Jsonclick,(short)0,(string)"",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)20,(string)"chr",(short)1,(string)"row",(short)20,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"Middle",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable3_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /*  Child Grid Control  */
         Grid2Row.AddColumnProperties("subfile", -1, isAjaxCallMode( ), new Object[] {(string)"Grid1Container"});
         if ( isAjaxCallMode( ) )
         {
            Grid1Container = new GXWebGrid( context);
         }
         else
         {
            Grid1Container.Clear();
         }
         Grid1Container.SetWrapped(nGXWrapped);
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"32\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Product Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(150), 4, 0)+"px"+" class=\""+""+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+""+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Category") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+""+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A13ProductName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A28ProductPhoto));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A7CategoryName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 10, 2, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
         RF0M3( ) ;
         nRC_GXsfl_32 = (int)(nGXsfl_32_idx-1);
         send_integrity_footer_hashes( ) ;
         GXCCtl = "nRC_GXsfl_32_" + sGXsfl_15_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_32), 8, 0, ",", "")));
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "</table>") ;
         }
         else
         {
            if ( ! isAjaxCallMode( ) )
            {
               GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"_"+sGXsfl_15_idx, Grid1Container.ToJavascriptSource());
            }
            if ( isAjaxCallMode( ) )
            {
               Grid2Row.AddGrid("Grid1", Grid1Container);
            }
            if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
            {
               GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V_"+sGXsfl_15_idx, Grid1Container.GridValuesHidden());
            }
            else
            {
               context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V_"+sGXsfl_15_idx+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
            }
         }
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Right",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable4_Internalname+"_"+sGXsfl_15_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Right",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavQty_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid2Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavQty_Internalname,(string)"Total",(string)"col-sm-3 ",(short)1,(bool)true,(string)""});
         /* Div Control */
         Grid2Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavQty_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Qty), 4, 0, ",", "")),StringUtil.LTrim( ((edtavQty_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Qty), "ZZZ9") : context.localUtil.Format( (decimal)(AV5Qty), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavQty_Jsonclick,(short)0,(string)"",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavQty_Enabled,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Right",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Right",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid2Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes0M2( ) ;
         /* End of Columns property logic. */
         Grid2Container.AddRow(Grid2Row);
         nGXsfl_15_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divTable1_Internalname = "TABLE1";
         edtSellerPhoto_Internalname = "SELLERPHOTO";
         edtSellerName_Internalname = "SELLERNAME";
         divTable2_Internalname = "TABLE2";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductPhoto_Internalname = "PRODUCTPHOTO";
         edtCategoryName_Internalname = "CATEGORYNAME";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         divTable3_Internalname = "TABLE3";
         edtavQty_Internalname = "vQTY";
         divTable4_Internalname = "TABLE4";
         divGrid2table_Internalname = "GRID2TABLE";
         divTable5_Internalname = "TABLE5";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
         subGrid2_Internalname = "GRID2";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavQty_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtSellerName_Jsonclick = "";
         subGrid2_Class = "FreeStyleGrid";
         edtProductPrice_Jsonclick = "";
         edtCategoryName_Jsonclick = "";
         edtProductName_Jsonclick = "";
         edtProductId_Jsonclick = "";
         subGrid1_Class = "";
         subGrid1_Backcolorstyle = 0;
         subGrid2_Allowcollapsing = 0;
         edtavQty_Enabled = 0;
         subGrid2_Backcolorstyle = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Sellers And Products";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'A10SellerId',fld:'SELLERID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID2.LOAD","{handler:'E110M2',iparms:[]");
         setEventMetadata("GRID2.LOAD",",oparms:[{av:'AV5Qty',fld:'vQTY',pic:'ZZZ9'},{av:'A40000GXC1',fld:'GXC1',pic:'999999999'}]}");
         setEventMetadata("NULL","{handler:'Valid_Productprice',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Qty',iparms:[]");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         Grid2Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid2_Header = "";
         Grid2Column = new GXWebColumn();
         A19SellerPhoto = "";
         A18SellerName = "";
         Grid1Container = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A40001SellerPhoto_GXI = "";
         A13ProductName = "";
         A28ProductPhoto = "";
         A40003ProductPhoto_GXI = "";
         A7CategoryName = "";
         scmdbuf = "";
         H000M3_A10SellerId = new short[1] ;
         H000M3_A18SellerName = new string[] {""} ;
         H000M3_A40001SellerPhoto_GXI = new string[] {""} ;
         H000M3_A40000GXC1 = new int[1] ;
         H000M3_n40000GXC1 = new bool[] {false} ;
         H000M3_A19SellerPhoto = new string[] {""} ;
         H000M4_A6CategoryId = new short[1] ;
         H000M4_A10SellerId = new short[1] ;
         H000M4_A27ProductPrice = new decimal[1] ;
         H000M4_A7CategoryName = new string[] {""} ;
         H000M4_A40003ProductPhoto_GXI = new string[] {""} ;
         H000M4_A13ProductName = new string[] {""} ;
         H000M4_A12ProductId = new short[1] ;
         H000M4_A28ProductPhoto = new string[] {""} ;
         Grid2Row = new GXWebRow();
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         subGrid2_Linesclass = "";
         Grid1Column = new GXWebColumn();
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sellersandproducts__default(),
            new Object[][] {
                new Object[] {
               H000M3_A10SellerId, H000M3_A18SellerName, H000M3_A40001SellerPhoto_GXI, H000M3_A40000GXC1, H000M3_n40000GXC1, H000M3_A19SellerPhoto
               }
               , new Object[] {
               H000M4_A6CategoryId, H000M4_A10SellerId, H000M4_A27ProductPrice, H000M4_A7CategoryName, H000M4_A40003ProductPhoto_GXI, H000M4_A13ProductName, H000M4_A12ProductId, H000M4_A28ProductPhoto
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavQty_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short A10SellerId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid2_Backcolorstyle ;
      private short AV5Qty ;
      private short subGrid2_Allowselection ;
      private short subGrid2_Allowhovering ;
      private short subGrid2_Allowcollapsing ;
      private short subGrid2_Collapsed ;
      private short A12ProductId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A6CategoryId ;
      private short subGrid1_Backstyle ;
      private short subGrid2_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short GRID2_nEOF ;
      private short GRID1_nEOF ;
      private int nRC_GXsfl_32 ;
      private int nGXsfl_32_idx=1 ;
      private int nRC_GXsfl_15 ;
      private int nGXsfl_15_idx=1 ;
      private int edtavQty_Enabled ;
      private int subGrid2_Selectedindex ;
      private int subGrid2_Selectioncolor ;
      private int subGrid2_Hoveringcolor ;
      private int subGrid2_Islastpage ;
      private int subGrid1_Islastpage ;
      private int A40000GXC1 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid2_Backcolor ;
      private int subGrid2_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nCurrentRecord ;
      private long GRID2_nCurrentRecord ;
      private long GRID2_nFirstRecordOnPage ;
      private long GRID1_nFirstRecordOnPage ;
      private decimal A27ProductPrice ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_32_idx="0001" ;
      private string sGXsfl_15_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTable5_Internalname ;
      private string sStyleString ;
      private string subGrid2_Internalname ;
      private string subGrid2_Header ;
      private string A18SellerName ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtSellerPhoto_Internalname ;
      private string edtSellerName_Internalname ;
      private string edtavQty_Internalname ;
      private string edtProductId_Internalname ;
      private string A13ProductName ;
      private string edtProductName_Internalname ;
      private string edtProductPhoto_Internalname ;
      private string A7CategoryName ;
      private string edtCategoryName_Internalname ;
      private string edtProductPrice_Internalname ;
      private string scmdbuf ;
      private string sGXsfl_32_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string edtCategoryName_Jsonclick ;
      private string edtProductPrice_Jsonclick ;
      private string subGrid1_Internalname ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGrid2_Class ;
      private string subGrid2_Linesclass ;
      private string divGrid2table_Internalname ;
      private string divTable2_Internalname ;
      private string edtSellerName_Jsonclick ;
      private string divTable3_Internalname ;
      private string subGrid1_Header ;
      private string GXCCtl ;
      private string divTable4_Internalname ;
      private string edtavQty_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool bGXsfl_32_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n40000GXC1 ;
      private bool returnInSub ;
      private bool A28ProductPhoto_IsBlob ;
      private bool A19SellerPhoto_IsBlob ;
      private string A40001SellerPhoto_GXI ;
      private string A40003ProductPhoto_GXI ;
      private string A19SellerPhoto ;
      private string A28ProductPhoto ;
      private GXWebGrid Grid2Container ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid2Row ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid2Column ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000M3_A10SellerId ;
      private string[] H000M3_A18SellerName ;
      private string[] H000M3_A40001SellerPhoto_GXI ;
      private int[] H000M3_A40000GXC1 ;
      private bool[] H000M3_n40000GXC1 ;
      private string[] H000M3_A19SellerPhoto ;
      private short[] H000M4_A6CategoryId ;
      private short[] H000M4_A10SellerId ;
      private decimal[] H000M4_A27ProductPrice ;
      private string[] H000M4_A7CategoryName ;
      private string[] H000M4_A40003ProductPhoto_GXI ;
      private string[] H000M4_A13ProductName ;
      private short[] H000M4_A12ProductId ;
      private string[] H000M4_A28ProductPhoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class sellersandproducts__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH000M3;
          prmH000M3 = new Object[] {
          };
          Object[] prmH000M4;
          prmH000M4 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000M3", "SELECT T1.[SellerId], T1.[SellerName], T1.[SellerPhoto_GXI], COALESCE( T2.[GXC1], 0) AS GXC1, T1.[SellerPhoto] FROM ([Seller] T1 LEFT JOIN (SELECT COUNT(*) AS GXC1, [SellerId] FROM [Product] GROUP BY [SellerId] ) T2 ON T2.[SellerId] = T1.[SellerId]) ORDER BY T1.[SellerId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000M3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000M4", "SELECT T1.[CategoryId], T1.[SellerId], T1.[ProductPrice], T2.[CategoryName], T1.[ProductPhoto_GXI], T1.[ProductName], T1.[ProductId], T1.[ProductPhoto] FROM ([Product] T1 INNER JOIN [Category] T2 ON T2.[CategoryId] = T1.[CategoryId]) WHERE T1.[SellerId] = @SellerId ORDER BY T1.[SellerId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000M4,11, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
                return;
       }
    }

 }

}
