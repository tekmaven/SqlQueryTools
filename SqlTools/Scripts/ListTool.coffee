$(document).ready () ->
	viewModel = { SourceText: ko.observable "" }
	viewModel.ProcessedText = ko.computed () ->
		textToChange = $.trim(@SourceText())
		if textToChange == ""
			return ""
		lines = textToChange.match(/^.*([\n\r]+|$)/gm)
		text = ""
		for line, i in lines
			text = text + "\n\'#{$.trim(line)}\'"
			if i+1 != lines.length
				text = text + ","
		return $.trim(text)
	,viewModel

	ko.applyBindings viewModel