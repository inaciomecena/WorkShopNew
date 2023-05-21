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
   public class menu : GXDataArea
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
               AV7MenuXid = (short)(NumberUtil.Val( GetPar( "MenuXid"), "."));
               AssignAttri("", false, "AV7MenuXid", StringUtil.LTrimStr( (decimal)(AV7MenuXid), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vMENUXID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MenuXid), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Menu", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMenuXDesc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public menu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public menu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_MenuXid )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MenuXid = aP1_MenuXid;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbMenXEst = new GXCombobox();
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
         if ( cmbMenXEst.ItemCount > 0 )
         {
            A5MenXEst = cmbMenXEst.getValidValue(A5MenXEst);
            n5MenXEst = false;
            AssignAttri("", false, "A5MenXEst", A5MenXEst);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMenXEst.CurrentValue = StringUtil.RTrim( A5MenXEst);
            AssignProp("", false, cmbMenXEst_Internalname, "Values", cmbMenXEst.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Menu", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Menu.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Menu.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuXid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuXid_Internalname, "Xid", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMenuXid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1MenuXid), 4, 0, ",", "")), StringUtil.LTrim( ((edtMenuXid_Enabled!=0) ? context.localUtil.Format( (decimal)(A1MenuXid), "ZZZ9") : context.localUtil.Format( (decimal)(A1MenuXid), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuXid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMenuXid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuXDesc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuXDesc_Internalname, "XDesc", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenuXDesc_Internalname, A2MenuXDesc, StringUtil.RTrim( context.localUtil.Format( A2MenuXDesc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuXDesc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMenuXDesc_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuXPosi_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuXPosi_Internalname, "Position", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenuXPosi_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3MenuXPosi), 4, 0, ",", "")), StringUtil.LTrim( ((edtMenuXPosi_Enabled!=0) ? context.localUtil.Format( (decimal)(A3MenuXPosi), "ZZZ9") : context.localUtil.Format( (decimal)(A3MenuXPosi), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuXPosi_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMenuXPosi_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenXUrl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenXUrl_Internalname, "Url", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenXUrl_Internalname, A4MenXUrl, StringUtil.RTrim( context.localUtil.Format( A4MenXUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", A4MenXUrl, "_blank", "", "", edtMenXUrl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMenXUrl_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Url", "left", true, "", "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbMenXEst_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMenXEst_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMenXEst, cmbMenXEst_Internalname, StringUtil.RTrim( A5MenXEst), 1, cmbMenXEst_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbMenXEst.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 1, "HLP_Menu.htm");
         cmbMenXEst.CurrentValue = StringUtil.RTrim( A5MenXEst);
         AssignProp("", false, cmbMenXEst_Internalname, "Values", (string)(cmbMenXEst.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Menu.htm");
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
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1MenuXid = (short)(context.localUtil.CToN( cgiGet( "Z1MenuXid"), ",", "."));
               Z2MenuXDesc = cgiGet( "Z2MenuXDesc");
               n2MenuXDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A2MenuXDesc)) ? true : false);
               Z3MenuXPosi = (short)(context.localUtil.CToN( cgiGet( "Z3MenuXPosi"), ",", "."));
               n3MenuXPosi = ((0==A3MenuXPosi) ? true : false);
               Z4MenXUrl = cgiGet( "Z4MenXUrl");
               n4MenXUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A4MenXUrl)) ? true : false);
               Z5MenXEst = cgiGet( "Z5MenXEst");
               n5MenXEst = (String.IsNullOrEmpty(StringUtil.RTrim( A5MenXEst)) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7MenuXid = (short)(context.localUtil.CToN( cgiGet( "vMENUXID"), ",", "."));
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A1MenuXid = (short)(context.localUtil.CToN( cgiGet( edtMenuXid_Internalname), ",", "."));
               AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
               A2MenuXDesc = cgiGet( edtMenuXDesc_Internalname);
               n2MenuXDesc = false;
               AssignAttri("", false, "A2MenuXDesc", A2MenuXDesc);
               n2MenuXDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A2MenuXDesc)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMenuXPosi_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMenuXPosi_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MENUXPOSI");
                  AnyError = 1;
                  GX_FocusControl = edtMenuXPosi_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A3MenuXPosi = 0;
                  n3MenuXPosi = false;
                  AssignAttri("", false, "A3MenuXPosi", StringUtil.LTrimStr( (decimal)(A3MenuXPosi), 4, 0));
               }
               else
               {
                  A3MenuXPosi = (short)(context.localUtil.CToN( cgiGet( edtMenuXPosi_Internalname), ",", "."));
                  n3MenuXPosi = false;
                  AssignAttri("", false, "A3MenuXPosi", StringUtil.LTrimStr( (decimal)(A3MenuXPosi), 4, 0));
               }
               n3MenuXPosi = ((0==A3MenuXPosi) ? true : false);
               A4MenXUrl = cgiGet( edtMenXUrl_Internalname);
               n4MenXUrl = false;
               AssignAttri("", false, "A4MenXUrl", A4MenXUrl);
               n4MenXUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A4MenXUrl)) ? true : false);
               cmbMenXEst.CurrentValue = cgiGet( cmbMenXEst_Internalname);
               A5MenXEst = cgiGet( cmbMenXEst_Internalname);
               n5MenXEst = false;
               AssignAttri("", false, "A5MenXEst", A5MenXEst);
               n5MenXEst = (String.IsNullOrEmpty(StringUtil.RTrim( A5MenXEst)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Menu");
               A1MenuXid = (short)(context.localUtil.CToN( cgiGet( edtMenuXid_Internalname), ",", "."));
               AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
               forbiddenHiddens.Add("MenuXid", context.localUtil.Format( (decimal)(A1MenuXid), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1MenuXid != Z1MenuXid ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("menu:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A1MenuXid = (short)(NumberUtil.Val( GetPar( "MenuXid"), "."));
                  AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
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
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MENUXID");
                        AnyError = 1;
                        GX_FocusControl = edtMenuXid_Internalname;
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
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12012 ();
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
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
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
            DisableAttributes011( ) ;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
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

      protected void E12012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwmenu.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2MenuXDesc = T00013_A2MenuXDesc[0];
               Z3MenuXPosi = T00013_A3MenuXPosi[0];
               Z4MenXUrl = T00013_A4MenXUrl[0];
               Z5MenXEst = T00013_A5MenXEst[0];
            }
            else
            {
               Z2MenuXDesc = A2MenuXDesc;
               Z3MenuXPosi = A3MenuXPosi;
               Z4MenXUrl = A4MenXUrl;
               Z5MenXEst = A5MenXEst;
            }
         }
         if ( GX_JID == -4 )
         {
            Z1MenuXid = A1MenuXid;
            Z2MenuXDesc = A2MenuXDesc;
            Z3MenuXPosi = A3MenuXPosi;
            Z4MenXUrl = A4MenXUrl;
            Z5MenXEst = A5MenXEst;
         }
      }

      protected void standaloneNotModal( )
      {
         edtMenuXid_Enabled = 0;
         AssignProp("", false, edtMenuXid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuXid_Enabled), 5, 0), true);
         edtMenuXid_Enabled = 0;
         AssignProp("", false, edtMenuXid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuXid_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MenuXid) )
         {
            A1MenuXid = AV7MenuXid;
            AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
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

      protected void Load011( )
      {
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A1MenuXid});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A2MenuXDesc = T00014_A2MenuXDesc[0];
            n2MenuXDesc = T00014_n2MenuXDesc[0];
            AssignAttri("", false, "A2MenuXDesc", A2MenuXDesc);
            A3MenuXPosi = T00014_A3MenuXPosi[0];
            n3MenuXPosi = T00014_n3MenuXPosi[0];
            AssignAttri("", false, "A3MenuXPosi", StringUtil.LTrimStr( (decimal)(A3MenuXPosi), 4, 0));
            A4MenXUrl = T00014_A4MenXUrl[0];
            n4MenXUrl = T00014_n4MenXUrl[0];
            AssignAttri("", false, "A4MenXUrl", A4MenXUrl);
            A5MenXEst = T00014_A5MenXEst[0];
            n5MenXEst = T00014_n5MenXEst[0];
            AssignAttri("", false, "A5MenXEst", A5MenXEst);
            ZM011( -4) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV11Pgmname = "Menu";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Menu";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         if ( ! ( GxRegex.IsMatch(A4MenXUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || String.IsNullOrEmpty(StringUtil.RTrim( A4MenXUrl)) ) )
         {
            GX_msglist.addItem("O valor de Url não coincide com o padrão especificado", "OutOfRange", 1, "MENXURL");
            AnyError = 1;
            GX_FocusControl = edtMenXUrl_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A1MenuXid});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1MenuXid});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 4) ;
            RcdFound1 = 1;
            A1MenuXid = T00013_A1MenuXid[0];
            AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
            A2MenuXDesc = T00013_A2MenuXDesc[0];
            n2MenuXDesc = T00013_n2MenuXDesc[0];
            AssignAttri("", false, "A2MenuXDesc", A2MenuXDesc);
            A3MenuXPosi = T00013_A3MenuXPosi[0];
            n3MenuXPosi = T00013_n3MenuXPosi[0];
            AssignAttri("", false, "A3MenuXPosi", StringUtil.LTrimStr( (decimal)(A3MenuXPosi), 4, 0));
            A4MenXUrl = T00013_A4MenXUrl[0];
            n4MenXUrl = T00013_n4MenXUrl[0];
            AssignAttri("", false, "A4MenXUrl", A4MenXUrl);
            A5MenXEst = T00013_A5MenXEst[0];
            n5MenXEst = T00013_n5MenXEst[0];
            AssignAttri("", false, "A5MenXEst", A5MenXEst);
            Z1MenuXid = A1MenuXid;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A1MenuXid});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00016_A1MenuXid[0] < A1MenuXid ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00016_A1MenuXid[0] > A1MenuXid ) ) )
            {
               A1MenuXid = T00016_A1MenuXid[0];
               AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1MenuXid});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00017_A1MenuXid[0] > A1MenuXid ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00017_A1MenuXid[0] < A1MenuXid ) ) )
            {
               A1MenuXid = T00017_A1MenuXid[0];
               AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMenuXDesc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1MenuXid != Z1MenuXid )
               {
                  A1MenuXid = Z1MenuXid;
                  AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MENUXID");
                  AnyError = 1;
                  GX_FocusControl = edtMenuXid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMenuXDesc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtMenuXDesc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1MenuXid != Z1MenuXid )
               {
                  /* Insert record */
                  GX_FocusControl = edtMenuXDesc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MENUXID");
                     AnyError = 1;
                     GX_FocusControl = edtMenuXid_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMenuXDesc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( A1MenuXid != Z1MenuXid )
         {
            A1MenuXid = Z1MenuXid;
            AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MENUXID");
            AnyError = 1;
            GX_FocusControl = edtMenuXid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMenuXDesc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1MenuXid});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Menu"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2MenuXDesc, T00012_A2MenuXDesc[0]) != 0 ) || ( Z3MenuXPosi != T00012_A3MenuXPosi[0] ) || ( StringUtil.StrCmp(Z4MenXUrl, T00012_A4MenXUrl[0]) != 0 ) || ( StringUtil.StrCmp(Z5MenXEst, T00012_A5MenXEst[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z2MenuXDesc, T00012_A2MenuXDesc[0]) != 0 )
               {
                  GXUtil.WriteLog("menu:[seudo value changed for attri]"+"MenuXDesc");
                  GXUtil.WriteLogRaw("Old: ",Z2MenuXDesc);
                  GXUtil.WriteLogRaw("Current: ",T00012_A2MenuXDesc[0]);
               }
               if ( Z3MenuXPosi != T00012_A3MenuXPosi[0] )
               {
                  GXUtil.WriteLog("menu:[seudo value changed for attri]"+"MenuXPosi");
                  GXUtil.WriteLogRaw("Old: ",Z3MenuXPosi);
                  GXUtil.WriteLogRaw("Current: ",T00012_A3MenuXPosi[0]);
               }
               if ( StringUtil.StrCmp(Z4MenXUrl, T00012_A4MenXUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("menu:[seudo value changed for attri]"+"MenXUrl");
                  GXUtil.WriteLogRaw("Old: ",Z4MenXUrl);
                  GXUtil.WriteLogRaw("Current: ",T00012_A4MenXUrl[0]);
               }
               if ( StringUtil.StrCmp(Z5MenXEst, T00012_A5MenXEst[0]) != 0 )
               {
                  GXUtil.WriteLog("menu:[seudo value changed for attri]"+"MenXEst");
                  GXUtil.WriteLogRaw("Old: ",Z5MenXEst);
                  GXUtil.WriteLogRaw("Current: ",T00012_A5MenXEst[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Menu"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00018 */
                     pr_default.execute(6, new Object[] {n2MenuXDesc, A2MenuXDesc, n3MenuXPosi, A3MenuXPosi, n4MenXUrl, A4MenXUrl, n5MenXEst, A5MenXEst});
                     A1MenuXid = T00018_A1MenuXid[0];
                     AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Menu");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00019 */
                     pr_default.execute(7, new Object[] {n2MenuXDesc, A2MenuXDesc, n3MenuXPosi, A3MenuXPosi, n4MenXUrl, A4MenXUrl, n5MenXEst, A5MenXEst, A1MenuXid});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Menu");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Menu"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000110 */
                  pr_default.execute(8, new Object[] {A1MenuXid});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Menu");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Menu";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("menu",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("menu",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000111 */
         pr_default.execute(9);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A1MenuXid = T000111_A1MenuXid[0];
            AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A1MenuXid = T000111_A1MenuXid[0];
            AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtMenuXid_Enabled = 0;
         AssignProp("", false, edtMenuXid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuXid_Enabled), 5, 0), true);
         edtMenuXDesc_Enabled = 0;
         AssignProp("", false, edtMenuXDesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuXDesc_Enabled), 5, 0), true);
         edtMenuXPosi_Enabled = 0;
         AssignProp("", false, edtMenuXPosi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuXPosi_Enabled), 5, 0), true);
         edtMenXUrl_Enabled = 0;
         AssignProp("", false, edtMenXUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenXUrl_Enabled), 5, 0), true);
         cmbMenXEst.Enabled = 0;
         AssignProp("", false, cmbMenXEst_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMenXEst.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.AddJavascriptSource("gxcfg.js", "?20235211511530", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("menu.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7MenuXid,4,0))}, new string[] {"Gx_mode","MenuXid"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Menu");
         forbiddenHiddens.Add("MenuXid", context.localUtil.Format( (decimal)(A1MenuXid), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("menu:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1MenuXid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1MenuXid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z2MenuXDesc", Z2MenuXDesc);
         GxWebStd.gx_hidden_field( context, "Z3MenuXPosi", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3MenuXPosi), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z4MenXUrl", Z4MenXUrl);
         GxWebStd.gx_hidden_field( context, "Z5MenXEst", StringUtil.RTrim( Z5MenXEst));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vMENUXID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MenuXid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUXID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MenuXid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
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
         return formatLink("menu.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7MenuXid,4,0))}, new string[] {"Gx_mode","MenuXid"})  ;
      }

      public override string GetPgmname( )
      {
         return "Menu" ;
      }

      public override string GetPgmdesc( )
      {
         return "Menu" ;
      }

      protected void InitializeNonKey011( )
      {
         A2MenuXDesc = "";
         n2MenuXDesc = false;
         AssignAttri("", false, "A2MenuXDesc", A2MenuXDesc);
         n2MenuXDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A2MenuXDesc)) ? true : false);
         A3MenuXPosi = 0;
         n3MenuXPosi = false;
         AssignAttri("", false, "A3MenuXPosi", StringUtil.LTrimStr( (decimal)(A3MenuXPosi), 4, 0));
         n3MenuXPosi = ((0==A3MenuXPosi) ? true : false);
         A4MenXUrl = "";
         n4MenXUrl = false;
         AssignAttri("", false, "A4MenXUrl", A4MenXUrl);
         n4MenXUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A4MenXUrl)) ? true : false);
         A5MenXEst = "";
         n5MenXEst = false;
         AssignAttri("", false, "A5MenXEst", A5MenXEst);
         n5MenXEst = (String.IsNullOrEmpty(StringUtil.RTrim( A5MenXEst)) ? true : false);
         Z2MenuXDesc = "";
         Z3MenuXPosi = 0;
         Z4MenXUrl = "";
         Z5MenXEst = "";
      }

      protected void InitAll011( )
      {
         A1MenuXid = 0;
         AssignAttri("", false, "A1MenuXid", StringUtil.LTrimStr( (decimal)(A1MenuXid), 4, 0));
         InitializeNonKey011( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20235211511545", true, true);
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
         context.AddJavascriptSource("menu.js", "?20235211511545", false, true);
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
         edtMenuXid_Internalname = "MENUXID";
         edtMenuXDesc_Internalname = "MENUXDESC";
         edtMenuXPosi_Internalname = "MENUXPOSI";
         edtMenXUrl_Internalname = "MENXURL";
         cmbMenXEst_Internalname = "MENXEST";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Menu";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbMenXEst_Jsonclick = "";
         cmbMenXEst.Enabled = 1;
         edtMenXUrl_Jsonclick = "";
         edtMenXUrl_Enabled = 1;
         edtMenuXPosi_Jsonclick = "";
         edtMenuXPosi_Enabled = 1;
         edtMenuXDesc_Jsonclick = "";
         edtMenuXDesc_Enabled = 1;
         edtMenuXid_Jsonclick = "";
         edtMenuXid_Enabled = 0;
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
         cmbMenXEst.Name = "MENXEST";
         cmbMenXEst.WebTags = "";
         cmbMenXEst.addItem("A", "Activo", 0);
         cmbMenXEst.addItem("I", "Inactivo", 0);
         if ( cmbMenXEst.ItemCount > 0 )
         {
            A5MenXEst = cmbMenXEst.getValidValue(A5MenXEst);
            n5MenXEst = false;
            AssignAttri("", false, "A5MenXEst", A5MenXEst);
         }
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MenuXid',fld:'vMENUXID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MenuXid',fld:'vMENUXID',pic:'ZZZ9',hsh:true},{av:'A1MenuXid',fld:'MENUXID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12012',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MENUXID","{handler:'Valid_Menuxid',iparms:[]");
         setEventMetadata("VALID_MENUXID",",oparms:[]}");
         setEventMetadata("VALID_MENXURL","{handler:'Valid_Menxurl',iparms:[]");
         setEventMetadata("VALID_MENXURL",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z2MenuXDesc = "";
         Z4MenXUrl = "";
         Z5MenXEst = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A5MenXEst = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A2MenuXDesc = "";
         A4MenXUrl = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00014_A1MenuXid = new short[1] ;
         T00014_A2MenuXDesc = new string[] {""} ;
         T00014_n2MenuXDesc = new bool[] {false} ;
         T00014_A3MenuXPosi = new short[1] ;
         T00014_n3MenuXPosi = new bool[] {false} ;
         T00014_A4MenXUrl = new string[] {""} ;
         T00014_n4MenXUrl = new bool[] {false} ;
         T00014_A5MenXEst = new string[] {""} ;
         T00014_n5MenXEst = new bool[] {false} ;
         T00015_A1MenuXid = new short[1] ;
         T00013_A1MenuXid = new short[1] ;
         T00013_A2MenuXDesc = new string[] {""} ;
         T00013_n2MenuXDesc = new bool[] {false} ;
         T00013_A3MenuXPosi = new short[1] ;
         T00013_n3MenuXPosi = new bool[] {false} ;
         T00013_A4MenXUrl = new string[] {""} ;
         T00013_n4MenXUrl = new bool[] {false} ;
         T00013_A5MenXEst = new string[] {""} ;
         T00013_n5MenXEst = new bool[] {false} ;
         T00016_A1MenuXid = new short[1] ;
         T00017_A1MenuXid = new short[1] ;
         T00012_A1MenuXid = new short[1] ;
         T00012_A2MenuXDesc = new string[] {""} ;
         T00012_n2MenuXDesc = new bool[] {false} ;
         T00012_A3MenuXPosi = new short[1] ;
         T00012_n3MenuXPosi = new bool[] {false} ;
         T00012_A4MenXUrl = new string[] {""} ;
         T00012_n4MenXUrl = new bool[] {false} ;
         T00012_A5MenXEst = new string[] {""} ;
         T00012_n5MenXEst = new bool[] {false} ;
         T00018_A1MenuXid = new short[1] ;
         T000111_A1MenuXid = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.menu__default(),
            new Object[][] {
                new Object[] {
               T00012_A1MenuXid, T00012_A2MenuXDesc, T00012_n2MenuXDesc, T00012_A3MenuXPosi, T00012_n3MenuXPosi, T00012_A4MenXUrl, T00012_n4MenXUrl, T00012_A5MenXEst, T00012_n5MenXEst
               }
               , new Object[] {
               T00013_A1MenuXid, T00013_A2MenuXDesc, T00013_n2MenuXDesc, T00013_A3MenuXPosi, T00013_n3MenuXPosi, T00013_A4MenXUrl, T00013_n4MenXUrl, T00013_A5MenXEst, T00013_n5MenXEst
               }
               , new Object[] {
               T00014_A1MenuXid, T00014_A2MenuXDesc, T00014_n2MenuXDesc, T00014_A3MenuXPosi, T00014_n3MenuXPosi, T00014_A4MenXUrl, T00014_n4MenXUrl, T00014_A5MenXEst, T00014_n5MenXEst
               }
               , new Object[] {
               T00015_A1MenuXid
               }
               , new Object[] {
               T00016_A1MenuXid
               }
               , new Object[] {
               T00017_A1MenuXid
               }
               , new Object[] {
               T00018_A1MenuXid
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000111_A1MenuXid
               }
            }
         );
         AV11Pgmname = "Menu";
      }

      private short wcpOAV7MenuXid ;
      private short Z1MenuXid ;
      private short Z3MenuXPosi ;
      private short GxWebError ;
      private short AV7MenuXid ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1MenuXid ;
      private short A3MenuXPosi ;
      private short RcdFound1 ;
      private short GX_JID ;
      private short nIsDirty_1 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtMenuXid_Enabled ;
      private int edtMenuXDesc_Enabled ;
      private int edtMenuXPosi_Enabled ;
      private int edtMenXUrl_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z5MenXEst ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMenuXDesc_Internalname ;
      private string A5MenXEst ;
      private string cmbMenXEst_Internalname ;
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
      private string edtMenuXid_Internalname ;
      private string edtMenuXid_Jsonclick ;
      private string edtMenuXDesc_Jsonclick ;
      private string edtMenuXPosi_Internalname ;
      private string edtMenuXPosi_Jsonclick ;
      private string edtMenXUrl_Internalname ;
      private string edtMenXUrl_Jsonclick ;
      private string cmbMenXEst_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode1 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n5MenXEst ;
      private bool n2MenuXDesc ;
      private bool n3MenuXPosi ;
      private bool n4MenXUrl ;
      private bool returnInSub ;
      private string Z2MenuXDesc ;
      private string Z4MenXUrl ;
      private string A2MenuXDesc ;
      private string A4MenXUrl ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMenXEst ;
      private IDataStoreProvider pr_default ;
      private short[] T00014_A1MenuXid ;
      private string[] T00014_A2MenuXDesc ;
      private bool[] T00014_n2MenuXDesc ;
      private short[] T00014_A3MenuXPosi ;
      private bool[] T00014_n3MenuXPosi ;
      private string[] T00014_A4MenXUrl ;
      private bool[] T00014_n4MenXUrl ;
      private string[] T00014_A5MenXEst ;
      private bool[] T00014_n5MenXEst ;
      private short[] T00015_A1MenuXid ;
      private short[] T00013_A1MenuXid ;
      private string[] T00013_A2MenuXDesc ;
      private bool[] T00013_n2MenuXDesc ;
      private short[] T00013_A3MenuXPosi ;
      private bool[] T00013_n3MenuXPosi ;
      private string[] T00013_A4MenXUrl ;
      private bool[] T00013_n4MenXUrl ;
      private string[] T00013_A5MenXEst ;
      private bool[] T00013_n5MenXEst ;
      private short[] T00016_A1MenuXid ;
      private short[] T00017_A1MenuXid ;
      private short[] T00012_A1MenuXid ;
      private string[] T00012_A2MenuXDesc ;
      private bool[] T00012_n2MenuXDesc ;
      private short[] T00012_A3MenuXPosi ;
      private bool[] T00012_n3MenuXPosi ;
      private string[] T00012_A4MenXUrl ;
      private bool[] T00012_n4MenXUrl ;
      private string[] T00012_A5MenXEst ;
      private bool[] T00012_n5MenXEst ;
      private short[] T00018_A1MenuXid ;
      private short[] T000111_A1MenuXid ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class menu__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@MenuXid",GXType.Int16,4,0)
          };
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@MenuXid",GXType.Int16,4,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@MenuXid",GXType.Int16,4,0)
          };
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@MenuXid",GXType.Int16,4,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@MenuXid",GXType.Int16,4,0)
          };
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@MenuXid",GXType.Int16,4,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@MenuXDesc",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@MenuXPosi",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@MenXUrl",GXType.NVarChar,1000,0){Nullable=true} ,
          new ParDef("@MenXEst",GXType.NChar,1,0){Nullable=true}
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@MenuXDesc",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@MenuXPosi",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@MenXUrl",GXType.NVarChar,1000,0){Nullable=true} ,
          new ParDef("@MenXEst",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@MenuXid",GXType.Int16,4,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@MenuXid",GXType.Int16,4,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [MenuXid], [MenuXDesc], [MenuXPosi], [MenXUrl], [MenXEst] FROM [Menu] WITH (UPDLOCK) WHERE [MenuXid] = @MenuXid ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [MenuXid], [MenuXDesc], [MenuXPosi], [MenXUrl], [MenXEst] FROM [Menu] WHERE [MenuXid] = @MenuXid ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT TM1.[MenuXid], TM1.[MenuXDesc], TM1.[MenuXPosi], TM1.[MenXUrl], TM1.[MenXEst] FROM [Menu] TM1 WHERE TM1.[MenuXid] = @MenuXid ORDER BY TM1.[MenuXid]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT [MenuXid] FROM [Menu] WHERE [MenuXid] = @MenuXid  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT TOP 1 [MenuXid] FROM [Menu] WHERE ( [MenuXid] > @MenuXid) ORDER BY [MenuXid]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00017", "SELECT TOP 1 [MenuXid] FROM [Menu] WHERE ( [MenuXid] < @MenuXid) ORDER BY [MenuXid] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00018", "INSERT INTO [Menu]([MenuXDesc], [MenuXPosi], [MenXUrl], [MenXEst]) VALUES(@MenuXDesc, @MenuXPosi, @MenXUrl, @MenXEst); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT00018)
             ,new CursorDef("T00019", "UPDATE [Menu] SET [MenuXDesc]=@MenuXDesc, [MenuXPosi]=@MenuXPosi, [MenXUrl]=@MenXUrl, [MenXEst]=@MenXEst  WHERE [MenuXid] = @MenuXid", GxErrorMask.GX_NOMASK,prmT00019)
             ,new CursorDef("T000110", "DELETE FROM [Menu]  WHERE [MenuXid] = @MenuXid", GxErrorMask.GX_NOMASK,prmT000110)
             ,new CursorDef("T000111", "SELECT [MenuXid] FROM [Menu] ORDER BY [MenuXid]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 1);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 1);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 1);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
