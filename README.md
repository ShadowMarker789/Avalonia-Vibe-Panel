# Avalonia-Vibe-Panel
Arranging elements by vibes

[Try it here](https://ShadowMarker789.github.io/Avalonia-Vibe-Panel/Demo/index.html)

## What is this, and why is this?

Sometimes you want an object "On the left" or "On the right" or perhaps even want to slightly nudge an element a bit without worrying about it clipping out of the panel. 

Two attached properties, X and Y. 

[0, 0] places an element directly in the center of the panel. 

[1, 0] places an element directly so it touches the right edge of the panel. 

[-1, 0] places an element directly so it touches the left edge of the panel. 

[0, 1] places an element directly so it touches the bottom edge of the panel.

[0, -1] places an element directly to it touches the top edge of the panel. 

And so on. 

Use `2` or `-2` as a value to put the element entirely out-of-bounds on a particular edge. This can be used to animate an element showing or hiding itself from any particular side. 

Animate from 1 to -1 to make an element switch alignment in an animated fashion. 

The values scale reasonably based on the panel size, but presumes that the child element will always be smaller than the panel - be sure to constrain your child element sizes!

## License

License: MIT - Do what you want with it, I'm not liable for anything, ever.

## Usage

I recommend copying the entirety of VibePanel.cs and just putting it into your project, adjusting namespaces as necessary. 