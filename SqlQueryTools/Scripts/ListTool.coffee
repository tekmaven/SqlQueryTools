$(document).ready () ->
	viewModel = { SourceText: ko.observable "" }
	viewModel.ProcessedText = ko.computed () ->
		textToChange = $.trim(@SourceText())
		if textToChange == ""
			return ""
		lines = textToChange.match(/^.*([\n\r]+|$)/gm) # I hate regex, and this is borred from a StackOverflow post.
		text = ""
		for line, i in lines
			text = text + "\n\'#{$.trim(line)}\'"
			if i+1 != lines.length
				text = text + ","
		text = $.trim(text)
		return text
	, viewModel

	viewModel.ProcessedTextThrottled = ko.computed(() ->
		return @ProcessedText()
	, viewModel).extend({ throttle: 500 });

	ko.computed () ->
		$('.clippy').clippy {text: @ProcessedTextThrottled(), clippy_path: '/Content/clippy.swf'}
	, viewModel


	ko.applyBindings viewModel	

	$('.tooltip').tipsy {
		gravity: 'e'
		title: 'data-tooltip'
		fade: true
	}