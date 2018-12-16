/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

async function run() {
    console.log(Office.context);
    var mailbox = Office.context.mailbox;
    var email = mailbox.userProfile.emailAddress;
    var item = mailbox.item;
    $('#run').click(run);
    console.log("Index.js loaded");
}