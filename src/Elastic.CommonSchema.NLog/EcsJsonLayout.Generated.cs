// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

/*
IMPORTANT NOTE
==============
This file has been generated.
If you wish to submit a PR please modify the original csharp file and submit the PR with that change. Thanks!
*/

using NLog.Layouts;

namespace Elastic.CommonSchema
{
	[Layout("ecs-jsonlayout")]
    public class EcsJsonLayout : JsonLayout
    {
        private readonly JsonLayout _jsonLayoutForMessageProperties;

        public EcsJsonLayout()
        {
            SuppressSpaces = true;
            RenderEmptyObject = false;
            MaxRecursionLimit = 3;

			Attributes.Add(new JsonAttribute("@timestamp", "${date}", true));
			Attributes.Add(new JsonAttribute("tags", "", true));
			Attributes.Add(new JsonAttribute("labels", "", true));
			Attributes.Add(new JsonAttribute("message", "${message}", true));
			Attributes.Add(new JsonAttribute("agent", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("version", "", true),
					new JsonAttribute("name", "", true),
					new JsonAttribute("type", "", true),
					new JsonAttribute("id", "", true),
					new JsonAttribute("ephemeral_id", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("as", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("number", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("client", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("address", "", true),
					new JsonAttribute("ip", "", true),
					new JsonAttribute("port", "", true),
					new JsonAttribute("mac", "", true),
					new JsonAttribute("domain", "", true),
					new JsonAttribute("registered_domain", "", true),
					new JsonAttribute("top_level_domain", "", true),
					new JsonAttribute("bytes", "", true),
					new JsonAttribute("packets", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("cloud", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("provider", "", true),
					new JsonAttribute("availability_zone", "", true),
					new JsonAttribute("region", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("container", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("runtime", "", true),
					new JsonAttribute("id", "", true),
					new JsonAttribute("name", "", true),
					new JsonAttribute("labels", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("destination", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("address", "", true),
					new JsonAttribute("ip", "", true),
					new JsonAttribute("port", "", true),
					new JsonAttribute("mac", "", true),
					new JsonAttribute("domain", "", true),
					new JsonAttribute("registered_domain", "", true),
					new JsonAttribute("top_level_domain", "", true),
					new JsonAttribute("bytes", "", true),
					new JsonAttribute("packets", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("dns", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("type", "", true),
					new JsonAttribute("id", "", true),
					new JsonAttribute("op_code", "", true),
					new JsonAttribute("header_flags", "", true),
					new JsonAttribute("response_code", "", true),
					new JsonAttribute("resolved_ip", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("ecs", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("version", "1.4.0", true),
				}
			}));
			Attributes.Add(new JsonAttribute("error", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("id", "", true),
					new JsonAttribute("message", "", true),
					new JsonAttribute("code", "", true),
					new JsonAttribute("type", "", true),
					new JsonAttribute("stack_trace", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("event", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("id", "", true),
					new JsonAttribute("code", "", true),
					new JsonAttribute("kind", "", true),
					new JsonAttribute("category", "", true),
					new JsonAttribute("action", "", true),
					new JsonAttribute("outcome", "", true),
					new JsonAttribute("type", "", true),
					new JsonAttribute("module", "", true),
					new JsonAttribute("dataset", "", true),
					new JsonAttribute("provider", "", true),
					new JsonAttribute("severity", "", true),
					new JsonAttribute("original", "", true),
					new JsonAttribute("hash", "", true),
					new JsonAttribute("duration", "", true),
					new JsonAttribute("sequence", "", true),
					new JsonAttribute("timezone", "", true),
					new JsonAttribute("created", "", true),
					new JsonAttribute("start", "", true),
					new JsonAttribute("end", "", true),
					new JsonAttribute("risk_score", "", true),
					new JsonAttribute("risk_score_norm", "", true),
					new JsonAttribute("ingested", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("file", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("name", "", true),
					new JsonAttribute("attributes", "", true),
					new JsonAttribute("directory", "", true),
					new JsonAttribute("drive_letter", "", true),
					new JsonAttribute("path", "", true),
					new JsonAttribute("target_path", "", true),
					new JsonAttribute("extension", "", true),
					new JsonAttribute("type", "", true),
					new JsonAttribute("device", "", true),
					new JsonAttribute("inode", "", true),
					new JsonAttribute("uid", "", true),
					new JsonAttribute("owner", "", true),
					new JsonAttribute("gid", "", true),
					new JsonAttribute("group", "", true),
					new JsonAttribute("mode", "", true),
					new JsonAttribute("size", "", true),
					new JsonAttribute("mtime", "", true),
					new JsonAttribute("ctime", "", true),
					new JsonAttribute("created", "", true),
					new JsonAttribute("accessed", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("geo", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("location", "", true),
					new JsonAttribute("continent_name", "", true),
					new JsonAttribute("country_name", "", true),
					new JsonAttribute("region_name", "", true),
					new JsonAttribute("city_name", "", true),
					new JsonAttribute("country_iso_code", "", true),
					new JsonAttribute("region_iso_code", "", true),
					new JsonAttribute("name", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("group", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("id", "", true),
					new JsonAttribute("name", "", true),
					new JsonAttribute("domain", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("hash", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("md5", "", true),
					new JsonAttribute("sha1", "", true),
					new JsonAttribute("sha256", "", true),
					new JsonAttribute("sha512", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("host", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("hostname", "", true),
					new JsonAttribute("name", "", true),
					new JsonAttribute("id", "", true),
					new JsonAttribute("ip", "", true),
					new JsonAttribute("mac", "", true),
					new JsonAttribute("type", "", true),
					new JsonAttribute("uptime", "", true),
					new JsonAttribute("architecture", "", true),
					new JsonAttribute("domain", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("http", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("version", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("log", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("level", "${level}", true),
					new JsonAttribute("original", "", true),
					new JsonAttribute("logger", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("network", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("name", "", true),
					new JsonAttribute("type", "", true),
					new JsonAttribute("iana_number", "", true),
					new JsonAttribute("transport", "", true),
					new JsonAttribute("application", "", true),
					new JsonAttribute("protocol", "", true),
					new JsonAttribute("direction", "", true),
					new JsonAttribute("forwarded_ip", "", true),
					new JsonAttribute("community_id", "", true),
					new JsonAttribute("bytes", "", true),
					new JsonAttribute("packets", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("observer", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("mac", "", true),
					new JsonAttribute("ip", "", true),
					new JsonAttribute("hostname", "", true),
					new JsonAttribute("name", "", true),
					new JsonAttribute("product", "", true),
					new JsonAttribute("vendor", "", true),
					new JsonAttribute("version", "", true),
					new JsonAttribute("serial_number", "", true),
					new JsonAttribute("type", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("organization", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("name", "", true),
					new JsonAttribute("id", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("os", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("platform", "", true),
					new JsonAttribute("name", "", true),
					new JsonAttribute("full", "", true),
					new JsonAttribute("family", "", true),
					new JsonAttribute("version", "", true),
					new JsonAttribute("kernel", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("package", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("name", "", true),
					new JsonAttribute("version", "", true),
					new JsonAttribute("build_version", "", true),
					new JsonAttribute("description", "", true),
					new JsonAttribute("size", "", true),
					new JsonAttribute("installed", "", true),
					new JsonAttribute("path", "", true),
					new JsonAttribute("architecture", "", true),
					new JsonAttribute("checksum", "", true),
					new JsonAttribute("install_scope", "", true),
					new JsonAttribute("license", "", true),
					new JsonAttribute("reference", "", true),
					new JsonAttribute("type", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("process", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("pid", "", true),
					new JsonAttribute("name", "", true),
					new JsonAttribute("ppid", "", true),
					new JsonAttribute("pgid", "", true),
					new JsonAttribute("command_line", "", true),
					new JsonAttribute("args", "", true),
					new JsonAttribute("args_count", "", true),
					new JsonAttribute("executable", "", true),
					new JsonAttribute("title", "", true),
					new JsonAttribute("start", "", true),
					new JsonAttribute("uptime", "", true),
					new JsonAttribute("working_directory", "", true),
					new JsonAttribute("exit_code", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("registry", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("hive", "", true),
					new JsonAttribute("key", "", true),
					new JsonAttribute("value", "", true),
					new JsonAttribute("path", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("related", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("ip", "", true),
					new JsonAttribute("user", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("rule", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("id", "", true),
					new JsonAttribute("uuid", "", true),
					new JsonAttribute("version", "", true),
					new JsonAttribute("name", "", true),
					new JsonAttribute("description", "", true),
					new JsonAttribute("category", "", true),
					new JsonAttribute("ruleset", "", true),
					new JsonAttribute("reference", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("server", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("address", "", true),
					new JsonAttribute("ip", "", true),
					new JsonAttribute("port", "", true),
					new JsonAttribute("mac", "", true),
					new JsonAttribute("domain", "", true),
					new JsonAttribute("registered_domain", "", true),
					new JsonAttribute("top_level_domain", "", true),
					new JsonAttribute("bytes", "", true),
					new JsonAttribute("packets", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("service", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("id", "", true),
					new JsonAttribute("name", "", true),
					new JsonAttribute("type", "", true),
					new JsonAttribute("state", "", true),
					new JsonAttribute("version", "", true),
					new JsonAttribute("ephemeral_id", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("source", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("address", "", true),
					new JsonAttribute("ip", "", true),
					new JsonAttribute("port", "", true),
					new JsonAttribute("mac", "", true),
					new JsonAttribute("domain", "", true),
					new JsonAttribute("registered_domain", "", true),
					new JsonAttribute("top_level_domain", "", true),
					new JsonAttribute("bytes", "", true),
					new JsonAttribute("packets", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("threat", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("framework", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("tls", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("version", "", true),
					new JsonAttribute("version_protocol", "", true),
					new JsonAttribute("cipher", "", true),
					new JsonAttribute("curve", "", true),
					new JsonAttribute("resumed", "", true),
					new JsonAttribute("established", "", true),
					new JsonAttribute("next_protocol", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("url", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("original", "", true),
					new JsonAttribute("full", "", true),
					new JsonAttribute("scheme", "", true),
					new JsonAttribute("domain", "", true),
					new JsonAttribute("registered_domain", "", true),
					new JsonAttribute("top_level_domain", "", true),
					new JsonAttribute("port", "", true),
					new JsonAttribute("path", "", true),
					new JsonAttribute("query", "", true),
					new JsonAttribute("extension", "", true),
					new JsonAttribute("fragment", "", true),
					new JsonAttribute("username", "", true),
					new JsonAttribute("password", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("user", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("id", "", true),
					new JsonAttribute("name", "", true),
					new JsonAttribute("full_name", "", true),
					new JsonAttribute("email", "", true),
					new JsonAttribute("hash", "", true),
					new JsonAttribute("domain", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("user_agent", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("original", "", true),
					new JsonAttribute("name", "", true),
					new JsonAttribute("version", "", true),
				}
			}));
			Attributes.Add(new JsonAttribute("vulnerability", new JsonLayout
			{
				Attributes =
				{
					new JsonAttribute("classification", "", true),
					new JsonAttribute("enumeration", "", true),
					new JsonAttribute("reference", "", true),
					new JsonAttribute("category", "", true),
					new JsonAttribute("description", "", true),
					new JsonAttribute("id", "", true),
					new JsonAttribute("severity", "", true),
					new JsonAttribute("report_id", "", true),
				}
			}));

            // Nesting json objects like this works fine and will lead to message properties
            // that look like message.property.ErrorMessage in the UI.

            _jsonLayoutForMessageProperties = new JsonLayout()
            {
                IncludeAllProperties = true,
                IncludeMdc = false,
                //IncludeGdc = false, // GDC not supported in NLog 4.5
                IncludeMdlc = false,
                RenderEmptyObject = false,
                SuppressSpaces = true,
                MaxRecursionLimit = 1,
                ExcludeProperties = ExcludeProperties
            };

            Attributes.Add(new JsonAttribute("Message Properties", _jsonLayoutForMessageProperties, false));
        }

        //This prevents changing the properties that we don't want changed
        protected override void InitializeLayout()
        {
            // This reads XML configuration
            base.InitializeLayout();

            // At this point, the value of MaxRecursionLimit in this instance is either
            // what we initialized it to be in the constructor, or a value supplied by the user.  Either way,
            // we should set the value of MaxRecursionLimit on the message properties sub-layout to be the same.
            _jsonLayoutForMessageProperties.MaxRecursionLimit = MaxRecursionLimit;

            // Now we set things to how we want them configured finally

            // By not overriding the attributes collection here customers can add additional attributes
            // to the data, in a similar manner to how they would have added data via custom layout strings.
            // By default we will only support the data directly related to structured logging.
            // Note that any message properties will also be present in the Gdc, Mdc, and Mdlc contexts.
            IncludeAllProperties = false;
            //IncludeGdc = false; // GDC not supported in NLog 4.5
            IncludeMdc = false;
            IncludeMdlc = false;
            RenderEmptyObject = false;
            SuppressSpaces = true;
        }
    }
}
