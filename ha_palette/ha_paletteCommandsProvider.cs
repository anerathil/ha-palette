// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace HaPalette;

public partial class HaPaletteCommandsProvider : CommandProvider
{
    private readonly ICommandItem[] _commands;

    public HaPaletteCommandsProvider()
    {
        DisplayName = "HA Palette";
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        _commands = [
            new CommandItem(new HaPalettePage()) { Title = DisplayName },
        ];
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }

    public override ICommandItem[]? GetDockBands()
    {
        var item = new ListItem(new NoOpCommand())
        {
            Title = "HA",
            Subtitle = "21.5 °C"
        };

        var band = new WrappedDockItem(
            [item],
            "com.anerathil.hapalette.status",
            "Home Assistant"
        );

        return [band];
    }

}
