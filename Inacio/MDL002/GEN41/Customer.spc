spec_i([ trn,7,'Customer','Customer',[],por,'17_0_9-159740' ]).
 
struct_i(5,0,[ 'Pgmname','Trncontext','Insert_countryid','GXV1','Trncontextatt','Mode','Customerid','Websession' ],[]).
 
level_i(5,[ 5,[ [ 5,many ],[ 3,one ] ],[ 11 ],[],[],[],[ 11 ],'ICUSTOMER',[ 5,[] ],[] ]).
 
tw_i(5,[ [ 3,[ [ 5,8,8 ] ] ] ]).
 
lwi_i(5,[ [] ]).
 
 
 
 
ta_i(5,[ [ [ 5,11 ],[ 5,20 ],[ 5,21 ],[ 5,22 ],[ 5,23 ],[ 3,9 ],[ 5,8 ] ] ]).
 
las_i(5,[ [ 'Pgmname','Trncontext','Insert_countryid','GXV1','Trncontextatt','Mode','Customerid','Websession',11,8,20,21,22,23,9 ] ]).
 
lac_i(5,[ [ 11,20,21,22,23,8 ] ]).
 
 
lits_i('Customer',5,10).
 
cls_i([ 0,0 ],[ 5,1023 ]).
 
pos_i(11,[ 0,0,0 ]).
pos_i(20,[ 0,0,0 ]).
pos_i(21,[ 0,0,0 ]).
pos_i(22,[ 0,0,0 ]).
pos_i(23,[ 0,0,0 ]).
pos_i(8,[ 0,0,0 ]).
pos_i(9,[ 0,0,0 ]).
 
 
default_i(e('Pgmname',2,2,'"Customer"')).
 
rule_i(0,datastore(1,'DS_LAST_CHANGE','')).
rule_i(0,datastore(1,'LOCK_RETRY','10')).
rule_i(0,datastore(1,'WAIT_RECORD','0')).
rule_i(0,datastore(1,'ISOLATION_LEVEL','CR')).
rule_i(0,datastore(1,'SQLSERVER_VERSION','10')).
rule_i(0,datastore(1,'COMMENT_ON','No')).
rule_i(0,datastore(1,'DFT_TMP_TBLSPACE','')).
rule_i(0,datastore(1,'DFT_IDX_TBLSPACE','')).
rule_i(0,datastore(1,'DFT_TBL_TBLSPACE','')).
rule_i(0,datastore(1,'DCL_REF_INT_DB','Yes')).
rule_i(0,datastore(1,'PRIMARY_KEY_TYPE','PK')).
rule_i(0,datastore(1,'CS_SCHEMA','')).
rule_i(0,datastore(1,'SORT_ATTRIBUTES','Yes')).
rule_i(0,datastore(1,'JRN400','QSQJRN')).
rule_i(0,datastore(1,'CREATE_SAVF','Yes')).
rule_i(0,datastore(1,'PGMLIB','')).
rule_i(0,datastore(1,'DTALIB','')).
rule_i(0,datastore(1,'RecycleRWMin','30')).
rule_i(0,datastore(1,'RecycleRWType','1')).
rule_i(0,datastore(1,'RecycleRW','-1')).
rule_i(0,datastore(1,'POOL_STARTUP','No')).
rule_i(0,datastore(1,'POOLSIZE_RW','10')).
rule_i(0,datastore(1,'UnlimitedRWPool','-1')).
rule_i(0,datastore(1,'PoolRWEnabled','-1')).
rule_i(0,datastore(1,'CS_RPCPGML','')).
rule_i(0,datastore(1,'JDBC_DATASOURCE','')).
rule_i(0,datastore(1,'USE_JDBC_DATASOURCE','0')).
rule_i(0,datastore(1,'DS_DBMS_ADDINFO','')).
rule_i(0,datastore(1,'USER_PASSWORD','')).
rule_i(0,datastore(1,'USER_ID','')).
rule_i(0,datastore(1,'TRUSTED_CONNECTION','Yes')).
rule_i(0,datastore(1,'CS_CONNECT','First')).
rule_i(0,datastore(1,'DBMS_PORT','')).
rule_i(0,datastore(1,'CS_SERVER','LENOVO\SQLEXPRESS01')).
rule_i(0,datastore(1,'CS_DBNAME',lojaGXInacio)).
rule_i(0,datastore(1,'CS_FLEDSNAME','')).
rule_i(0,datastore(1,'CS_DRVNAME','sql server')).
rule_i(0,datastore(1,'CS_DSNAME','')).
rule_i(0,datastore(1,'DB_URL','')).
rule_i(0,datastore(1,'JDBC_CUSTOM_URL','0')).
rule_i(0,datastore(1,'JDBC_CUSTOM_DRIVER','')).
rule_i(0,datastore(1,'JDBC_DRIVER','net.sourceforge.jtds.jdbc.Driver')).
rule_i(0,datastore(1,'CONNECT_METHOD','OPSYS')).
rule_i(0,datastore(1,'ACCESS_TECHNO','ADONET')).
rule_i(0,datastore(1,'MAIN_DS','-1')).
rule_i(0,datastore(1,'REORG_GEN','8')).
rule_i(0,datastore(1,'HelpKeyword','20')).
rule_i(0,datastore(1,'DBMS',12)).
rule_i(0,datastore(1,'NAME','Default')).
rule_i(0,prop(idNULLS_BEHAVIOR,idNB_Current)).
rule_i(0,prop('PWFCallable','0')).
rule_i(0,prop('ObjectVisibility','Public')).
rule_i(0,prop('FullyQualifiedName','Customer')).
rule_i(0,prop('GenerateObject','-1')).
rule_i(0,prop('MTIER_OPT','Yes')).
rule_i(0,prop('Hint_firstrows','UMPV')).
rule_i(0,prop('NULLVALUE_AS_NULL','UMPV')).
rule_i(0,prop('INITIALIZE_NEW','UMPV')).
rule_i(0,prop('STD_FUNC_OBJECT','Yes')).
rule_i(0,prop('SPC_WARNINGS_DISABLED','spc0096 spc0107 spc0142')).
rule_i(0,prop('KEY_MOREKEYS','UMPV')).
rule_i(0,prop('KEY_ENTER','UMPV')).
rule_i(0,prop('KEY_LAST','UMPV')).
rule_i(0,prop('KEY_FIRST','UMPV')).
rule_i(0,prop('KEY_SELECT','UMPV')).
rule_i(0,prop('KEY_DISPLAY','UMPV')).
rule_i(0,prop('KEY_DELETE','UMPV')).
rule_i(0,prop('KEY_CANCEL','UMPV')).
rule_i(0,prop('KEY_UPDATE','UMPV')).
rule_i(0,prop('KEY_MENU','UMPV')).
rule_i(0,prop('KEY_RETRIEVE','UMPV')).
rule_i(0,prop('KEY_NEXT','UMPV')).
rule_i(0,prop('KEY_PREVIOUS','UMPV')).
rule_i(0,prop('KEY_INSERT','UMPV')).
rule_i(0,prop('KEY_REFRESH','UMPV')).
rule_i(0,prop('KEY_PROMPT','UMPV')).
rule_i(0,prop('KEY_EXIT','UMPV')).
rule_i(0,prop('KEY_CHECK','UMPV')).
rule_i(0,prop('KEY_HELP','UMPV')).
rule_i(0,prop('ASSIGNED_FNC_KEYS','UMPV')).
rule_i(0,prop('FIRST_WD_DATEPICKER','UMPV')).
rule_i(0,prop('WNUM_DATEPICKER','UMPV')).
rule_i(0,prop(idUSE_WEB_DATEPICKER,'UMPV')).
rule_i(0,prop('WebFormDefaults','0')).
rule_i(0,prop('WebUX','SMOOTH')).
rule_i(0,prop('FIELD_TO_FIELD','UMPV')).
rule_i(0,prop('CONFIRM','UMPV')).
rule_i(0,prop('TRNCFM','UMPV')).
rule_i(0,prop('CFMTRN','No')).
rule_i(0,prop('TRNEND','Yes')).
rule_i(0,prop('IsDwhTrn','0')).
rule_i(0,prop(idDynTrnUpdatePolicy,idDynTrnUpdatePolicy_UPDATABLE)).
rule_i(0,prop(idIsDynTrn,'0')).
rule_i(0,prop('WEB_SECURITY_LEVEL','High')).
rule_i(0,prop('HTTP_PROTOCOL','Unsecure')).
rule_i(0,prop('USE_ENCRYPTION','NO')).
rule_i(0,prop('OnSessionTimeout','Ignore')).
rule_i(0,prop('SHOWMASTERPAGE_POPUP','0')).
rule_i(0,prop('MasterPage',o(13,'MasterPage'))).
rule_i(0,prop('WEB_COMP','No')).
rule_i(0,prop('Theme',o(25,'Carmine'))).
rule_i(0,prop('ExternalNamespace','WorkShopNew')).
rule_i(0,prop('ExternalName','Customer')).
rule_i(0,prop(idConnectivitySupport,idInherit)).
rule_i(0,prop('OBJECT_METADATA','')).
rule_i(0,prop('IsMain','0')).
rule_i(0,prop(sessiontype,'RW')).
rule_i(0,prop(idBC,'0')).
rule_i(0,prop('Folder',o(120,'Root Module'))).
rule_i(0,prop('ObjDesc','Customer')).
rule_i(0,prop('ObjName','Customer')).
rule_i(5,prompt([ 3,[ [ 5,8,8 ] ],[ 8 ],[ 8 ],[ t(o(13,'Gx0030'),28),t(8,2) ],[],n,[] ])).
rule_i(5,rule([ a(23,[ [ 8 ],[ t(o(13,'Gx0030'),28),t(8,2) ] ]) ],[],[],[ 8 ])).
rule_i(0,rule([ a(22,[ 'Dlt','"Eliminar"','' ]) ],[],[],[])).
rule_i(0,maingen(41)).
rule_i(0,rule([ a(10,[ 'Mode','Customerid' ]) ],[],[ insert,update,delete,display ],[])).
rule_i(0,parmio([ [ 'Mode',in ],[ 'Customerid',in ] ])).
rule_i(5,rule([ a(1,msg([ t('"O valor de Customer Email n�o coincide com o padr�o especificado"',3) ],[ t('OutOfRange',3) ])) ],[ t('NOT',8),t('(',0),t([ t(22,2),t('ismatch(',1) ],31),t('"^((\w+([-+.'']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)|(\s*))$"',3),t(')',4),t(')',4) ],[ insert,update ],[ 22 ])).
rule_i(5,rule([ a(3,[ t(11,2) ]) ],[],[ insert,update,delete,display ],[ 11 ])).
rule_i(5,rule([ a(21,[ [ 11 ] ]) ],[],[ insert,update,delete,display ],[ 11 ])).
rule_i(5,rule([ a(3,[ t(8,2) ]) ],[ t('Mode',23),t(=,10),t([ 42,'Insert' ],44),t('.AND.',9),t('.NOT.',8),t('null(',1),t('Insert_countryid',23),t(')',4) ],[ insert,update,delete,display ],[ 8,'Mode','Insert_countryid' ])).
rule_i(5,rule([ a(1,[ t('"Their name cannot be empty"',3) ]) ],[ t('null(',1),t(20,2),t(')',4) ],[ insert,update,delete,display ],[ 20 ])).
rule_i(5,rule([ a(1,[ t('"Their address cannot be empty"',3) ]) ],[ t('null(',1),t(21,2),t(')',4) ],[ insert,update,delete,display ],[ 21 ])).
rule_i(5,rule([ a(4,[ t('"Their phone is empty!"',3) ]) ],[ t('null(',1),t(23,2),t(')',4) ],[ insert,update,delete,display ],[ 23 ])).
rule_i(5,rule([ a(19,[ [ 8 ],msg([ t('"N�o existe ''Country''."',3) ],[ t('ForeignKeyNotFound',3) ]) ]) ],[],[ insert,update,delete ],[ 8 ])).
 
a_i(3,5,b,0,[],[ [],[ a(1,msg([ t('"O valor de Customer Email n�o coincide com o padr�o especificado"',3) ],[ t('OutOfRange',3) ])) ],[ t('NOT',8),t('(',0),t([ t(22,2),t('ismatch(',1) ],31),t('"^((\w+([-+.'']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)|(\s*))$"',3),t(')',4),t(')',4) ] ]).
a_i(4,5,f,11,[],[ [],[ t('Customerid',23),t('IF',17),t('.NOT.',8),t('null(',1),t('Customerid',23),t(')',4),t(';',18) ] ]).
a_i(5,5,f,[ t(11,2),t('Enabled',3) ],[],[ [],[ t(0,3),t(';',18) ] ]).
a_i(6,5,f,8,[],[ [],[ t('Insert_countryid',23),t('IF',17),t('Mode',23),t(=,10),t([ 42,'Insert' ],44),t('.AND.',9),t('.NOT.',8),t('null(',1),t('Insert_countryid',23),t(')',4),t(';',18) ] ]).
a_i(7,5,f,[ t(8,2),t('Enabled',3) ],[],[ [],[ t(0,3),t('IF',17),t('Mode',23),t(=,10),t([ 42,'Insert' ],44),t('.AND.',9),t('.NOT.',8),t('null(',1),t('Insert_countryid',23),t(')',4),t(';',18),t(1,3),t('OTHERWISE',19),t(';',18) ] ]).
a_i(8,5,b,6,[],[ [],[ a(3,[ t(8,2) ]) ],[ t('Mode',23),t(=,10),t([ 42,'Insert' ],44),t('.AND.',9),t('.NOT.',8),t('null(',1),t('Insert_countryid',23),t(')',4) ] ]).
a_i(9,5,b,7,[],[ [],[ a(1,[ t('"Their name cannot be empty"',3) ]) ],[ t('null(',1),t(20,2),t(')',4) ] ]).
a_i(10,5,b,8,[],[ [],[ a(1,[ t('"Their address cannot be empty"',3) ]) ],[ t('null(',1),t(21,2),t(')',4) ] ]).
a_i(11,5,b,9,[],[ [],[ a(4,[ t('"Their phone is empty!"',3) ]) ],[ t('null(',1),t(23,2),t(')',4) ] ]).
a_i(12,5,t,5,[],[ [ [ [],11,11 ] ],'ICUSTOMER',[] ]).
a_i(13,5,r,3,[],[ [ [ 5,8,8 ] ],'ICOUNTRY',[] ]).
a_i(14,5,f,'Pgmname',[],[ [],[ t('"Customer"',3) ] ]).
 
v_i(b,i,3,22).
v_i(b,o,3,[]).
v_i(f,i,4,'Customerid').
v_i(f,o,4,11).
v_i(f,i,5,[]).
v_i(f,o,5,[ t(11,2),t('Enabled',3) ]).
v_i(f,i,6,'Insert_countryid').
v_i(f,o,6,8).
v_i(f,i,7,'Insert_countryid').
v_i(f,o,7,[ t(8,2),t('Enabled',3) ]).
v_i(b,i,8,'Insert_countryid').
v_i(b,o,8,[]).
v_i(b,i,9,20).
v_i(b,o,9,[]).
v_i(b,i,10,21).
v_i(b,o,10,[]).
v_i(b,i,11,23).
v_i(b,o,11,[]).
v_i(t,i,12,11).
v_i(t,o,12,20).
v_i(t,o,12,21).
v_i(t,o,12,22).
v_i(t,o,12,23).
v_i(t,o,12,8).
v_i(r,i,13,8).
v_i(r,o,13,9).
v_i(f,i,14,[]).
v_i(f,o,14,'Pgmname').
 
act_info_i(4,[ [ 11 ] ]).
act_info_i(6,[ [ 8 ] ]).
 
ca_i(6,8).
 
tbl_to_delete_i(5,[ 9,[ [ 5,11,11 ] ],c,'ISHOPPINGCART1',0,[ 16 ],'' ]).
 
 
 
attri_i(16,[ 'ShoppingCartId',int,4,0,'ZZZ9',0,'Shopping Cart Id','',0 ]).
attri_i(9,[ 'CountryName',char,20,0,'',0,'Country Name','',0 ]).
attri_i(23,[ 'CustomerPhone',char,20,0,'',0,'Customer Phone','',0 ]).
attri_i(22,[ 'CustomerEmail',svchar,100,0,'',0,'Customer Email','',0 ]).
attri_i(21,[ 'CustomerAddress',svchar,1024,0,'',0,'Customer Address','',0 ]).
attri_i(20,[ 'CustomerName',char,20,0,'',0,'Customer Name','',0 ]).
attri_i(8,[ 'CountryId',int,4,0,'ZZZ9',0,'Country Id','',0 ]).
attri_i(11,[ 'CustomerId',int,4,0,'ZZZ9',0,'Customer Id','',0 ]).
attri_i('GXV1',[ 'GXV1',int,8,0,'',0,'','',14 ]).
attri_i('Pgmname',[ 'Pgmname',char,129,0,'',1,'Program name','',13 ]).
attri_i('Gxremove',[ 'GxRemove',int,1,0,'9',0,'Gx Remove','',5 ]).
attri_i('Trncontextatt',[ 'TrnContextAtt',o('TransactionContext.Attribute'),0,0,'',0,'Trn Context Att','',12 ]).
attri_i('Insert_countryid',[ 'Insert_CountryId',int,4,0,'ZZZ9',0,'Insert_Country Id','',11 ]).
attri_i('Websession',[ 'WebSession',o(websession),4,0,'',0,'Web Session','',10 ]).
attri_i('Trncontext',[ 'TrnContext',o('TransactionContext'),0,0,'',0,'Trn Context','',9 ]).
attri_i('Isauthorized',[ 'IsAuthorized',boolean,4,0,'',0,'Is Authorized','',8 ]).
attri_i('Customerid',[ 'CustomerId',int,4,0,'ZZZ9',0,'Customer Id','',7 ]).
attri_i('Mode',[ 'Gx_mode',char,3,0,'@!',1,'','',2 ]).
 
table_i(9,[ 'ShoppingCart',[ 16,11 ],'Shopping Cart','ShoppingCart' ]).
table_i(3,[ 'Country',[ 8,9 ],'Country','Country' ]).
table_i(5,[ 'Customer',[ 11,20,21,22,23,8 ],'Customer','Customer' ]).
 
index_i(5,[ 'ICUSTOMER',u,[ 11 ],'ICustomer' ]).
index_i(3,[ 'ICOUNTRY',u,[ 8 ],'ICountry' ]).
index_i(9,[ 'ISHOPPINGCART',u,[ 16 ],'IShoppingCart' ]).
index_i(9,[ 'ISHOPPINGCART1',d,[ 11 ],'IShoppingCart1' ]).
 
 
 
 
 
 
 
 
 
 
 
 
add_att_i(bits,2,40000,17,'CountryFlag_GXI',[ svchar,2048,0,0 ]).
 
upd_i(5,5,i,[ [ 20,21,22,23,8 ],[],'ICUSTOMER',[ [ [],11,11 ] ] ]).
upd_i(5,5,u,[ [ 20,21,22,23,8 ],[],'ICUSTOMER',[] ]).
upd_i(5,5,d,[ [],[],'ICUSTOMER',[] ]).
 
 
 
 
 
 
 
 
 
enum_value_i(2,42,'"INS"','Insert','"Insert"',[ none ]).
enum_value_i(2,42,'"UPD"','Update','"Update"',[ none ]).
enum_value_i(2,42,'"DLT"','Delete','"Delete"',[ none ]).
enum_value_i(2,42,'"DSP"','Display','"Display"',[ none ]).
 
enum_value_info_i(2,42,'GeneXus\TrnMode').
 
enum_type_i(2,42,char,3,0).
 
dom_info_i(88,[ 'Id' ]).
dom_info_i(89,[ 'Name' ]).
dom_info_i(43,[ 'GeneXus\Address' ]).
dom_info_i(45,[ 'GeneXus\Email' ]).
dom_info_i(48,[ 'GeneXus\Phone' ]).
 
a_ctrl_i(22,c,[ '"^((\w+([-+.'']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)|(\s*))$"' ]).
 
break_i(2,nvg,1,[],[ [],[],[] ]).
 
b_group_i(2,1,lit,0,1,1).
b_group_i(2,2,lit,0,2,30).
b_group_i(2,3,lit,0,31,0).
 
b_line_i(1,2,1,cmd,1,[ t('',146,1,0),t('Start',3,1,7) ]).
b_line_i(5,2,2,cmd,1,[ t('',109,5,0),t('.NOT.',8,1,5),t('udp(',1,5,23),t(o(1,'IsAuthorized'),28,5,11),t(',',7,1,0),t('Pgmname',23,1,24),t(')',4,1,0) ]).
b_line_i(6,2,2,cmd,1,[ t('',104,6,0),t(o(13,'NotAuthorized'),28,1,3),t('Pgmname',23,1,17) ]).
b_line_i(7,2,2,cmd,1,[ t('',111,7,0) ]).
b_line_i(9,2,2,cmd,1,[ t('',107,9,0),t([ t('Trncontext',23,9,2),t('fromxml(',1,9,14) ],31,9,2),t([ t('Websession',23,1,23),t('get(',1,1,35) ],31,9,35),t('"TrnContext"',3,9,40),t(')',4,1,53),t(')',4,1,54) ]).
b_line_i(10,2,2,cmd,1,[ t('',107,10,0),t([ t('Insert_countryid',23,10,2),t('setempty(',1,10,20) ],31,10,2),t(')',4,1,30) ]).
b_line_i(12,2,2,cmd,1,[ t('',109,12,0),t('(',0,1,5),t([ t('Trncontext',23,12,6),t('Transactionname',3,12,18) ],29,12,18),t(=,10,1,34),t('Pgmname',23,1,36),t('.AND.',9,1,45),t('Mode',23,1,51),t(=,10,1,57),t([ 42,'Insert' ],44,12,59),t(')',4,1,73) ]).
b_line_i(13,2,2,cmd,1,[ t('',107,13,0),t('GXV1',23,1,0),t(=,10,1,0),t(1,3,1,0) ]).
b_line_i([ 13,2 ],2,2,cmd,1,[ t('',114,13,0),t('GXV1',23,1,0),t(<=,10,1,0),t([ t('Trncontext',23,13,25),t('Attributes',3,13,37),t('Count',3,13,0) ],29,13,0) ]).
b_line_i([ 13,3 ],2,2,cmd,1,[ t('',107,13,0),t('Trncontextatt',23,1,0),t(=,10,1,0),t([ t([ t('Trncontext',23,1,0),t('Attributes',3,1,0) ],29,1,0),t('item(',1,1,0) ],31,1,0),t('GXV1',23,1,0),t(')',4,1,0) ]).
b_line_i(14,2,2,cmd,2,[ t('',152,14,0) ]).
b_line_i(16,2,2,cmd,2,[ t('',153,16,0),t([ t('Trncontextatt',23,16,10),t('Attributename',3,16,25) ],29,16,25),t(=,10,2,39),t('"CountryId"',3,16,41) ]).
b_line_i(17,2,2,cmd,2,[ t('',107,17,0),t('Insert_countryid',23,17,6),t(=,10,17,6),t('val(',1,17,6),t([ t('Trncontextatt',23,17,36),t('Attributevalue',3,17,51) ],29,17,51),t(')',4,2,65) ]).
b_line_i(18,2,2,cmd,2,[ t('',154,18,0) ]).
b_line_i([ 19,1 ],2,2,cmd,2,[ t('',107,19,0),t('GXV1',23,2,0),t(=,10,2,0),t('GXV1',23,2,0),t(+,5,2,0),t(1,3,2,0) ]).
b_line_i([ 19,2 ],2,2,cmd,2,[ t('',115,19,0) ]).
b_line_i(20,2,2,cmd,3,[ t('',111,20,0) ]).
b_line_i(22,2,2,cmd,3,[ t('',109,22,0),t('Mode',23,3,5),t(=,10,3,11),t([ 42,'Delete' ],44,22,13) ]).
b_line_i(23,2,2,cmd,3,[ t('',107,23,0),t([ t('Btn_enter',3,3,0),t('Caption',3,3,0) ],29,3,0),t(=,10,3,0),t('"Eliminar"',3,3,0) ]).
b_line_i(24,2,2,cmd,3,[ t('',107,24,0),t([ t('Btn_enter',3,3,0),t('Tooltiptext',3,3,0) ],29,3,0),t(=,10,3,0),t('"Eliminar"',3,3,0) ]).
b_line_i(25,2,2,cmd,3,[ t('',111,25,0) ]).
b_line_i(28,2,2,cmd,3,[ t('',147,28,0) ]).
b_line_i(30,2,2,cmd,3,[ t('',146,30,0),t('After Trn',3,30,7) ]).
b_line_i(34,2,3,cmd,3,[ t('',109,34,0),t('(',0,3,5),t('Mode',23,3,6),t(=,10,3,12),t([ 42,'Delete' ],44,34,14),t('.AND.',9,3,29),t('.NOT.',8,3,35),t([ t('Trncontext',23,34,41),t('Callerondelete',3,34,53) ],29,34,53),t(')',4,3,67) ]).
b_line_i(35,2,3,cmd,3,[ t('',104,35,0),t(o(13,'WWCustomer'),28,3,3) ]).
b_line_i(36,2,3,cmd,3,[ t('',111,36,0) ]).
b_line_i(38,2,3,cmd,3,[ t('',118,38,0) ]).
b_line_i(41,2,3,cmd,3,[ t('',147,41,0) ]).
 
 
 
 
 
 
 
 
 
 
 
 
 
 
html_i(2,div(2)).
 
html_sub_i(2,3,html_i(0,div(3))).
html_sub_i(3,4,html_i(0,div(4))).
html_sub_i(4,5,html_i(0,div(5))).
html_sub_i(5,6,html_i(0,div(6))).
html_sub_i(6,7,html_i(0,div(7))).
html_sub_i(7,8,html_i(0,div(8))).
html_sub_i(8,9,html_i(0,t('Customer',3))).
html_sub_i(6,10,html_i(1,div(10))).
html_sub_i(10,11,html_i(0,div(11))).
html_sub_i(11,12,html_i(0,comp(errview))).
html_sub_i(3,13,html_i(1,div(13))).
html_sub_i(13,14,html_i(0,div(14))).
html_sub_i(14,15,html_i(0,div(15))).
html_sub_i(15,16,html_i(0,div(16))).
html_sub_i(16,17,html_i(0,div(17))).
html_sub_i(17,18,html_i(0,div(18))).
html_sub_i(18,19,html_i(0,div(19))).
html_sub_i(19,20,html_i(0,div(20))).
html_sub_i(20,21,html_i(0,button('First'))).
html_sub_i(19,22,html_i(1,div(22))).
html_sub_i(22,23,html_i(0,button('Previous'))).
html_sub_i(19,24,html_i(2,div(24))).
html_sub_i(24,25,html_i(0,button('Next'))).
html_sub_i(19,26,html_i(3,div(26))).
html_sub_i(26,27,html_i(0,button('Last'))).
html_sub_i(19,28,html_i(4,div(28))).
html_sub_i(28,29,html_i(0,button('Select'))).
html_sub_i(15,30,html_i(1,div(30))).
html_sub_i(30,31,html_i(0,div(31))).
html_sub_i(31,32,html_i(0,div(32))).
html_sub_i(32,33,html_i(0,div(33))).
html_sub_i(33,34,html_i(0,t(11,2))).
html_sub_i(15,35,html_i(2,div(35))).
html_sub_i(35,36,html_i(0,div(36))).
html_sub_i(36,37,html_i(0,div(37))).
html_sub_i(37,38,html_i(0,div(38))).
html_sub_i(38,39,html_i(0,t(20,2))).
html_sub_i(15,40,html_i(3,div(40))).
html_sub_i(40,41,html_i(0,div(41))).
html_sub_i(41,42,html_i(0,div(42))).
html_sub_i(42,43,html_i(0,div(43))).
html_sub_i(43,44,html_i(0,t(21,2))).
html_sub_i(15,45,html_i(4,div(45))).
html_sub_i(45,46,html_i(0,div(46))).
html_sub_i(46,47,html_i(0,div(47))).
html_sub_i(47,48,html_i(0,div(48))).
html_sub_i(48,49,html_i(0,t(22,2))).
html_sub_i(15,50,html_i(5,div(50))).
html_sub_i(50,51,html_i(0,div(51))).
html_sub_i(51,52,html_i(0,div(52))).
html_sub_i(52,53,html_i(0,div(53))).
html_sub_i(53,54,html_i(0,t(23,2))).
html_sub_i(15,55,html_i(6,div(55))).
html_sub_i(55,56,html_i(0,div(56))).
html_sub_i(56,57,html_i(0,div(57))).
html_sub_i(57,58,html_i(0,div(58))).
html_sub_i(58,59,html_i(0,t(8,2))).
html_sub_i(15,60,html_i(7,div(60))).
html_sub_i(60,61,html_i(0,div(61))).
html_sub_i(61,62,html_i(0,div(62))).
html_sub_i(62,63,html_i(0,div(63))).
html_sub_i(63,64,html_i(0,t(9,2))).
html_sub_i(3,65,html_i(2,div(65))).
html_sub_i(65,66,html_i(0,div(66))).
html_sub_i(66,67,html_i(0,div(67))).
html_sub_i(67,68,html_i(0,div(68))).
html_sub_i(68,69,html_i(0,button('Enter'))).
html_sub_i(67,70,html_i(1,div(70))).
html_sub_i(70,71,html_i(0,button('Cancel'))).
html_sub_i(67,72,html_i(2,div(72))).
html_sub_i(72,73,html_i(0,button('Delete'))).
 
html_tags_i(1,'Class','form-horizontal Form').
html_tags_i(2,'data-gx-base-lib',bootstrapv3).
html_tags_i(2,'data-abstract-form','').
html_tags_i(9,'ControlType','').
html_tags_i(18,'data-gx-actiongroup-type',toolbar).
html_tags_i(21,'ControlType','').
html_tags_i(23,'ControlType','').
html_tags_i(25,'ControlType','').
html_tags_i(27,'ControlType','').
html_tags_i(29,'ControlType','').
html_tags_i(32,'data-gx-att','att:11').
html_tags_i(34,'data-gx-att','att:11').
html_tags_i(37,'data-gx-att','att:20').
html_tags_i(39,'data-gx-att','att:20').
html_tags_i(42,'data-gx-att','att:21').
html_tags_i(44,'data-gx-att','att:21').
html_tags_i(47,'data-gx-att','att:22').
html_tags_i(49,'data-gx-att','att:22').
html_tags_i(52,'data-gx-att','att:23').
html_tags_i(54,'data-gx-att','att:23').
html_tags_i(57,'data-gx-att','att:8').
html_tags_i(59,'data-gx-att','att:8').
html_tags_i(62,'data-gx-att','att:9').
html_tags_i(64,'data-gx-att','att:9').
html_tags_i(67,'data-gx-actiongroup-type',toolbar).
html_tags_i(69,'ControlType','').
html_tags_i(71,'ControlType','').
html_tags_i(73,'ControlType','').
 
html_comp_i(12,'Backcolor',rgb(0,0,0),d,[ color ]).
html_comp_i(2,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(2,'Class','Section',d,[ str ]).
html_comp_i(2,'Id','',d,[ str ]).
html_comp_i(2,'Height',measure(0,px),d,[ measure ]).
html_comp_i(2,'Width',measure(0,px),d,[ measure ]).
html_comp_i(2,'Semanticcontent',div,d,[ str ]).
html_comp_i(2,'Align',left,d,[ str ]).
html_comp_i(2,'Valign',top,d,[ str ]).
html_comp_i(3,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(3,'Class','WWAdvancedContainer',v,[ str ]).
html_comp_i(3,'Id','Maintable',v,[ str ]).
html_comp_i(3,'Height',measure(0,px),d,[ measure ]).
html_comp_i(3,'Width',measure(0,px),d,[ measure ]).
html_comp_i(3,'Semanticcontent',div,d,[ str ]).
html_comp_i(3,'Align',left,d,[ str ]).
html_comp_i(3,'Valign',top,d,[ str ]).
html_comp_i(4,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(4,'Class',row,v,[ str ]).
html_comp_i(4,'Id','',d,[ str ]).
html_comp_i(4,'Height',measure(0,px),d,[ measure ]).
html_comp_i(4,'Width',measure(0,px),d,[ measure ]).
html_comp_i(4,'Semanticcontent',div,d,[ str ]).
html_comp_i(4,'Align',left,d,[ str ]).
html_comp_i(4,'Valign',top,d,[ str ]).
html_comp_i(5,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(5,'Class','col-xs-12 col-sm-8 col-sm-offset-2',v,[ str ]).
html_comp_i(5,'Id','',d,[ str ]).
html_comp_i(5,'Height',measure(0,px),d,[ measure ]).
html_comp_i(5,'Width',measure(0,px),d,[ measure ]).
html_comp_i(5,'Semanticcontent',div,d,[ str ]).
html_comp_i(5,'Align',left,d,[ str ]).
html_comp_i(5,'Valign',top,d,[ str ]).
html_comp_i(6,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(6,'Class','TableTop',v,[ str ]).
html_comp_i(6,'Id','Titlecontainer',v,[ str ]).
html_comp_i(6,'Height',measure(0,px),d,[ measure ]).
html_comp_i(6,'Width',measure(0,px),d,[ measure ]).
html_comp_i(6,'Semanticcontent',div,d,[ str ]).
html_comp_i(6,'Align',left,d,[ str ]).
html_comp_i(6,'Valign',top,d,[ str ]).
html_comp_i(7,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(7,'Class',row,v,[ str ]).
html_comp_i(7,'Id','',d,[ str ]).
html_comp_i(7,'Height',measure(0,px),d,[ measure ]).
html_comp_i(7,'Width',measure(0,px),d,[ measure ]).
html_comp_i(7,'Semanticcontent',div,d,[ str ]).
html_comp_i(7,'Align',left,d,[ str ]).
html_comp_i(7,'Valign',top,d,[ str ]).
html_comp_i(8,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(8,'Class','col-xs-12',v,[ str ]).
html_comp_i(8,'Id','',d,[ str ]).
html_comp_i(8,'Height',measure(0,px),d,[ measure ]).
html_comp_i(8,'Width',measure(0,px),d,[ measure ]).
html_comp_i(8,'Semanticcontent',div,d,[ str ]).
html_comp_i(8,'Align',left,d,[ str ]).
html_comp_i(8,'Valign',top,d,[ str ]).
html_comp_i(9,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(9,'Caption','Customer',d,[ str ]).
html_comp_i(9,'Id','Title',v,[ str ]).
html_comp_i(9,'Class','Title',v,[ str ]).
html_comp_i(9,'Event','',d,[ str ]).
html_comp_i(9,'Returnonclick',0,d,[ bool ]).
html_comp_i(9,'Gxformat',0,d,[ num ]).
html_comp_i(9,'Title','',d,[ str ]).
html_comp_i(9,'Fill',-1,d,[ bool ]).
html_comp_i(9,'Backcolor',rgb(255,255,255),d,[ color ]).
html_comp_i(9,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(9,'Font',font('Arial',14,[]),d,[ font ]).
html_comp_i(10,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(10,'Class',row,v,[ str ]).
html_comp_i(10,'Id','',d,[ str ]).
html_comp_i(10,'Height',measure(0,px),d,[ measure ]).
html_comp_i(10,'Width',measure(0,px),d,[ measure ]).
html_comp_i(10,'Semanticcontent',div,d,[ str ]).
html_comp_i(10,'Align',left,d,[ str ]).
html_comp_i(10,'Valign',top,d,[ str ]).
html_comp_i(11,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(11,'Class','col-xs-12',v,[ str ]).
html_comp_i(11,'Id','',d,[ str ]).
html_comp_i(11,'Height',measure(0,px),d,[ measure ]).
html_comp_i(11,'Width',measure(0,px),d,[ measure ]).
html_comp_i(11,'Semanticcontent',div,d,[ str ]).
html_comp_i(11,'Align',left,d,[ str ]).
html_comp_i(11,'Valign',top,d,[ str ]).
html_comp_i(12,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(12,'Controlname','Errorviewer',v,[ str ]).
html_comp_i(12,'Class','ErrorViewer',v,[ str ]).
html_comp_i(12,'Displaymode',1,d,[ num ]).
html_comp_i(12,'Forecolor',rgb(255,0,0),d,[ color ]).
html_comp_i(12,'Font',font('Arial',9,[]),d,[ font ]).
html_comp_i(12,'Fill',-1,d,[ bool ]).
html_comp_i(13,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(13,'Class',row,v,[ str ]).
html_comp_i(13,'Id','',d,[ str ]).
html_comp_i(13,'Height',measure(0,px),d,[ measure ]).
html_comp_i(13,'Width',measure(0,px),d,[ measure ]).
html_comp_i(13,'Semanticcontent',div,d,[ str ]).
html_comp_i(13,'Align',left,d,[ str ]).
html_comp_i(13,'Valign',top,d,[ str ]).
html_comp_i(14,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(14,'Class','col-xs-12 col-sm-8 col-sm-offset-2',v,[ str ]).
html_comp_i(14,'Id','',d,[ str ]).
html_comp_i(14,'Height',measure(0,px),d,[ measure ]).
html_comp_i(14,'Width',measure(0,px),d,[ measure ]).
html_comp_i(14,'Semanticcontent',div,d,[ str ]).
html_comp_i(14,'Align',left,d,[ str ]).
html_comp_i(14,'Valign',top,d,[ str ]).
html_comp_i(15,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(15,'Class','FormContainer',v,[ str ]).
html_comp_i(15,'Id','Formcontainer',v,[ str ]).
html_comp_i(15,'Height',measure(0,px),d,[ measure ]).
html_comp_i(15,'Width',measure(0,px),d,[ measure ]).
html_comp_i(15,'Semanticcontent',div,d,[ str ]).
html_comp_i(15,'Align',left,d,[ str ]).
html_comp_i(15,'Valign',top,d,[ str ]).
html_comp_i(16,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(16,'Class',row,v,[ str ]).
html_comp_i(16,'Id','',d,[ str ]).
html_comp_i(16,'Height',measure(0,px),d,[ measure ]).
html_comp_i(16,'Width',measure(0,px),d,[ measure ]).
html_comp_i(16,'Semanticcontent',div,d,[ str ]).
html_comp_i(16,'Align',left,d,[ str ]).
html_comp_i(16,'Valign',top,d,[ str ]).
html_comp_i(17,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(17,'Class','col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass',v,[ str ]).
html_comp_i(17,'Id','Toolbarcell',v,[ str ]).
html_comp_i(17,'Height',measure(0,px),d,[ measure ]).
html_comp_i(17,'Width',measure(0,px),d,[ measure ]).
html_comp_i(17,'Semanticcontent',div,d,[ str ]).
html_comp_i(17,'Align',left,d,[ str ]).
html_comp_i(17,'Valign',top,d,[ str ]).
html_comp_i(18,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(18,'Class','gx-action-group ActionGroup',v,[ str ]).
html_comp_i(18,'Id','',d,[ str ]).
html_comp_i(18,'Height',measure(0,px),d,[ measure ]).
html_comp_i(18,'Width',measure(0,px),d,[ measure ]).
html_comp_i(18,'Semanticcontent',div,d,[ str ]).
html_comp_i(18,'Align',left,d,[ str ]).
html_comp_i(18,'Valign',top,d,[ str ]).
html_comp_i(19,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(19,'Class','btn-group',v,[ str ]).
html_comp_i(19,'Id','',d,[ str ]).
html_comp_i(19,'Height',measure(0,px),d,[ measure ]).
html_comp_i(19,'Width',measure(0,px),d,[ measure ]).
html_comp_i(19,'Semanticcontent',div,d,[ str ]).
html_comp_i(19,'Align',left,d,[ str ]).
html_comp_i(19,'Valign',top,d,[ str ]).
html_comp_i(20,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(20,'Class','gx-button',v,[ str ]).
html_comp_i(20,'Id','',d,[ str ]).
html_comp_i(20,'Height',measure(0,px),d,[ measure ]).
html_comp_i(20,'Width',measure(0,px),d,[ measure ]).
html_comp_i(20,'Semanticcontent',div,d,[ str ]).
html_comp_i(20,'Align',left,d,[ str ]).
html_comp_i(20,'Valign',top,d,[ str ]).
html_comp_i(21,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(21,'Controlname','Btn_first',v,[ str ]).
html_comp_i(21,'Class','BtnFirst',v,[ str ]).
html_comp_i(21,'Event','First',v,[ str ]).
html_comp_i(21,'Caption','',d,[ str ]).
html_comp_i(21,'Title','',d,[ str ]).
html_comp_i(21,'Font',font('Arial',9,[]),d,[ font ]).
html_comp_i(21,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(21,'Backcolor',rgb(240,240,240),d,[ color ]).
html_comp_i(21,'Border','0',d,[ str ]).
html_comp_i(21,'Bordercolor',rgb(255,255,255),d,[ color ]).
html_comp_i(21,'Buttonborderstyle',standard,d,[ str ]).
html_comp_i(22,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(22,'Class','gx-button',v,[ str ]).
html_comp_i(22,'Id','',d,[ str ]).
html_comp_i(22,'Height',measure(0,px),d,[ measure ]).
html_comp_i(22,'Width',measure(0,px),d,[ measure ]).
html_comp_i(22,'Semanticcontent',div,d,[ str ]).
html_comp_i(22,'Align',left,d,[ str ]).
html_comp_i(22,'Valign',top,d,[ str ]).
html_comp_i(23,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(23,'Controlname','Btn_previous',v,[ str ]).
html_comp_i(23,'Class','BtnPrevious',v,[ str ]).
html_comp_i(23,'Event','Previous',v,[ str ]).
html_comp_i(23,'Caption','',d,[ str ]).
html_comp_i(23,'Title','',d,[ str ]).
html_comp_i(23,'Font',font('Arial',9,[]),d,[ font ]).
html_comp_i(23,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(23,'Backcolor',rgb(240,240,240),d,[ color ]).
html_comp_i(23,'Border','2',d,[ str ]).
html_comp_i(23,'Bordercolor',rgb(255,255,255),d,[ color ]).
html_comp_i(23,'Buttonborderstyle',standard,d,[ str ]).
html_comp_i(24,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(24,'Class','gx-button',v,[ str ]).
html_comp_i(24,'Id','',d,[ str ]).
html_comp_i(24,'Height',measure(0,px),d,[ measure ]).
html_comp_i(24,'Width',measure(0,px),d,[ measure ]).
html_comp_i(24,'Semanticcontent',div,d,[ str ]).
html_comp_i(24,'Align',left,d,[ str ]).
html_comp_i(24,'Valign',top,d,[ str ]).
html_comp_i(25,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(25,'Controlname','Btn_next',v,[ str ]).
html_comp_i(25,'Class','BtnNext',v,[ str ]).
html_comp_i(25,'Event','Next',v,[ str ]).
html_comp_i(25,'Caption','',d,[ str ]).
html_comp_i(25,'Title','',d,[ str ]).
html_comp_i(25,'Font',font('Arial',9,[]),d,[ font ]).
html_comp_i(25,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(25,'Backcolor',rgb(240,240,240),d,[ color ]).
html_comp_i(25,'Border','2',d,[ str ]).
html_comp_i(25,'Bordercolor',rgb(255,255,255),d,[ color ]).
html_comp_i(25,'Buttonborderstyle',standard,d,[ str ]).
html_comp_i(26,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(26,'Class','gx-button',v,[ str ]).
html_comp_i(26,'Id','',d,[ str ]).
html_comp_i(26,'Height',measure(0,px),d,[ measure ]).
html_comp_i(26,'Width',measure(0,px),d,[ measure ]).
html_comp_i(26,'Semanticcontent',div,d,[ str ]).
html_comp_i(26,'Align',left,d,[ str ]).
html_comp_i(26,'Valign',top,d,[ str ]).
html_comp_i(27,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(27,'Controlname','Btn_last',v,[ str ]).
html_comp_i(27,'Class','BtnLast',v,[ str ]).
html_comp_i(27,'Event','Last',v,[ str ]).
html_comp_i(27,'Caption','',d,[ str ]).
html_comp_i(27,'Title','',d,[ str ]).
html_comp_i(27,'Font',font('Arial',9,[]),d,[ font ]).
html_comp_i(27,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(27,'Backcolor',rgb(240,240,240),d,[ color ]).
html_comp_i(27,'Border','2',d,[ str ]).
html_comp_i(27,'Bordercolor',rgb(255,255,255),d,[ color ]).
html_comp_i(27,'Buttonborderstyle',standard,d,[ str ]).
html_comp_i(28,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(28,'Class','gx-button',v,[ str ]).
html_comp_i(28,'Id','',d,[ str ]).
html_comp_i(28,'Height',measure(0,px),d,[ measure ]).
html_comp_i(28,'Width',measure(0,px),d,[ measure ]).
html_comp_i(28,'Semanticcontent',div,d,[ str ]).
html_comp_i(28,'Align',left,d,[ str ]).
html_comp_i(28,'Valign',top,d,[ str ]).
html_comp_i(29,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(29,'Controlname','Btn_select',v,[ str ]).
html_comp_i(29,'Class','BtnSelect',v,[ str ]).
html_comp_i(29,'Event','Select',v,[ str ]).
html_comp_i(29,'Caption','Selecionar',d,[ str ]).
html_comp_i(29,'Title','Selecionar',d,[ str ]).
html_comp_i(29,'Font',font('Arial',9,[]),d,[ font ]).
html_comp_i(29,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(29,'Backcolor',rgb(240,240,240),d,[ color ]).
html_comp_i(29,'Border','0',d,[ str ]).
html_comp_i(29,'Bordercolor',rgb(255,255,255),d,[ color ]).
html_comp_i(29,'Buttonborderstyle',standard,d,[ str ]).
html_comp_i(30,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(30,'Class',row,v,[ str ]).
html_comp_i(30,'Id','',d,[ str ]).
html_comp_i(30,'Height',measure(0,px),d,[ measure ]).
html_comp_i(30,'Width',measure(0,px),d,[ measure ]).
html_comp_i(30,'Semanticcontent',div,d,[ str ]).
html_comp_i(30,'Align',left,d,[ str ]).
html_comp_i(30,'Valign',top,d,[ str ]).
html_comp_i(31,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(31,'Class','col-xs-12 FormCellAdvanced',v,[ str ]).
html_comp_i(31,'Id','',d,[ str ]).
html_comp_i(31,'Height',measure(0,px),d,[ measure ]).
html_comp_i(31,'Width',measure(0,px),d,[ measure ]).
html_comp_i(31,'Semanticcontent',div,d,[ str ]).
html_comp_i(31,'Align',left,d,[ str ]).
html_comp_i(31,'Valign',top,d,[ str ]).
html_comp_i(32,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(32,'Class','form-group gx-form-group ',v,[ str ]).
html_comp_i(32,'Id','',d,[ str ]).
html_comp_i(32,'Height',measure(0,px),d,[ measure ]).
html_comp_i(32,'Width',measure(0,px),d,[ measure ]).
html_comp_i(32,'Semanticcontent',div,d,[ str ]).
html_comp_i(32,'Align',left,d,[ str ]).
html_comp_i(32,'Valign',top,d,[ str ]).
html_comp_i(33,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(33,'Class','col-sm-9 gx-attribute',v,[ str ]).
html_comp_i(33,'Id','',d,[ str ]).
html_comp_i(33,'Height',measure(0,px),d,[ measure ]).
html_comp_i(33,'Width',measure(0,px),d,[ measure ]).
html_comp_i(33,'Semanticcontent',div,d,[ str ]).
html_comp_i(33,'Align',left,d,[ str ]).
html_comp_i(33,'Valign',top,d,[ str ]).
html_comp_i(34,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(34,'Colcount',4,d,[ num ]).
html_comp_i(34,'Attid',11,v,[ num ]).
html_comp_i(34,'Class','Attribute',v,[ str ]).
html_comp_i(34,'Controlname','Customerid',d,[ str ]).
html_comp_i(34,'Returnonclick',0,v,[ bool ]).
html_comp_i(34,'Captionclass','col-sm-3 AttributeLabel',v,[ str ]).
html_comp_i(34,'Captionstyle','',v,[ str ]).
html_comp_i(34,'Captionposition','Left',v,[ str ]).
html_comp_i(34,'Captionvalue','Id',d,[ str ]).
html_comp_i(34,'Layoutclass','col-sm-9',v,[ str ]).
html_comp_i(34,'Controltype',2,d,[ num ]).
html_comp_i(34,'Inputtype',0,d,[ num ]).
html_comp_i(34,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(34,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(34,'Readonly',0,v,[ bool ]).
html_comp_i(34,'Autocomplete',-1,d,[ bool ]).
html_comp_i(34,'Ispassword',0,d,[ bool ]).
html_comp_i(34,'Autoresize',-1,d,[ bool ]).
html_comp_i(34,'Gxwidth',measure(4,chr),d,[ measure ]).
html_comp_i(34,'Gxheight',measure(1,row),d,[ measure ]).
html_comp_i(34,'Ismultiline',0,d,[ bool ]).
html_comp_i(34,'Maxtextnumberlines',0,d,[ num ]).
html_comp_i(34,'Fill',-1,d,[ bool ]).
html_comp_i(34,'Backcolor',rgb(255,255,255),d,[ color ]).
html_comp_i(34,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(34,'Font',font('Arial',10,[]),d,[ font ]).
html_comp_i(34,'Horizontalalignment',right,d,[ str ]).
html_comp_i(34,'Gxformat',0,d,[ num ]).
html_comp_i(34,'Title','',d,[ str ]).
html_comp_i(34,'Invitemsg','',v,[ str ]).
html_comp_i(35,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(35,'Class',row,v,[ str ]).
html_comp_i(35,'Id','',d,[ str ]).
html_comp_i(35,'Height',measure(0,px),d,[ measure ]).
html_comp_i(35,'Width',measure(0,px),d,[ measure ]).
html_comp_i(35,'Semanticcontent',div,d,[ str ]).
html_comp_i(35,'Align',left,d,[ str ]).
html_comp_i(35,'Valign',top,d,[ str ]).
html_comp_i(36,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(36,'Class','col-xs-12 FormCell',v,[ str ]).
html_comp_i(36,'Id','',d,[ str ]).
html_comp_i(36,'Height',measure(0,px),d,[ measure ]).
html_comp_i(36,'Width',measure(0,px),d,[ measure ]).
html_comp_i(36,'Semanticcontent',div,d,[ str ]).
html_comp_i(36,'Align',left,d,[ str ]).
html_comp_i(36,'Valign',top,d,[ str ]).
html_comp_i(37,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(37,'Class','form-group gx-form-group ',v,[ str ]).
html_comp_i(37,'Id','',d,[ str ]).
html_comp_i(37,'Height',measure(0,px),d,[ measure ]).
html_comp_i(37,'Width',measure(0,px),d,[ measure ]).
html_comp_i(37,'Semanticcontent',div,d,[ str ]).
html_comp_i(37,'Align',left,d,[ str ]).
html_comp_i(37,'Valign',top,d,[ str ]).
html_comp_i(38,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(38,'Class','col-sm-9 gx-attribute',v,[ str ]).
html_comp_i(38,'Id','',d,[ str ]).
html_comp_i(38,'Height',measure(0,px),d,[ measure ]).
html_comp_i(38,'Width',measure(0,px),d,[ measure ]).
html_comp_i(38,'Semanticcontent',div,d,[ str ]).
html_comp_i(38,'Align',left,d,[ str ]).
html_comp_i(38,'Valign',top,d,[ str ]).
html_comp_i(39,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(39,'Colcount',20,d,[ num ]).
html_comp_i(39,'Attid',20,v,[ num ]).
html_comp_i(39,'Class','Attribute',v,[ str ]).
html_comp_i(39,'Controlname','Customername',d,[ str ]).
html_comp_i(39,'Returnonclick',0,v,[ bool ]).
html_comp_i(39,'Captionclass','col-sm-3 AttributeLabel',v,[ str ]).
html_comp_i(39,'Captionstyle','',v,[ str ]).
html_comp_i(39,'Captionposition','Left',v,[ str ]).
html_comp_i(39,'Captionvalue','Name',d,[ str ]).
html_comp_i(39,'Layoutclass','col-sm-9',v,[ str ]).
html_comp_i(39,'Controltype',2,d,[ num ]).
html_comp_i(39,'Inputtype',0,d,[ num ]).
html_comp_i(39,'Editautocomplete',0,d,[ num ]).
html_comp_i(39,'Autocorrection',-1,d,[ bool ]).
html_comp_i(39,'Autocapitalization','FirstWord',d,[ str ]).
html_comp_i(39,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(39,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(39,'Readonly',0,v,[ bool ]).
html_comp_i(39,'Autocomplete',-1,d,[ bool ]).
html_comp_i(39,'Ispassword',0,d,[ bool ]).
html_comp_i(39,'Autoresize',-1,d,[ bool ]).
html_comp_i(39,'Gxwidth',measure(20,chr),d,[ measure ]).
html_comp_i(39,'Gxheight',measure(1,row),d,[ measure ]).
html_comp_i(39,'Ismultiline',0,d,[ bool ]).
html_comp_i(39,'Maxtextnumberlines',0,d,[ num ]).
html_comp_i(39,'Fill',-1,d,[ bool ]).
html_comp_i(39,'Backcolor',rgb(255,255,255),d,[ color ]).
html_comp_i(39,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(39,'Font',font('Arial',10,[]),d,[ font ]).
html_comp_i(39,'Horizontalalignment',left,d,[ str ]).
html_comp_i(39,'Gxformat',0,d,[ num ]).
html_comp_i(39,'Title','',d,[ str ]).
html_comp_i(39,'Invitemsg','',v,[ str ]).
html_comp_i(40,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(40,'Class',row,v,[ str ]).
html_comp_i(40,'Id','',d,[ str ]).
html_comp_i(40,'Height',measure(0,px),d,[ measure ]).
html_comp_i(40,'Width',measure(0,px),d,[ measure ]).
html_comp_i(40,'Semanticcontent',div,d,[ str ]).
html_comp_i(40,'Align',left,d,[ str ]).
html_comp_i(40,'Valign',top,d,[ str ]).
html_comp_i(41,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(41,'Class','col-xs-12 FormCell',v,[ str ]).
html_comp_i(41,'Id','',d,[ str ]).
html_comp_i(41,'Height',measure(0,px),d,[ measure ]).
html_comp_i(41,'Width',measure(0,px),d,[ measure ]).
html_comp_i(41,'Semanticcontent',div,d,[ str ]).
html_comp_i(41,'Align',left,d,[ str ]).
html_comp_i(41,'Valign',top,d,[ str ]).
html_comp_i(42,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(42,'Class','form-group gx-form-group ',v,[ str ]).
html_comp_i(42,'Id','',d,[ str ]).
html_comp_i(42,'Height',measure(0,px),d,[ measure ]).
html_comp_i(42,'Width',measure(0,px),d,[ measure ]).
html_comp_i(42,'Semanticcontent',div,d,[ str ]).
html_comp_i(42,'Align',left,d,[ str ]).
html_comp_i(42,'Valign',top,d,[ str ]).
html_comp_i(43,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(43,'Class','col-sm-9 gx-attribute',v,[ str ]).
html_comp_i(43,'Id','',d,[ str ]).
html_comp_i(43,'Height',measure(0,px),d,[ measure ]).
html_comp_i(43,'Width',measure(0,px),d,[ measure ]).
html_comp_i(43,'Semanticcontent',div,d,[ str ]).
html_comp_i(43,'Align',left,d,[ str ]).
html_comp_i(43,'Valign',top,d,[ str ]).
html_comp_i(44,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(44,'Colcount',80,d,[ num ]).
html_comp_i(44,'Attid',21,v,[ num ]).
html_comp_i(44,'Class','Attribute',v,[ str ]).
html_comp_i(44,'Controlname','Customeraddress',d,[ str ]).
html_comp_i(44,'Returnonclick',0,v,[ bool ]).
html_comp_i(44,'Captionclass','col-sm-3 AttributeLabel',v,[ str ]).
html_comp_i(44,'Captionstyle','',v,[ str ]).
html_comp_i(44,'Captionposition','Left',v,[ str ]).
html_comp_i(44,'Captionvalue','Address',d,[ str ]).
html_comp_i(44,'Layoutclass','col-sm-9',v,[ str ]).
html_comp_i(44,'Controltype',2,d,[ num ]).
html_comp_i(44,'Inputtype',0,d,[ num ]).
html_comp_i(44,'Editautocomplete',0,d,[ num ]).
html_comp_i(44,'Autocorrection',0,d,[ bool ]).
html_comp_i(44,'Autocapitalization','FirstWord',d,[ str ]).
html_comp_i(44,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(44,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(44,'Readonly',0,v,[ bool ]).
html_comp_i(44,'Autocomplete',-1,d,[ bool ]).
html_comp_i(44,'Ispassword',0,d,[ bool ]).
html_comp_i(44,'Autoresize',-1,d,[ bool ]).
html_comp_i(44,'Gxwidth',measure(80,chr),d,[ measure ]).
html_comp_i(44,'Gxheight',measure(10,row),d,[ measure ]).
html_comp_i(44,'Ismultiline',-1,d,[ bool ]).
html_comp_i(44,'Maxtextnumberlines',0,d,[ num ]).
html_comp_i(44,'Fill',-1,d,[ bool ]).
html_comp_i(44,'Backcolor',rgb(255,255,255),d,[ color ]).
html_comp_i(44,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(44,'Font',font('Arial',10,[]),d,[ font ]).
html_comp_i(44,'Horizontalalignment',left,d,[ str ]).
html_comp_i(44,'Gxformat',0,d,[ num ]).
html_comp_i(44,'Title','',d,[ str ]).
html_comp_i(44,'Invitemsg','',v,[ str ]).
html_comp_i(45,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(45,'Class',row,v,[ str ]).
html_comp_i(45,'Id','',d,[ str ]).
html_comp_i(45,'Height',measure(0,px),d,[ measure ]).
html_comp_i(45,'Width',measure(0,px),d,[ measure ]).
html_comp_i(45,'Semanticcontent',div,d,[ str ]).
html_comp_i(45,'Align',left,d,[ str ]).
html_comp_i(45,'Valign',top,d,[ str ]).
html_comp_i(46,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(46,'Class','col-xs-12 FormCell',v,[ str ]).
html_comp_i(46,'Id','',d,[ str ]).
html_comp_i(46,'Height',measure(0,px),d,[ measure ]).
html_comp_i(46,'Width',measure(0,px),d,[ measure ]).
html_comp_i(46,'Semanticcontent',div,d,[ str ]).
html_comp_i(46,'Align',left,d,[ str ]).
html_comp_i(46,'Valign',top,d,[ str ]).
html_comp_i(47,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(47,'Class','form-group gx-form-group ',v,[ str ]).
html_comp_i(47,'Id','',d,[ str ]).
html_comp_i(47,'Height',measure(0,px),d,[ measure ]).
html_comp_i(47,'Width',measure(0,px),d,[ measure ]).
html_comp_i(47,'Semanticcontent',div,d,[ str ]).
html_comp_i(47,'Align',left,d,[ str ]).
html_comp_i(47,'Valign',top,d,[ str ]).
html_comp_i(48,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(48,'Class','col-sm-9 gx-attribute',v,[ str ]).
html_comp_i(48,'Id','',d,[ str ]).
html_comp_i(48,'Height',measure(0,px),d,[ measure ]).
html_comp_i(48,'Width',measure(0,px),d,[ measure ]).
html_comp_i(48,'Semanticcontent',div,d,[ str ]).
html_comp_i(48,'Align',left,d,[ str ]).
html_comp_i(48,'Valign',top,d,[ str ]).
html_comp_i(49,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(49,'Colcount',80,d,[ num ]).
html_comp_i(49,'Attid',22,v,[ num ]).
html_comp_i(49,'Class','Attribute',v,[ str ]).
html_comp_i(49,'Controlname','Customeremail',d,[ str ]).
html_comp_i(49,'Returnonclick',0,v,[ bool ]).
html_comp_i(49,'Captionclass','col-sm-3 AttributeLabel',v,[ str ]).
html_comp_i(49,'Captionstyle','',v,[ str ]).
html_comp_i(49,'Captionposition','Left',v,[ str ]).
html_comp_i(49,'Captionvalue','Email',d,[ str ]).
html_comp_i(49,'Layoutclass','col-sm-9',v,[ str ]).
html_comp_i(49,'Controltype',2,d,[ num ]).
html_comp_i(49,'Inputtype',0,d,[ num ]).
html_comp_i(49,'Editautocomplete',0,d,[ num ]).
html_comp_i(49,'Autocorrection',0,d,[ bool ]).
html_comp_i(49,'Autocapitalization','None',d,[ str ]).
html_comp_i(49,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(49,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(49,'Readonly',0,v,[ bool ]).
html_comp_i(49,'Autocomplete',-1,d,[ bool ]).
html_comp_i(49,'Ispassword',0,d,[ bool ]).
html_comp_i(49,'Autoresize',-1,d,[ bool ]).
html_comp_i(49,'Gxwidth',measure(80,chr),d,[ measure ]).
html_comp_i(49,'Gxheight',measure(1,row),d,[ measure ]).
html_comp_i(49,'Ismultiline',0,d,[ bool ]).
html_comp_i(49,'Maxtextnumberlines',0,d,[ num ]).
html_comp_i(49,'Fill',-1,d,[ bool ]).
html_comp_i(49,'Backcolor',rgb(255,255,255),d,[ color ]).
html_comp_i(49,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(49,'Font',font('Arial',10,[]),d,[ font ]).
html_comp_i(49,'Horizontalalignment',left,d,[ str ]).
html_comp_i(49,'Gxformat',0,d,[ num ]).
html_comp_i(49,'Title','',d,[ str ]).
html_comp_i(49,'Invitemsg','',v,[ str ]).
html_comp_i(50,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(50,'Class',row,v,[ str ]).
html_comp_i(50,'Id','',d,[ str ]).
html_comp_i(50,'Height',measure(0,px),d,[ measure ]).
html_comp_i(50,'Width',measure(0,px),d,[ measure ]).
html_comp_i(50,'Semanticcontent',div,d,[ str ]).
html_comp_i(50,'Align',left,d,[ str ]).
html_comp_i(50,'Valign',top,d,[ str ]).
html_comp_i(51,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(51,'Class','col-xs-12 FormCell',v,[ str ]).
html_comp_i(51,'Id','',d,[ str ]).
html_comp_i(51,'Height',measure(0,px),d,[ measure ]).
html_comp_i(51,'Width',measure(0,px),d,[ measure ]).
html_comp_i(51,'Semanticcontent',div,d,[ str ]).
html_comp_i(51,'Align',left,d,[ str ]).
html_comp_i(51,'Valign',top,d,[ str ]).
html_comp_i(52,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(52,'Class','form-group gx-form-group ',v,[ str ]).
html_comp_i(52,'Id','',d,[ str ]).
html_comp_i(52,'Height',measure(0,px),d,[ measure ]).
html_comp_i(52,'Width',measure(0,px),d,[ measure ]).
html_comp_i(52,'Semanticcontent',div,d,[ str ]).
html_comp_i(52,'Align',left,d,[ str ]).
html_comp_i(52,'Valign',top,d,[ str ]).
html_comp_i(53,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(53,'Class','col-sm-9 gx-attribute',v,[ str ]).
html_comp_i(53,'Id','',d,[ str ]).
html_comp_i(53,'Height',measure(0,px),d,[ measure ]).
html_comp_i(53,'Width',measure(0,px),d,[ measure ]).
html_comp_i(53,'Semanticcontent',div,d,[ str ]).
html_comp_i(53,'Align',left,d,[ str ]).
html_comp_i(53,'Valign',top,d,[ str ]).
html_comp_i(54,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(54,'Colcount',20,d,[ num ]).
html_comp_i(54,'Attid',23,v,[ num ]).
html_comp_i(54,'Class','Attribute',v,[ str ]).
html_comp_i(54,'Controlname','Customerphone',d,[ str ]).
html_comp_i(54,'Returnonclick',0,v,[ bool ]).
html_comp_i(54,'Captionclass','col-sm-3 AttributeLabel',v,[ str ]).
html_comp_i(54,'Captionstyle','',v,[ str ]).
html_comp_i(54,'Captionposition','Left',v,[ str ]).
html_comp_i(54,'Captionvalue','Phone',d,[ str ]).
html_comp_i(54,'Layoutclass','col-sm-9',v,[ str ]).
html_comp_i(54,'Controltype',2,d,[ num ]).
html_comp_i(54,'Inputtype',0,d,[ num ]).
html_comp_i(54,'Editautocomplete',0,d,[ num ]).
html_comp_i(54,'Autocorrection',0,d,[ bool ]).
html_comp_i(54,'Autocapitalization','None',d,[ str ]).
html_comp_i(54,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(54,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(54,'Readonly',0,v,[ bool ]).
html_comp_i(54,'Autocomplete',-1,d,[ bool ]).
html_comp_i(54,'Ispassword',0,d,[ bool ]).
html_comp_i(54,'Autoresize',-1,d,[ bool ]).
html_comp_i(54,'Gxwidth',measure(20,chr),d,[ measure ]).
html_comp_i(54,'Gxheight',measure(1,row),d,[ measure ]).
html_comp_i(54,'Ismultiline',0,d,[ bool ]).
html_comp_i(54,'Maxtextnumberlines',0,d,[ num ]).
html_comp_i(54,'Fill',-1,d,[ bool ]).
html_comp_i(54,'Backcolor',rgb(255,255,255),d,[ color ]).
html_comp_i(54,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(54,'Font',font('Arial',10,[]),d,[ font ]).
html_comp_i(54,'Horizontalalignment',left,d,[ str ]).
html_comp_i(54,'Gxformat',0,d,[ num ]).
html_comp_i(54,'Title','',d,[ str ]).
html_comp_i(54,'Invitemsg','',v,[ str ]).
html_comp_i(55,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(55,'Class',row,v,[ str ]).
html_comp_i(55,'Id','',d,[ str ]).
html_comp_i(55,'Height',measure(0,px),d,[ measure ]).
html_comp_i(55,'Width',measure(0,px),d,[ measure ]).
html_comp_i(55,'Semanticcontent',div,d,[ str ]).
html_comp_i(55,'Align',left,d,[ str ]).
html_comp_i(55,'Valign',top,d,[ str ]).
html_comp_i(56,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(56,'Class','col-xs-12 FormCell',v,[ str ]).
html_comp_i(56,'Id','',d,[ str ]).
html_comp_i(56,'Height',measure(0,px),d,[ measure ]).
html_comp_i(56,'Width',measure(0,px),d,[ measure ]).
html_comp_i(56,'Semanticcontent',div,d,[ str ]).
html_comp_i(56,'Align',left,d,[ str ]).
html_comp_i(56,'Valign',top,d,[ str ]).
html_comp_i(57,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(57,'Class','form-group gx-form-group ',v,[ str ]).
html_comp_i(57,'Id','',d,[ str ]).
html_comp_i(57,'Height',measure(0,px),d,[ measure ]).
html_comp_i(57,'Width',measure(0,px),d,[ measure ]).
html_comp_i(57,'Semanticcontent',div,d,[ str ]).
html_comp_i(57,'Align',left,d,[ str ]).
html_comp_i(57,'Valign',top,d,[ str ]).
html_comp_i(58,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(58,'Class','col-sm-9 gx-attribute',v,[ str ]).
html_comp_i(58,'Id','',d,[ str ]).
html_comp_i(58,'Height',measure(0,px),d,[ measure ]).
html_comp_i(58,'Width',measure(0,px),d,[ measure ]).
html_comp_i(58,'Semanticcontent',div,d,[ str ]).
html_comp_i(58,'Align',left,d,[ str ]).
html_comp_i(58,'Valign',top,d,[ str ]).
html_comp_i(59,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(59,'Colcount',4,d,[ num ]).
html_comp_i(59,'Attid',8,v,[ num ]).
html_comp_i(59,'Class','Attribute',v,[ str ]).
html_comp_i(59,'Controlname','Countryid',d,[ str ]).
html_comp_i(59,'Returnonclick',0,v,[ bool ]).
html_comp_i(59,'Captionclass','col-sm-3 AttributeLabel',v,[ str ]).
html_comp_i(59,'Captionstyle','',v,[ str ]).
html_comp_i(59,'Captionposition','Left',v,[ str ]).
html_comp_i(59,'Captionvalue','Country Id',d,[ str ]).
html_comp_i(59,'Layoutclass','col-sm-9',v,[ str ]).
html_comp_i(59,'Controltype',2,d,[ num ]).
html_comp_i(59,'Inputtype',0,d,[ num ]).
html_comp_i(59,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(59,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(59,'Readonly',0,v,[ bool ]).
html_comp_i(59,'Autocomplete',-1,d,[ bool ]).
html_comp_i(59,'Ispassword',0,d,[ bool ]).
html_comp_i(59,'Autoresize',-1,d,[ bool ]).
html_comp_i(59,'Gxwidth',measure(4,chr),d,[ measure ]).
html_comp_i(59,'Gxheight',measure(1,row),d,[ measure ]).
html_comp_i(59,'Ismultiline',0,d,[ bool ]).
html_comp_i(59,'Maxtextnumberlines',0,d,[ num ]).
html_comp_i(59,'Fill',-1,d,[ bool ]).
html_comp_i(59,'Backcolor',rgb(255,255,255),d,[ color ]).
html_comp_i(59,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(59,'Font',font('Arial',10,[]),d,[ font ]).
html_comp_i(59,'Horizontalalignment',right,d,[ str ]).
html_comp_i(59,'Gxformat',0,d,[ num ]).
html_comp_i(59,'Title','',d,[ str ]).
html_comp_i(59,'Invitemsg','',v,[ str ]).
html_comp_i(60,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(60,'Class',row,v,[ str ]).
html_comp_i(60,'Id','',d,[ str ]).
html_comp_i(60,'Height',measure(0,px),d,[ measure ]).
html_comp_i(60,'Width',measure(0,px),d,[ measure ]).
html_comp_i(60,'Semanticcontent',div,d,[ str ]).
html_comp_i(60,'Align',left,d,[ str ]).
html_comp_i(60,'Valign',top,d,[ str ]).
html_comp_i(61,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(61,'Class','col-xs-12 FormCell',v,[ str ]).
html_comp_i(61,'Id','',d,[ str ]).
html_comp_i(61,'Height',measure(0,px),d,[ measure ]).
html_comp_i(61,'Width',measure(0,px),d,[ measure ]).
html_comp_i(61,'Semanticcontent',div,d,[ str ]).
html_comp_i(61,'Align',left,d,[ str ]).
html_comp_i(61,'Valign',top,d,[ str ]).
html_comp_i(62,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(62,'Class','form-group gx-form-group ',v,[ str ]).
html_comp_i(62,'Id','',d,[ str ]).
html_comp_i(62,'Height',measure(0,px),d,[ measure ]).
html_comp_i(62,'Width',measure(0,px),d,[ measure ]).
html_comp_i(62,'Semanticcontent',div,d,[ str ]).
html_comp_i(62,'Align',left,d,[ str ]).
html_comp_i(62,'Valign',top,d,[ str ]).
html_comp_i(63,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(63,'Class','col-sm-9 gx-attribute',v,[ str ]).
html_comp_i(63,'Id','',d,[ str ]).
html_comp_i(63,'Height',measure(0,px),d,[ measure ]).
html_comp_i(63,'Width',measure(0,px),d,[ measure ]).
html_comp_i(63,'Semanticcontent',div,d,[ str ]).
html_comp_i(63,'Align',left,d,[ str ]).
html_comp_i(63,'Valign',top,d,[ str ]).
html_comp_i(64,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(64,'Colcount',20,d,[ num ]).
html_comp_i(64,'Attid',9,v,[ num ]).
html_comp_i(64,'Class','Attribute',v,[ str ]).
html_comp_i(64,'Controlname','Countryname',d,[ str ]).
html_comp_i(64,'Returnonclick',0,v,[ bool ]).
html_comp_i(64,'Captionclass','col-sm-3 AttributeLabel',v,[ str ]).
html_comp_i(64,'Captionstyle','',v,[ str ]).
html_comp_i(64,'Captionposition','Left',v,[ str ]).
html_comp_i(64,'Captionvalue','Country Name',d,[ str ]).
html_comp_i(64,'Layoutclass','col-sm-9',v,[ str ]).
html_comp_i(64,'Controltype',2,d,[ num ]).
html_comp_i(64,'Inputtype',0,d,[ num ]).
html_comp_i(64,'Editautocomplete',0,d,[ num ]).
html_comp_i(64,'Autocorrection',-1,d,[ bool ]).
html_comp_i(64,'Autocapitalization','FirstWord',d,[ str ]).
html_comp_i(64,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(64,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(64,'Readonly',0,v,[ bool ]).
html_comp_i(64,'Autocomplete',-1,d,[ bool ]).
html_comp_i(64,'Ispassword',0,d,[ bool ]).
html_comp_i(64,'Autoresize',-1,d,[ bool ]).
html_comp_i(64,'Gxwidth',measure(20,chr),d,[ measure ]).
html_comp_i(64,'Gxheight',measure(1,row),d,[ measure ]).
html_comp_i(64,'Ismultiline',0,d,[ bool ]).
html_comp_i(64,'Maxtextnumberlines',0,d,[ num ]).
html_comp_i(64,'Fill',-1,d,[ bool ]).
html_comp_i(64,'Backcolor',rgb(255,255,255),d,[ color ]).
html_comp_i(64,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(64,'Font',font('Arial',10,[]),d,[ font ]).
html_comp_i(64,'Horizontalalignment',left,d,[ str ]).
html_comp_i(64,'Gxformat',0,d,[ num ]).
html_comp_i(64,'Title','',d,[ str ]).
html_comp_i(64,'Invitemsg','',v,[ str ]).
html_comp_i(65,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(65,'Class',row,v,[ str ]).
html_comp_i(65,'Id','',d,[ str ]).
html_comp_i(65,'Height',measure(0,px),d,[ measure ]).
html_comp_i(65,'Width',measure(0,px),d,[ measure ]).
html_comp_i(65,'Semanticcontent',div,d,[ str ]).
html_comp_i(65,'Align',left,d,[ str ]).
html_comp_i(65,'Valign',top,d,[ str ]).
html_comp_i(66,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(66,'Class','col-xs-12',v,[ str ]).
html_comp_i(66,'Id','',d,[ str ]).
html_comp_i(66,'Height',measure(0,px),d,[ measure ]).
html_comp_i(66,'Width',measure(0,px),d,[ measure ]).
html_comp_i(66,'Semanticcontent',div,d,[ str ]).
html_comp_i(66,'Align','Center',v,[ str ]).
html_comp_i(66,'Valign',top,d,[ str ]).
html_comp_i(67,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(67,'Class','gx-action-group Confirm',v,[ str ]).
html_comp_i(67,'Id','',d,[ str ]).
html_comp_i(67,'Height',measure(0,px),d,[ measure ]).
html_comp_i(67,'Width',measure(0,px),d,[ measure ]).
html_comp_i(67,'Semanticcontent',div,d,[ str ]).
html_comp_i(67,'Align',left,d,[ str ]).
html_comp_i(67,'Valign',top,d,[ str ]).
html_comp_i(68,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(68,'Class','gx-button',v,[ str ]).
html_comp_i(68,'Id','',d,[ str ]).
html_comp_i(68,'Height',measure(0,px),d,[ measure ]).
html_comp_i(68,'Width',measure(0,px),d,[ measure ]).
html_comp_i(68,'Semanticcontent',div,d,[ str ]).
html_comp_i(68,'Align',left,d,[ str ]).
html_comp_i(68,'Valign',top,d,[ str ]).
html_comp_i(69,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(69,'Controlname','Btn_enter',v,[ str ]).
html_comp_i(69,'Class','BtnEnter',v,[ str ]).
html_comp_i(69,'Event','Enter',v,[ str ]).
html_comp_i(69,'Caption','Confirmar',d,[ str ]).
html_comp_i(69,'Title','Confirmar',d,[ str ]).
html_comp_i(69,'Font',font('Arial',9,[]),d,[ font ]).
html_comp_i(69,'Forecolor',rgb(255,255,255),d,[ color ]).
html_comp_i(69,'Backcolor',rgb(240,240,240),d,[ color ]).
html_comp_i(69,'Border','2',d,[ str ]).
html_comp_i(69,'Bordercolor',rgb(255,255,255),d,[ color ]).
html_comp_i(69,'Buttonborderstyle',standard,d,[ str ]).
html_comp_i(70,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(70,'Class','gx-button',v,[ str ]).
html_comp_i(70,'Id','',d,[ str ]).
html_comp_i(70,'Height',measure(0,px),d,[ measure ]).
html_comp_i(70,'Width',measure(0,px),d,[ measure ]).
html_comp_i(70,'Semanticcontent',div,d,[ str ]).
html_comp_i(70,'Align',left,d,[ str ]).
html_comp_i(70,'Valign',top,d,[ str ]).
html_comp_i(71,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(71,'Controlname','Btn_cancel',v,[ str ]).
html_comp_i(71,'Class','BtnCancel',v,[ str ]).
html_comp_i(71,'Event','Cancel',v,[ str ]).
html_comp_i(71,'Caption','Fechar',d,[ str ]).
html_comp_i(71,'Title','Fechar',d,[ str ]).
html_comp_i(71,'Font',font('Arial',9,[]),d,[ font ]).
html_comp_i(71,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(71,'Backcolor',rgb(240,240,240),d,[ color ]).
html_comp_i(71,'Border','2',d,[ str ]).
html_comp_i(71,'Bordercolor',rgb(255,255,255),d,[ color ]).
html_comp_i(71,'Buttonborderstyle',standard,d,[ str ]).
html_comp_i(72,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(72,'Class','gx-button',v,[ str ]).
html_comp_i(72,'Id','',d,[ str ]).
html_comp_i(72,'Height',measure(0,px),d,[ measure ]).
html_comp_i(72,'Width',measure(0,px),d,[ measure ]).
html_comp_i(72,'Semanticcontent',div,d,[ str ]).
html_comp_i(72,'Align',left,d,[ str ]).
html_comp_i(72,'Valign',top,d,[ str ]).
html_comp_i(73,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(73,'Controlname','Btn_delete',v,[ str ]).
html_comp_i(73,'Class','BtnDelete',v,[ str ]).
html_comp_i(73,'Event','Delete',v,[ str ]).
html_comp_i(73,'Caption','Eliminar',d,[ str ]).
html_comp_i(73,'Title','Eliminar',d,[ str ]).
html_comp_i(73,'Font',font('Arial',9,[]),d,[ font ]).
html_comp_i(73,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(73,'Backcolor',rgb(240,240,240),d,[ color ]).
html_comp_i(73,'Border','2',d,[ str ]).
html_comp_i(73,'Bordercolor',rgb(255,255,255),d,[ color ]).
html_comp_i(73,'Buttonborderstyle',standard,d,[ str ]).
 
 
 
 
 
 
 
 
 
lit_i(9,1,t('Customer',3),[ ctlname('Title') ]).
lit_i(8,1,div(8),[ ctlname('') ]).
lit_i(7,1,div(7),[ ctlname('') ]).
lit_i(12,1,comp(errview),[ ctlname('Errorviewer'),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(11,1,div(11),[ ctlname('') ]).
lit_i(10,1,div(10),[ ctlname('') ]).
lit_i(6,1,div(6),[ ctlname('Titlecontainer') ]).
lit_i(5,1,div(5),[ ctlname('') ]).
lit_i(4,1,div(4),[ ctlname('') ]).
lit_i(21,1,button('First'),[ ctlname('Btn_first'),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(20,1,div(20),[ ctlname('') ]).
lit_i(23,1,button('Previous'),[ ctlname('Btn_previous'),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(22,1,div(22),[ ctlname('') ]).
lit_i(25,1,button('Next'),[ ctlname('Btn_next'),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(24,1,div(24),[ ctlname('') ]).
lit_i(27,1,button('Last'),[ ctlname('Btn_last'),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(26,1,div(26),[ ctlname('') ]).
lit_i(29,1,button('Select'),[ ctlname('Btn_select'),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(28,1,div(28),[ ctlname('') ]).
lit_i(19,1,div(19),[ ctlname('') ]).
lit_i(18,1,div(18),[ ctlname('') ]).
lit_i(17,1,div(17),[ ctlname('Toolbarcell') ]).
lit_i(16,1,div(16),[ ctlname('') ]).
lit_i(34,1,t(11,2),[ ctlname(11),ctrltype(edit,34),pos(34),ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(33,1,div(33),[ ctlname('') ]).
lit_i(32,1,div(32),[ ctlname('') ]).
lit_i(31,1,div(31),[ ctlname('') ]).
lit_i(30,1,div(30),[ ctlname('') ]).
lit_i(39,1,t(20,2),[ ctlname(20),ctrltype(edit,39),pos(39),ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(38,1,div(38),[ ctlname('') ]).
lit_i(37,1,div(37),[ ctlname('') ]).
lit_i(36,1,div(36),[ ctlname('') ]).
lit_i(35,1,div(35),[ ctlname('') ]).
lit_i(44,1,t(21,2),[ ctlname(21),ctrltype(edit,44),pos(44),ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(43,1,div(43),[ ctlname('') ]).
lit_i(42,1,div(42),[ ctlname('') ]).
lit_i(41,1,div(41),[ ctlname('') ]).
lit_i(40,1,div(40),[ ctlname('') ]).
lit_i(49,1,t(22,2),[ ctlname(22),ctrltype(edit,49),pos(49),ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(48,1,div(48),[ ctlname('') ]).
lit_i(47,1,div(47),[ ctlname('') ]).
lit_i(46,1,div(46),[ ctlname('') ]).
lit_i(45,1,div(45),[ ctlname('') ]).
lit_i(54,1,t(23,2),[ ctlname(23),ctrltype(edit,54),pos(54),ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(53,1,div(53),[ ctlname('') ]).
lit_i(52,1,div(52),[ ctlname('') ]).
lit_i(51,1,div(51),[ ctlname('') ]).
lit_i(50,1,div(50),[ ctlname('') ]).
lit_i(59,1,t(8,2),[ ctlname(8),ctrltype(edit,59),pos(59),ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(58,1,div(58),[ ctlname('') ]).
lit_i(57,1,div(57),[ ctlname('') ]).
lit_i(56,1,div(56),[ ctlname('') ]).
lit_i(55,1,div(55),[ ctlname('') ]).
lit_i(64,1,t(9,2),[ ctlname(9),ctrltype(edit,64),pos(64),ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(63,1,div(63),[ ctlname('') ]).
lit_i(62,1,div(62),[ ctlname('') ]).
lit_i(61,1,div(61),[ ctlname('') ]).
lit_i(60,1,div(60),[ ctlname('') ]).
lit_i(15,1,div(15),[ ctlname('Formcontainer') ]).
lit_i(14,1,div(14),[ ctlname('') ]).
lit_i(13,1,div(13),[ ctlname('') ]).
lit_i(69,1,button('Enter'),[ ctlname('Btn_enter'),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(68,1,div(68),[ ctlname('') ]).
lit_i(71,1,button('Cancel'),[ ctlname('Btn_cancel'),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(70,1,div(70),[ ctlname('') ]).
lit_i(73,1,button('Delete'),[ ctlname('Btn_delete'),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(72,1,div(72),[ ctlname('') ]).
lit_i(67,1,div(67),[ ctlname('') ]).
lit_i(66,1,div(66),[ ctlname('') ]).
lit_i(65,1,div(65),[ ctlname('') ]).
lit_i(3,1,div(3),[ ctlname('Maintable') ]).
lit_i(2,1,div(2),[ ctlname('') ]).
lit_i(1,1,window,[ rect(0,0,1000,1000),ctlname('Form') ]).
 
 
 
 
 
 
 
 
 
att_prop_i(2,11,'ExternalName','CustomerId',d).
att_prop_i(2,11,'ExternalNamespace','WorkShopNew',d).
att_prop_i(2,11,'EmptyAsNull','Yes',d).
att_prop_i(2,11,idBasedOn,88,v).
att_prop_i(2,11,'AUTONUMBER','-1',d).
att_prop_i(2,11,'AUTONUMBER_START','1',d).
att_prop_i(2,11,'AUTONUMBER_STEP','1',d).
att_prop_i(2,11,'AUTONUMBER_FORREPLICATION','-1',d).
att_prop_i(2,11,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,11,'AttRegEx','',d).
att_prop_i(2,11,'AttValidationFailedMsg','',d).
att_prop_i(2,11,'DownloadOffline','0',d).
att_prop_i(2,11,'VarServiceExtName','',d).
att_prop_i(2,11,'FullName','CustomerId',v).
att_prop_i(2,20,'ExternalName','CustomerName',d).
att_prop_i(2,20,'ExternalNamespace','WorkShopNew',d).
att_prop_i(2,20,'EmptyAsNull','Yes',d).
att_prop_i(2,20,idBasedOn,89,v).
att_prop_i(2,20,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,20,'DB_NLS_SUPPORT','Yes',d).
att_prop_i(2,20,'AttRegEx','',d).
att_prop_i(2,20,'AttValidationFailedMsg','',d).
att_prop_i(2,20,'DownloadOffline','0',d).
att_prop_i(2,20,'VarServiceExtName','',d).
att_prop_i(2,20,'FullName','CustomerName',v).
att_prop_i(2,21,'ExternalName','CustomerAddress',d).
att_prop_i(2,21,'ExternalNamespace','WorkShopNew',d).
att_prop_i(2,21,'EmptyAsNull','Yes',d).
att_prop_i(2,21,idBasedOn,43,v).
att_prop_i(2,21,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,21,'DB_NLS_SUPPORT','Yes',d).
att_prop_i(2,21,'AttRegEx','',d).
att_prop_i(2,21,'AttValidationFailedMsg','',d).
att_prop_i(2,21,'DownloadOffline','0',d).
att_prop_i(2,21,'VarServiceExtName','',d).
att_prop_i(2,21,'FullName','CustomerAddress',v).
att_prop_i(2,22,'ExternalName','CustomerEmail',d).
att_prop_i(2,22,'ExternalNamespace','WorkShopNew',d).
att_prop_i(2,22,'EmptyAsNull','Yes',d).
att_prop_i(2,22,idBasedOn,45,v).
att_prop_i(2,22,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,22,'DB_NLS_SUPPORT','Yes',d).
att_prop_i(2,22,'AttRegEx','^((\w+([-+.'']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)|(\s*))$',d).
att_prop_i(2,22,'AttValidationFailedMsg','GXM_DoesNotMatchRegExp',d).
att_prop_i(2,22,'DownloadOffline','0',d).
att_prop_i(2,22,'VarServiceExtName','',d).
att_prop_i(2,22,'FullName','CustomerEmail',v).
att_prop_i(2,23,'ExternalName','CustomerPhone',d).
att_prop_i(2,23,'ExternalNamespace','WorkShopNew',d).
att_prop_i(2,23,'EmptyAsNull','Yes',d).
att_prop_i(2,23,idBasedOn,48,v).
att_prop_i(2,23,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,23,'DB_NLS_SUPPORT','Yes',d).
att_prop_i(2,23,'AttRegEx','',d).
att_prop_i(2,23,'AttValidationFailedMsg','',d).
att_prop_i(2,23,'DownloadOffline','0',d).
att_prop_i(2,23,'VarServiceExtName','',d).
att_prop_i(2,23,'FullName','CustomerPhone',v).
att_prop_i(2,8,'ExternalName','CountryId',d).
att_prop_i(2,8,'ExternalNamespace','WorkShopNew',d).
att_prop_i(2,8,'EmptyAsNull','Yes',d).
att_prop_i(2,8,idBasedOn,88,v).
att_prop_i(2,8,'AUTONUMBER','-1',d).
att_prop_i(2,8,'AUTONUMBER_START','1',d).
att_prop_i(2,8,'AUTONUMBER_STEP','1',d).
att_prop_i(2,8,'AUTONUMBER_FORREPLICATION','-1',d).
att_prop_i(2,8,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,8,'AttRegEx','',d).
att_prop_i(2,8,'AttValidationFailedMsg','',d).
att_prop_i(2,8,'DownloadOffline','0',d).
att_prop_i(2,8,'VarServiceExtName','',d).
att_prop_i(2,8,'FullName','CountryId',v).
att_prop_i(2,9,'ExternalName','CountryName',d).
att_prop_i(2,9,'ExternalNamespace','WorkShopNew',d).
att_prop_i(2,9,'EmptyAsNull','Yes',d).
att_prop_i(2,9,idBasedOn,89,v).
att_prop_i(2,9,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,9,'DB_NLS_SUPPORT','Yes',d).
att_prop_i(2,9,'AttRegEx','',d).
att_prop_i(2,9,'AttValidationFailedMsg','',d).
att_prop_i(2,9,'DownloadOffline','0',d).
att_prop_i(2,9,'VarServiceExtName','',d).
att_prop_i(2,9,'FullName','CountryName',v).
att_prop_i(2,16,'ExternalName','ShoppingCartId',d).
att_prop_i(2,16,'ExternalNamespace','WorkShopNew',d).
att_prop_i(2,16,'EmptyAsNull','Yes',d).
att_prop_i(2,16,idBasedOn,88,v).
att_prop_i(2,16,'AUTONUMBER','-1',d).
att_prop_i(2,16,'AUTONUMBER_START','1',d).
att_prop_i(2,16,'AUTONUMBER_STEP','1',d).
att_prop_i(2,16,'AUTONUMBER_FORREPLICATION','-1',d).
att_prop_i(2,16,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,16,'AttRegEx','',d).
att_prop_i(2,16,'AttValidationFailedMsg','',d).
att_prop_i(2,16,'DownloadOffline','0',d).
att_prop_i(2,16,'VarServiceExtName','',d).
att_prop_i(2,16,'FullName','ShoppingCartId',v).
 
tbl_prop_i(2,9,'AllDirSuper',[ [ 5,[ 11 ] ] ],v).
tbl_prop_i(2,5,'AllDirSuper',[ [ 3,[ 8 ] ] ],v).
tbl_prop_i(2,3,'DirSubor',[ [ 5,[ 8 ] ] ],v).
tbl_prop_i(2,5,'DirSubor',[ [ 9,[ 11 ] ] ],v).
tbl_prop_i(2,9,'DirSuper',[ [ 5,[ 11 ] ] ],v).
tbl_prop_i(2,5,'DirSuper',[ [ 3,[ 8 ] ] ],v).
 
tbl_att_prop_i(2,5,22,'AllowNulls',n).
tbl_att_prop_i(2,5,11,'AllowNulls',n).
tbl_att_prop_i(2,5,11,'AUTONUMBER',y).
tbl_att_prop_i(2,5,20,'AllowNulls',n).
tbl_att_prop_i(2,5,21,'AllowNulls',n).
tbl_att_prop_i(2,5,23,'AllowNulls',n).
tbl_att_prop_i(2,5,8,'AllowNulls',n).
tbl_att_prop_i(2,3,8,'AllowNulls',n).
tbl_att_prop_i(2,3,8,'AUTONUMBER',y).
tbl_att_prop_i(2,3,9,'AllowNulls',n).
tbl_att_prop_i(2,9,16,'AllowNulls',n).
tbl_att_prop_i(2,9,16,'AUTONUMBER',y).
tbl_att_prop_i(2,9,11,'AllowNulls',n).
 
var_prop_i(2,'Customerid',idBasedOn,'',v).
var_prop_i(2,'Insert_countryid',idBasedOn,'',v).
 
 
 
 
trn_level_i(5,[ [ 11,20,21,22,23,8,9 ],'Customer','Customer','Customer','',20 ]).
 
struct_dt_i([ 26,56,0 ],name,'TransactionContext').
struct_dt_i([ 26,56,0 ],namespace,'WorkShopNew').
struct_dt_i([ 26,56,0 ],'ObjName','TransactionContext').
struct_dt_i([ 26,56,0 ],'ObjDesc','Transaction Context').
struct_dt_i([ 26,56,0 ],'ExternalName','TransactionContext').
struct_dt_i([ 26,56,0 ],'ExternalNamespace','WorkShopNew').
struct_dt_i([ 26,56,0 ],'JsonInclude',idJsonNoProperty).
struct_dt_i([ 26,56,84 ],name,'Attribute').
struct_dt_i([ 26,56,84 ],namespace,'WorkShopNew.TransactionContext').
struct_dt_i([ 26,56,0 ],fullname,'TransactionContext').
struct_dt_i([ 26,56,84 ],fullname,'TransactionContext.Attribute').
 
struct_dt_elem_i([ 26,56,0 ],1,name,'Callerobject').
struct_dt_elem_i([ 26,56,0 ],1,camelname,'CallerObject').
struct_dt_elem_i([ 26,56,0 ],1,basedon,53).
struct_dt_elem_i([ 26,56,0 ],1,length,256).
struct_dt_elem_i([ 26,56,0 ],1,decimals,0).
struct_dt_elem_i([ 26,56,0 ],1,type,[ 13,256,0 ]).
struct_dt_elem_i([ 26,56,0 ],1,pic,'').
struct_dt_elem_i([ 26,56,0 ],1,collection,'False').
struct_dt_elem_i([ 26,56,0 ],1,'ExternalName','CallerObject').
struct_dt_elem_i([ 26,56,0 ],1,'ExternalNamespace','WorkShopNew').
struct_dt_elem_i([ 26,56,0 ],1,'XmlType','Element').
struct_dt_elem_i([ 26,56,0 ],1,'XmlName','').
struct_dt_elem_i([ 26,56,0 ],1,'XmlNamespace','').
struct_dt_elem_i([ 26,56,0 ],1,soaptype,'').
struct_dt_elem_i([ 26,56,0 ],1,'XmlInclude',idXmlIncludeAlways).
struct_dt_elem_i([ 26,56,0 ],1,'JsonName','').
struct_dt_elem_i([ 26,56,0 ],1,'JsonInclude',idJsonEmpty).
struct_dt_elem_i([ 26,56,0 ],2,name,'Callerondelete').
struct_dt_elem_i([ 26,56,0 ],2,camelname,'CallerOnDelete').
struct_dt_elem_i([ 26,56,0 ],2,length,4).
struct_dt_elem_i([ 26,56,0 ],2,decimals,0).
struct_dt_elem_i([ 26,56,0 ],2,type,[ 15,4,0 ]).
struct_dt_elem_i([ 26,56,0 ],2,pic,'').
struct_dt_elem_i([ 26,56,0 ],2,collection,'False').
struct_dt_elem_i([ 26,56,0 ],2,'ExternalName','CallerOnDelete').
struct_dt_elem_i([ 26,56,0 ],2,'ExternalNamespace','WorkShopNew').
struct_dt_elem_i([ 26,56,0 ],2,'XmlType','Element').
struct_dt_elem_i([ 26,56,0 ],2,'XmlName','').
struct_dt_elem_i([ 26,56,0 ],2,'XmlNamespace','').
struct_dt_elem_i([ 26,56,0 ],2,soaptype,'').
struct_dt_elem_i([ 26,56,0 ],2,'XmlInclude',idXmlIncludeAlways).
struct_dt_elem_i([ 26,56,0 ],2,'JsonName','').
struct_dt_elem_i([ 26,56,0 ],2,'JsonInclude',idJsonEmpty).
struct_dt_elem_i([ 26,56,0 ],3,name,'Callerurl').
struct_dt_elem_i([ 26,56,0 ],3,camelname,'CallerURL').
struct_dt_elem_i([ 26,56,0 ],3,basedon,32).
struct_dt_elem_i([ 26,56,0 ],3,length,1000).
struct_dt_elem_i([ 26,56,0 ],3,decimals,0).
struct_dt_elem_i([ 26,56,0 ],3,type,[ 13,1000,0 ]).
struct_dt_elem_i([ 26,56,0 ],3,pic,'').
struct_dt_elem_i([ 26,56,0 ],3,collection,'False').
struct_dt_elem_i([ 26,56,0 ],3,'ExternalName','CallerURL').
struct_dt_elem_i([ 26,56,0 ],3,'ExternalNamespace','WorkShopNew').
struct_dt_elem_i([ 26,56,0 ],3,'XmlType','Element').
struct_dt_elem_i([ 26,56,0 ],3,'XmlName','').
struct_dt_elem_i([ 26,56,0 ],3,'XmlNamespace','').
struct_dt_elem_i([ 26,56,0 ],3,soaptype,'').
struct_dt_elem_i([ 26,56,0 ],3,'XmlInclude',idXmlIncludeAlways).
struct_dt_elem_i([ 26,56,0 ],3,'JsonName','').
struct_dt_elem_i([ 26,56,0 ],3,'JsonInclude',idJsonEmpty).
struct_dt_elem_i([ 26,56,0 ],4,name,'Transactionname').
struct_dt_elem_i([ 26,56,0 ],4,camelname,'TransactionName').
struct_dt_elem_i([ 26,56,0 ],4,basedon,53).
struct_dt_elem_i([ 26,56,0 ],4,length,256).
struct_dt_elem_i([ 26,56,0 ],4,decimals,0).
struct_dt_elem_i([ 26,56,0 ],4,type,[ 13,256,0 ]).
struct_dt_elem_i([ 26,56,0 ],4,pic,'').
struct_dt_elem_i([ 26,56,0 ],4,collection,'False').
struct_dt_elem_i([ 26,56,0 ],4,'ExternalName','TransactionName').
struct_dt_elem_i([ 26,56,0 ],4,'ExternalNamespace','WorkShopNew').
struct_dt_elem_i([ 26,56,0 ],4,'XmlType','Element').
struct_dt_elem_i([ 26,56,0 ],4,'XmlName','').
struct_dt_elem_i([ 26,56,0 ],4,'XmlNamespace','').
struct_dt_elem_i([ 26,56,0 ],4,soaptype,'').
struct_dt_elem_i([ 26,56,0 ],4,'XmlInclude',idXmlIncludeAlways).
struct_dt_elem_i([ 26,56,0 ],4,'JsonName','').
struct_dt_elem_i([ 26,56,0 ],4,'JsonInclude',idJsonEmpty).
struct_dt_elem_i([ 26,56,0 ],5,name,'Attributes').
struct_dt_elem_i([ 26,56,0 ],5,camelname,'Attributes').
struct_dt_elem_i([ 26,56,0 ],5,type,[ [ 26,56,84 ],0,0 ]).
struct_dt_elem_i([ 26,56,0 ],5,pic,'').
struct_dt_elem_i([ 26,56,0 ],5,collection,'True').
struct_dt_elem_i([ 26,56,0 ],5,'ObjName','Attributes').
struct_dt_elem_i([ 26,56,0 ],5,'ObjDesc','Attributes').
struct_dt_elem_i([ 26,56,0 ],5,'CollectionItemName','Attribute').
struct_dt_elem_i([ 26,56,0 ],5,'XmlName','').
struct_dt_elem_i([ 26,56,0 ],5,'XmlCollectionItemName','').
struct_dt_elem_i([ 26,56,0 ],5,'XmlNamespace','').
struct_dt_elem_i([ 26,56,0 ],5,'CollectionSerialization',idXmlCollectionWrapped).
struct_dt_elem_i([ 26,56,0 ],5,'XmlInclude',idXmlIncludeAlways).
struct_dt_elem_i([ 26,56,0 ],5,'JsonName','').
struct_dt_elem_i([ 26,56,0 ],5,'JsonInclude',idJsonNoProperty).
struct_dt_elem_i([ 26,56,0 ],5,'JsonCollectionSerialization',idXmlCollectionWrapped).
struct_dt_elem_i([ 26,56,84 ],1,name,'Attributename').
struct_dt_elem_i([ 26,56,84 ],1,camelname,'AttributeName').
struct_dt_elem_i([ 26,56,84 ],1,length,128).
struct_dt_elem_i([ 26,56,84 ],1,decimals,0).
struct_dt_elem_i([ 26,56,84 ],1,type,[ 13,128,0 ]).
struct_dt_elem_i([ 26,56,84 ],1,pic,'').
struct_dt_elem_i([ 26,56,84 ],1,collection,'False').
struct_dt_elem_i([ 26,56,84 ],1,'ExternalName','AttributeName').
struct_dt_elem_i([ 26,56,84 ],1,'ExternalNamespace','WorkShopNew').
struct_dt_elem_i([ 26,56,84 ],1,'XmlType','Element').
struct_dt_elem_i([ 26,56,84 ],1,'XmlName','').
struct_dt_elem_i([ 26,56,84 ],1,'XmlNamespace','').
struct_dt_elem_i([ 26,56,84 ],1,soaptype,'').
struct_dt_elem_i([ 26,56,84 ],1,'XmlInclude',idXmlIncludeAlways).
struct_dt_elem_i([ 26,56,84 ],1,'JsonName','').
struct_dt_elem_i([ 26,56,84 ],1,'JsonInclude',idJsonEmpty).
struct_dt_elem_i([ 26,56,84 ],2,name,'Attributevalue').
struct_dt_elem_i([ 26,56,84 ],2,camelname,'AttributeValue').
struct_dt_elem_i([ 26,56,84 ],2,length,1000).
struct_dt_elem_i([ 26,56,84 ],2,decimals,0).
struct_dt_elem_i([ 26,56,84 ],2,type,[ 13,1000,0 ]).
struct_dt_elem_i([ 26,56,84 ],2,pic,'').
struct_dt_elem_i([ 26,56,84 ],2,collection,'False').
struct_dt_elem_i([ 26,56,84 ],2,'ExternalName','AttributeValue').
struct_dt_elem_i([ 26,56,84 ],2,'ExternalNamespace','WorkShopNew').
struct_dt_elem_i([ 26,56,84 ],2,'XmlType','Element').
struct_dt_elem_i([ 26,56,84 ],2,'XmlName','').
struct_dt_elem_i([ 26,56,84 ],2,'XmlNamespace','').
struct_dt_elem_i([ 26,56,84 ],2,soaptype,'').
struct_dt_elem_i([ 26,56,84 ],2,'XmlInclude',idXmlIncludeAlways).
struct_dt_elem_i([ 26,56,84 ],2,'JsonName','').
struct_dt_elem_i([ 26,56,84 ],2,'JsonInclude',idJsonEmpty).
struct_dt_elem_i([ 26,56,0 ],3,pic,'99/99/99').
 
 
 
 
 
sub_info_i(146,'Start',1,28,[ [ 'Pgmname','Websession','Mode' ],[ 'Trncontext','Insert_countryid','GXV1','Trncontextatt',[ t('Btn_enter',3),t('Caption',3) ],[ t('Btn_enter',3),t('Tooltiptext',3) ] ] ]).
sub_info_i(146,'After Trn',30,41,[ [ 'Mode','Trncontext' ],[] ]).
 
pgm_parm_i(web,30,'GX0030',[ [ int,4,0,0 ] ],[ [ pCountryId,out,[] ] ]).
pgm_parm_i(web,49,'WWCUSTOMER',[],[]).
pgm_parm_i(web,9,'NOTAUTHORIZED',[ [ svchar,256,0,0 ] ],[ [ 'GxObject',in,[] ] ]).
pgm_parm_i(proc,13,'ISAUTHORIZED',[ [ svchar,256,0,0 ],[ boolean,4,0,0 ] ],[ [ 'GxObject',in,[] ],[ 'Authorized',out,[] ] ]).
 
pgm_callprotocol_i(trn,7,'CUSTOMER','INTERNAL','Unsecure').
pgm_callprotocol_i(web,30,'GX0030','INTERNAL','Unsecure').
pgm_callprotocol_i(web,49,'WWCUSTOMER','INTERNAL','').
pgm_callprotocol_i(web,9,'NOTAUTHORIZED','INTERNAL','Unsecure').
pgm_callprotocol_i(proc,13,'ISAUTHORIZED','INTERNAL','Unsecure').
 
 
 
 
module_info_i('GeneXus','CSHARP_NAME_SPACE','GeneXus.Core').
module_info_i('GeneXus','AssemblyName','GeneXus.dll').
 
 
 
 
 
 
 
 
 
 
