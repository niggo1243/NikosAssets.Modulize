## About

Sometimes you want or rather need your components to always execute in the right order within the Unity function execution order (Awake, Start, Update, etc.).
This package offers a solution where you can create and order your own modules (MonoBehaviours).

Checkout the [Features](#features) section below for more information about the specific use cases and available helper scripts.

### Requirements

You need to understand the concepts of inheritance and generics in C# to use this package.

## Support

Since I am developing and maintaining this asset package in my spare time, feel free to support me [via paypal](https://paypal.me/NikosProjects), [buy me a coffee](https://ko-fi.com/nikocreatestech) or check out my [games](https://store.steampowered.com/curator/44541812) or other [published assets](https://assetstore.unity.com/publishers/52812).

## Documentation

See the API doc [TBA]

## Setup

### Unity Package Dependency

To add this toolkit as a package dependency to your Unity project, locate your manifest file in "Package/manifest.json" or add the git-url via the package manager UI.

In the previous versions of this package you had to add the NaughtyAttributes package dependency to the "scopedRegistries". Unfortunately this forced you to use a specific fork or version, so to avoid that restriction you have to add the NaughtyAttributes git url (fork/ version) of your liking yourself.

The current dependency is a fork with performance improvements ([https://github.com/niggo1243/NaughtyAttributes](https://github.com/niggo1243/NaughtyAttributes)) of the original open-source project NaughtyAttributes by dbrizov: [https://github.com/dbrizov/NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes)

The original NaughtyAttributes package works as well though and if you already have it installed, you don't have to add the forked branch in the following steps!

Add the following lines to the "dependencies" section to include this package and my helpers package dependency (scopedRegistries automatic dependency resolve setup is in progress!):
```
"com.nikosassets.helpers": "https://github.com/niggo1243/Unity3DHelperTools.git#upm"
"com.nikosassets.modulize": "TBA"
```

For my NaughtyAttributes performance improvements fork:
```
"com.nikosassets.naughtyattributes": "https://github.com/niggo1243/NaughtyAttributes.git#upm"
```

The original branch:
```
"com.dbrizov.naughtyattributes": "https://github.com/dbrizov/NaughtyAttributes.git#upm"
```

You can also choose specific releases and tags after the "#" instead of "upm".

## Features

In depth sample scenes & feature showcase with pictures/ gifs [TBA].

In short:

Inherit from the ```BaseCompositeExecutor<TBaseModule>``` with your specified module type to use it as your ordered MonoBehaviour executor, where you place ```TBaseModule``` in the respective X-Update list.
The ```TBaseModule``` is your custom MonoBehaviour you want executed in a specific and reliable order between/ before/ after your other ```TBaseModule``` MonoBehaviours.

