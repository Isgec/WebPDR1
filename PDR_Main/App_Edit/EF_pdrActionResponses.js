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
    temp: function() {
    }
    }
</script>
