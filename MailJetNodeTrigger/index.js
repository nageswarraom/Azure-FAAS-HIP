module.exports = function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request.');

    if (req.query.name || (req.body && req.body.name)) {
        context.res = {
            // status: 200, /* Defaults to 200 */
            body: "Hello " + (req.query.name || req.body.name)
        };
    }
    else {
        context.res = {
            status: 400,
            body: "Please pass a name on the query string or in the request body"
        };
    }
    //context.done();
    /**
 *
 * This call sends a message to the given recipient with vars and custom vars.
 *
 */
const mailjet = require ('node-mailjet')
	.connect("eba22ee2f4138ff9a46ea1927aa610a0", "f181d09765b200b43b1a07a1377de681")
const request = mailjet
	.post("send", {'version': 'v3.1'})
	.request({
		"Messages":[
			{
				"From": {
					"Email": "naag@hipgroup.co.nz",
					"Name": "naag"
				},
				"To": [
					{
						"Email": "naag@hipgroup.co.nz",
						"Name": "naag"
					}
				],
				"TemplateID": 209327,
				"TemplateLanguage": true,
				"Subject": "Variable test - Template",
				/*"TemplateErrorReporting": {
					"Email": "naag@hipgroup.co.nz",
					"Name": "Air traffic control"
				},
    			"TemplateErrorDeliver": true,*/
				"Variables": {
					"Group": "getKai"
    			}
			}
		]
	})
request
	.then((result) => {
    context.log(result.body);
		//console.log(result.body)
	})
	.catch((err) => {
		context.log(err.statusCode)
	})
      context.done();
};