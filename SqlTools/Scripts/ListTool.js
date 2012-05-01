(function() {

  $(document).ready(function() {
    var viewModel;
    viewModel = {
      SourceText: ko.observable("")
    };
    viewModel.ProcessedText = ko.computed(function() {
      var i, line, lines, text, textToChange, _i, _len;
      textToChange = $.trim(this.SourceText());
      if (textToChange === "") {
        return "";
      }
      lines = textToChange.match(/^.*([\n\r]+|$)/gm);
      text = "";
      for (i = _i = 0, _len = lines.length; _i < _len; i = ++_i) {
        line = lines[i];
        text = text + ("\n\'" + ($.trim(line)) + "\'");
        if (i + 1 !== lines.length) {
          text = text + ",";
        }
      }
      text = $.trim(text);
      return text;
    }, viewModel);
    viewModel.ProcessedTextThrottled = ko.computed(function() {
      return this.ProcessedText();
    }, viewModel).extend({
      throttle: 500
    });
    ko.computed(function() {
      return $('.clippy').clippy({
        text: this.ProcessedTextThrottled(),
        clippy_path: '/Content/clippy.swf'
      });
    }, viewModel);
    ko.applyBindings(viewModel);
    return $('.tooltip').tipsy({
      gravity: 'e',
      title: 'data-tooltip',
      fade: true
    });
  });

}).call(this);
