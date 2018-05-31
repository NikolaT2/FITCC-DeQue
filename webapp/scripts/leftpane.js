$(document).ready(function(){
    if ($(window).width() <= 576){  
      $('.left-info-pane').hide();
    }
  });
  
  $(window).resize(function(){
    if ($(window).width() >= 576){  
      $('.left-info-pane').show();
    }
    if ($(window).width() <= 576){  
      $('.left-info-pane').hide();
    }
  });