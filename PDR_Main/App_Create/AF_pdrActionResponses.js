<script type="text/javascript"> 
var script_pdrActionResponses = {
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
    ACEActionNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ActionNo','');
      var F_ActionNo = $get(sender._element.id);
      var F_ActionNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ActionNo.value = p[1];
      F_ActionNo_Display.innerHTML = e.get_text();
    },
    ACEActionNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ActionNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEActionNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_PDRNo: function(sender) {
      var Prefix = sender.id.replace('PDRNo','');
      this.validated_FK_PDR_ActionResponses_PDRNo_main = true;
      this.validate_FK_PDR_ActionResponses_PDRNo(sender,Prefix);
      },
    validate_ActionNo: function(sender) {
      var Prefix = sender.id.replace('ActionNo','');
      this.validated_FK_PDR_ActionResponses_ActionNo_main = true;
      this.validate_FK_PDR_ActionResponses_ActionNo(sender,Prefix);
      },
    validate_FK_PDR_ActionResponses_ActionNo: function(o,Prefix) {
      var value = o.id;
      var PDRNo = $get(Prefix + 'PDRNo');
      if(PDRNo.value==''){
        if(this.validated_FK_PDR_ActionResponses_ActionNo_main){
          var o_d = $get(Prefix + 'PDRNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + PDRNo.value ;
      var ActionNo = $get(Prefix + 'ActionNo');
      if(ActionNo.value==''){
        if(this.validated_FK_PDR_ActionResponses_ActionNo_main){
          var o_d = $get(Prefix + 'ActionNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ActionNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PDR_ActionResponses_ActionNo(value, this.validated_FK_PDR_ActionResponses_ActionNo);
      },
    validated_FK_PDR_ActionResponses_ActionNo_main: false,
    validated_FK_PDR_ActionResponses_ActionNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pdrActionResponses.validated_FK_PDR_ActionResponses_ActionNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PDR_ActionResponses_PDRNo: function(o,Prefix) {
      var value = o.id;
      var PDRNo = $get(Prefix + 'PDRNo');
      if(PDRNo.value==''){
        if(this.validated_FK_PDR_ActionResponses_PDRNo_main){
          var o_d = $get(Prefix + 'PDRNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + PDRNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PDR_ActionResponses_PDRNo(value, this.validated_FK_PDR_ActionResponses_PDRNo);
      },
    validated_FK_PDR_ActionResponses_PDRNo_main: false,
    validated_FK_PDR_ActionResponses_PDRNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pdrActionResponses.validated_FK_PDR_ActionResponses_PDRNo_main){
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
