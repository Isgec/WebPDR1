<script type="text/javascript"> 
var script_pdrActionPlan = {
    ACEPDRNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('PDRNo','');
      var F_PDRNo = $get(sender._element.id);
      var F_PDRNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_PDRNo.value = p[0];
      F_PDRNo_Display.innerHTML = e.get_text();
    },
    ACEPDRNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('PDRNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEPDRNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEResponsible_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('Responsible','');
      var F_Responsible = $get(sender._element.id);
      var F_Responsible_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_Responsible.value = p[0];
      F_Responsible_Display.innerHTML = e.get_text();
    },
    ACEResponsible_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('Responsible','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEResponsible_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_Responsible: function(sender) {
      var Prefix = sender.id.replace('Responsible','');
      this.validated_FK_PDR_Actions_Responsible_main = true;
      this.validate_FK_PDR_Actions_Responsible(sender,Prefix);
      },
    validate_FK_PDR_Actions_Responsible: function(o,Prefix) {
      var value = o.id;
      var Responsible = $get(Prefix + 'Responsible');
      if(Responsible.value==''){
        if(this.validated_FK_PDR_Actions_Responsible_main){
          var o_d = $get(Prefix + 'Responsible' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + Responsible.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PDR_Actions_Responsible(value, this.validated_FK_PDR_Actions_Responsible);
      },
    validated_FK_PDR_Actions_Responsible_main: false,
    validated_FK_PDR_Actions_Responsible: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pdrActionPlan.validated_FK_PDR_Actions_Responsible_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
