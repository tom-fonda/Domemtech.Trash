# Generated from trgen <version>
$(& Remove-Item *.class -Recurse -Force ) 2>&1 | Out-Null
$(& Remove-Item *.tokens -Recurse -Force ) 2>&1 | Out-Null
$(& Remove-Item *.interp -Recurse -Force ) 2>&1 | Out-Null
<tool_grammar_tuples:{x|$(& Remove-Item <x.GeneratedFileName> -Force ) 2>&1 | Out-Null
}>
exit 0
