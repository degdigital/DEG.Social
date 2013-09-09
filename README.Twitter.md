DEG.Shared.Twitter
==================

This module provides a simple integration with the [Twitter REST API 1.1](https://dev.twitter.com/docs/api/1.1)

# Features

1. Retrieve User Timeline
2. Search tweets by User Mention
3. Search tweets by Hashtag

Yup, that's it for now. This module does very little, but it tries to do it very well.

# Motivation

This module was developed out of necessity. We had a need to retrieve a user's timeline, and with Twitter disabling the 1.0 version of their API, most of the libraries we examined were being abandoned by their developers.

We didn't want to be tied to a library that was going to disappear soon, or become unsupportable. That is why we decided to write our own!

These are the primary goals for this project:
1. Simplicity
  * The library should be easy to use, and the API should be intuitive.
2. Stability
  * As with all software, it will fail sometimes. When it does, the cause should be known, and the remedy should be clear.
3. Readability
  * The code should be clean and well organized, so that others can enjoy it.

With that in mind, it only does exactly what we need it to, and no more. If you need it to do more, then please feel free to contribute! We will be actively monitoring, reviewing and merging pull requests.

# Authentication

This module currently supports [Application only authentication](https://dev.twitter.com/docs/auth/application-only-auth).

Basically, this means API activities are done as a [Twitter Application](https://dev.twitter.com/apps), and not as an individual.

We will be adding other authentication support as needed in the future.
