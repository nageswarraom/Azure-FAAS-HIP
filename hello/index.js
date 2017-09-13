'use strict';

/* eslint-disable no-param-reassign */

module.exports.hello = function (context) {
  context.log('JavaScript HTTP trigger function processed a request.');
var msg = {foo: "test", bar: " successfull"};
  context.bindings.outputQueueItem2 = msg;
  context.res = {
    // status: 200, /* Defaults to 200 */
    body: 'Go Serverless v1.x! Your function executed successfully!',
  };
  context.done();
};
