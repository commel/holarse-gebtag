Main.exe: Main.cs
	mcs -out:$@ $<

.PHONY: clean
clean:
	$(RM) Main.exe
