# HAPalette

Home Assistant integration for the Microsoft PowerToys Command Palette and Dock.

HAPalette connects to Home Assistant and exposes selected entities as live-updating items in the PowerToys Command Palette Dock.

## Goals

- Display Home Assistant entity states directly in the PowerToys Dock
- Receive live state updates through the Home Assistant WebSocket API
- Support configurable Home Assistant entities
- Reconnect automatically after Home Assistant or network interruptions
- Keep Home Assistant credentials out of source control
- Provide Command Palette actions for selected Home Assistant entities

## Planned architecture

```text
PowerToys Command Palette
        │
        ▼
HAPalette Extension
        │
        ├── Dock Items
        │
        ├── Entity State Store
        │
        └── Home Assistant WebSocket Client
                        │
                        ▼
                Home Assistant
                /api/websocket
```

The extension uses a persistent WebSocket connection to Home Assistant.

On startup it will:

1. Connect to Home Assistant
2. Authenticate
3. Retrieve the initial entity states
4. Subscribe to configured entities
5. Update Dock items whenever an entity changes
6. Reconnect and resubscribe after connection loss

## Example

A Dock configuration could display information such as:

```text
[ Living 21.4 °C ] [ Solar 3.2 kW ] [ Battery 78% ]
```

Potential entity types include:

- temperature
- humidity
- power consumption
- solar production
- battery state
- doors and windows
- lights
- switches
- presence
- arbitrary Home Assistant sensors

## Development

### Requirements

- Windows 11
- Microsoft PowerToys with Command Palette enabled
- .NET 10 SDK
- Windows App SDK development tooling
- Visual Studio Build Tools or Visual Studio
- Visual Studio Code or Visual Studio
- Home Assistant instance with API access

Verify the installed .NET SDK:

```powershell
dotnet --list-sdks
```

### Restore

```powershell
dotnet restore
```

### Build

```powershell
dotnet build
```

Depending on the Windows App SDK packaging configuration, building and deploying the extension may require MSBuild or Visual Studio deployment tooling.

### Test

```powershell
dotnet test
```

## Home Assistant

Home Assistant exposes its WebSocket API at:

```text
ws://homeassistant.local:8123/api/websocket
```

For HTTPS installations:

```text
wss://homeassistant.example.com/api/websocket
```

Authentication uses a Home Assistant access token.

Credentials must not be committed to the repository.

## Project structure

The intended structure is:

```text
ha-palette/
├── ha_palette/
│   ├── HomeAssistant/
│   │   ├── HomeAssistantClient.cs
│   │   ├── HomeAssistantConnection.cs
│   │   ├── EntityState.cs
│   │   └── EntityStateStore.cs
│   │
│   ├── Dock/
│   │   ├── HomeAssistantDockBand.cs
│   │   └── EntityDockItem.cs
│   │
│   ├── Configuration/
│   │   └── HomeAssistantSettings.cs
│   │
│   └── ...
│
├── Directory.Build.props
├── Directory.Packages.props
├── ha_palette.sln
└── README.md
```

## Status

Early development.

Initial milestones:

- [ ] Build and deploy generated Command Palette extension
- [ ] Display a static Dock item
- [ ] Connect to Home Assistant WebSocket API
- [ ] Authenticate with Home Assistant
- [ ] Load initial entity states
- [ ] Subscribe to entity state changes
- [ ] Display live entity values in the Dock
- [ ] Implement reconnect and resubscribe behavior
- [ ] Add configuration
- [ ] Store credentials securely

## License

TBD