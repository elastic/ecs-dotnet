// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

/*
IMPORTANT NOTE
==============
This file has been generated. 
If you wish to submit a PR please modify the original csharp file and submit the PR with that change. Thanks!
*/

// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;

namespace Elastic.CommonSchema.Elasticsearch
{
	/// <summary>
	/// Elastic Common Schema version v8.3.1 index templates to be used with Elasticsearch.
	/// </summary>
	public static class IndexComponents
	{
		/// <summary>
		/// Elastic Common Schema version v8.3.1 AgentJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string AgentJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-agent.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""agent"": {
          ""properties"": {
            ""build"": {
              ""properties"": {
                ""original"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""ephemeral_id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""version"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 BaseJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string BaseJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-base.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""@timestamp"": {
          ""type"": ""date""
        },
        ""labels"": {
          ""type"": ""object""
        },
        ""message"": {
          ""type"": ""match_only_text""
        },
        ""tags"": {
          ""ignore_above"": 1024,
          ""type"": ""keyword""
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 ClientJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string ClientJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-client.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""client"": {
          ""properties"": {
            ""address"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""as"": {
              ""properties"": {
                ""number"": {
                  ""type"": ""long""
                },
                ""organization"": {
                  ""properties"": {
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                }
              }
            },
            ""bytes"": {
              ""type"": ""long""
            },
            ""domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""geo"": {
              ""properties"": {
                ""city_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""continent_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""continent_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""country_iso_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""country_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""location"": {
                  ""type"": ""geo_point""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""postal_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region_iso_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""timezone"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""ip"": {
              ""type"": ""ip""
            },
            ""mac"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""nat"": {
              ""properties"": {
                ""ip"": {
                  ""type"": ""ip""
                },
                ""port"": {
                  ""type"": ""long""
                }
              }
            },
            ""packets"": {
              ""type"": ""long""
            },
            ""port"": {
              ""type"": ""long""
            },
            ""registered_domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""subdomain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""top_level_domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""user"": {
              ""properties"": {
                ""domain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""email"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""full_name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""group"": {
                  ""properties"": {
                    ""domain"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""hash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""roles"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 CloudJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string CloudJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-cloud.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""cloud"": {
          ""properties"": {
            ""account"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""availability_zone"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""instance"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""machine"": {
              ""properties"": {
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""origin"": {
              ""properties"": {
                ""account"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""availability_zone"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""instance"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""machine"": {
                  ""properties"": {
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""project"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""provider"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""service"": {
                  ""properties"": {
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                }
              }
            },
            ""project"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""provider"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""region"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""service"": {
              ""properties"": {
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""target"": {
              ""properties"": {
                ""account"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""availability_zone"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""instance"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""machine"": {
                  ""properties"": {
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""project"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""provider"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""service"": {
                  ""properties"": {
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 ContainerJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string ContainerJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-container.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""container"": {
          ""properties"": {
            ""cpu"": {
              ""properties"": {
                ""usage"": {
                  ""scaling_factor"": 1000,
                  ""type"": ""scaled_float""
                }
              }
            },
            ""disk"": {
              ""properties"": {
                ""read"": {
                  ""properties"": {
                    ""bytes"": {
                      ""type"": ""long""
                    }
                  }
                },
                ""write"": {
                  ""properties"": {
                    ""bytes"": {
                      ""type"": ""long""
                    }
                  }
                }
              }
            },
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""image"": {
              ""properties"": {
                ""hash"": {
                  ""properties"": {
                    ""all"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""tag"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""labels"": {
              ""type"": ""object""
            },
            ""memory"": {
              ""properties"": {
                ""usage"": {
                  ""scaling_factor"": 1000,
                  ""type"": ""scaled_float""
                }
              }
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""network"": {
              ""properties"": {
                ""egress"": {
                  ""properties"": {
                    ""bytes"": {
                      ""type"": ""long""
                    }
                  }
                },
                ""ingress"": {
                  ""properties"": {
                    ""bytes"": {
                      ""type"": ""long""
                    }
                  }
                }
              }
            },
            ""runtime"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 DataStreamJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string DataStreamJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-data_stream.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""data_stream"": {
          ""properties"": {
            ""dataset"": {
              ""type"": ""constant_keyword""
            },
            ""namespace"": {
              ""type"": ""constant_keyword""
            },
            ""type"": {
              ""type"": ""constant_keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 DestinationJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string DestinationJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-destination.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""destination"": {
          ""properties"": {
            ""address"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""as"": {
              ""properties"": {
                ""number"": {
                  ""type"": ""long""
                },
                ""organization"": {
                  ""properties"": {
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                }
              }
            },
            ""bytes"": {
              ""type"": ""long""
            },
            ""domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""geo"": {
              ""properties"": {
                ""city_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""continent_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""continent_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""country_iso_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""country_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""location"": {
                  ""type"": ""geo_point""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""postal_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region_iso_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""timezone"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""ip"": {
              ""type"": ""ip""
            },
            ""mac"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""nat"": {
              ""properties"": {
                ""ip"": {
                  ""type"": ""ip""
                },
                ""port"": {
                  ""type"": ""long""
                }
              }
            },
            ""packets"": {
              ""type"": ""long""
            },
            ""port"": {
              ""type"": ""long""
            },
            ""registered_domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""subdomain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""top_level_domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""user"": {
              ""properties"": {
                ""domain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""email"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""full_name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""group"": {
                  ""properties"": {
                    ""domain"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""hash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""roles"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 DllJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string DllJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-dll.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""dll"": {
          ""properties"": {
            ""code_signature"": {
              ""properties"": {
                ""digest_algorithm"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""exists"": {
                  ""type"": ""boolean""
                },
                ""signing_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""status"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""subject_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""team_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""timestamp"": {
                  ""type"": ""date""
                },
                ""trusted"": {
                  ""type"": ""boolean""
                },
                ""valid"": {
                  ""type"": ""boolean""
                }
              }
            },
            ""hash"": {
              ""properties"": {
                ""md5"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""sha1"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""sha256"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""sha384"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""sha512"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""ssdeep"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""tlsh"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""path"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""pe"": {
              ""properties"": {
                ""architecture"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""company"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""description"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""file_version"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""imphash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""original_file_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""pehash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""product"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 DnsJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string DnsJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-dns.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""dns"": {
          ""properties"": {
            ""answers"": {
              ""properties"": {
                ""class"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""data"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""ttl"": {
                  ""type"": ""long""
                },
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              },
              ""type"": ""object""
            },
            ""header_flags"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""op_code"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""question"": {
              ""properties"": {
                ""class"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""registered_domain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""subdomain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""top_level_domain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""resolved_ip"": {
              ""type"": ""ip""
            },
            ""response_code"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 EcsJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string EcsJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-ecs.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""ecs"": {
          ""properties"": {
            ""version"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 EmailJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string EmailJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-email.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""email"": {
          ""properties"": {
            ""attachments"": {
              ""properties"": {
                ""file"": {
                  ""properties"": {
                    ""extension"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""hash"": {
                      ""properties"": {
                        ""md5"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""sha1"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""sha256"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""sha384"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""sha512"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""ssdeep"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""tlsh"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""mime_type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""size"": {
                      ""type"": ""long""
                    }
                  }
                }
              },
              ""type"": ""nested""
            },
            ""bcc"": {
              ""properties"": {
                ""address"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""cc"": {
              ""properties"": {
                ""address"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""content_type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""delivery_timestamp"": {
              ""type"": ""date""
            },
            ""direction"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""from"": {
              ""properties"": {
                ""address"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""local_id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""message_id"": {
              ""type"": ""wildcard""
            },
            ""origination_timestamp"": {
              ""type"": ""date""
            },
            ""reply_to"": {
              ""properties"": {
                ""address"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""sender"": {
              ""properties"": {
                ""address"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""subject"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""to"": {
              ""properties"": {
                ""address"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""x_mailer"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 ErrorJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string ErrorJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-error.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""error"": {
          ""properties"": {
            ""code"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""message"": {
              ""type"": ""match_only_text""
            },
            ""stack_trace"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""type"": ""wildcard""
            },
            ""type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 EventJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string EventJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-event.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""event"": {
          ""properties"": {
            ""action"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""agent_id_status"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""category"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""code"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""created"": {
              ""type"": ""date""
            },
            ""dataset"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""duration"": {
              ""type"": ""long""
            },
            ""end"": {
              ""type"": ""date""
            },
            ""hash"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""ingested"": {
              ""type"": ""date""
            },
            ""kind"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""module"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""original"": {
              ""doc_values"": false,
              ""index"": false,
              ""type"": ""keyword""
            },
            ""outcome"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""provider"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""reason"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""reference"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""risk_score"": {
              ""type"": ""float""
            },
            ""risk_score_norm"": {
              ""type"": ""float""
            },
            ""sequence"": {
              ""type"": ""long""
            },
            ""severity"": {
              ""type"": ""long""
            },
            ""start"": {
              ""type"": ""date""
            },
            ""timezone"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""url"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 FaasJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string FaasJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-faas.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""faas"": {
          ""properties"": {
            ""coldstart"": {
              ""type"": ""boolean""
            },
            ""execution"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""trigger"": {
              ""properties"": {
                ""request_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              },
              ""type"": ""nested""
            },
            ""version"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 FileJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string FileJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-file.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""file"": {
          ""properties"": {
            ""accessed"": {
              ""type"": ""date""
            },
            ""attributes"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""code_signature"": {
              ""properties"": {
                ""digest_algorithm"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""exists"": {
                  ""type"": ""boolean""
                },
                ""signing_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""status"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""subject_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""team_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""timestamp"": {
                  ""type"": ""date""
                },
                ""trusted"": {
                  ""type"": ""boolean""
                },
                ""valid"": {
                  ""type"": ""boolean""
                }
              }
            },
            ""created"": {
              ""type"": ""date""
            },
            ""ctime"": {
              ""type"": ""date""
            },
            ""device"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""directory"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""drive_letter"": {
              ""ignore_above"": 1,
              ""type"": ""keyword""
            },
            ""elf"": {
              ""properties"": {
                ""architecture"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""byte_order"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""cpu_type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""creation_date"": {
                  ""type"": ""date""
                },
                ""exports"": {
                  ""type"": ""flattened""
                },
                ""header"": {
                  ""properties"": {
                    ""abi_version"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""class"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""data"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""entrypoint"": {
                      ""type"": ""long""
                    },
                    ""object_version"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""os_abi"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""version"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""imports"": {
                  ""type"": ""flattened""
                },
                ""sections"": {
                  ""properties"": {
                    ""chi2"": {
                      ""type"": ""long""
                    },
                    ""entropy"": {
                      ""type"": ""long""
                    },
                    ""flags"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""physical_offset"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""physical_size"": {
                      ""type"": ""long""
                    },
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""virtual_address"": {
                      ""type"": ""long""
                    },
                    ""virtual_size"": {
                      ""type"": ""long""
                    }
                  },
                  ""type"": ""nested""
                },
                ""segments"": {
                  ""properties"": {
                    ""sections"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  },
                  ""type"": ""nested""
                },
                ""shared_libraries"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""telfhash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""extension"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""fork_name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""gid"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""group"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""hash"": {
              ""properties"": {
                ""md5"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""sha1"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""sha256"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""sha384"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""sha512"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""ssdeep"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""tlsh"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""inode"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""mime_type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""mode"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""mtime"": {
              ""type"": ""date""
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""owner"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""path"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""pe"": {
              ""properties"": {
                ""architecture"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""company"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""description"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""file_version"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""imphash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""original_file_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""pehash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""product"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""size"": {
              ""type"": ""long""
            },
            ""target_path"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""uid"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""x509"": {
              ""properties"": {
                ""alternative_names"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""issuer"": {
                  ""properties"": {
                    ""common_name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""country"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""distinguished_name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""locality"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""organization"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""organizational_unit"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""state_or_province"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""not_after"": {
                  ""type"": ""date""
                },
                ""not_before"": {
                  ""type"": ""date""
                },
                ""public_key_algorithm"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""public_key_curve"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""public_key_exponent"": {
                  ""doc_values"": false,
                  ""index"": false,
                  ""type"": ""long""
                },
                ""public_key_size"": {
                  ""type"": ""long""
                },
                ""serial_number"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""signature_algorithm"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""subject"": {
                  ""properties"": {
                    ""common_name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""country"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""distinguished_name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""locality"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""organization"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""organizational_unit"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""state_or_province"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""version_number"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 GroupJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string GroupJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-group.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""group"": {
          ""properties"": {
            ""domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 HostJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string HostJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-host.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""host"": {
          ""properties"": {
            ""architecture"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""boot"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""cpu"": {
              ""properties"": {
                ""usage"": {
                  ""scaling_factor"": 1000,
                  ""type"": ""scaled_float""
                }
              }
            },
            ""disk"": {
              ""properties"": {
                ""read"": {
                  ""properties"": {
                    ""bytes"": {
                      ""type"": ""long""
                    }
                  }
                },
                ""write"": {
                  ""properties"": {
                    ""bytes"": {
                      ""type"": ""long""
                    }
                  }
                }
              }
            },
            ""domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""geo"": {
              ""properties"": {
                ""city_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""continent_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""continent_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""country_iso_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""country_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""location"": {
                  ""type"": ""geo_point""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""postal_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region_iso_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""timezone"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""hostname"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""ip"": {
              ""type"": ""ip""
            },
            ""mac"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""network"": {
              ""properties"": {
                ""egress"": {
                  ""properties"": {
                    ""bytes"": {
                      ""type"": ""long""
                    },
                    ""packets"": {
                      ""type"": ""long""
                    }
                  }
                },
                ""ingress"": {
                  ""properties"": {
                    ""bytes"": {
                      ""type"": ""long""
                    },
                    ""packets"": {
                      ""type"": ""long""
                    }
                  }
                }
              }
            },
            ""os"": {
              ""properties"": {
                ""family"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""full"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""kernel"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""platform"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""version"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""pid_ns_ino"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""uptime"": {
              ""type"": ""long""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 HttpJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string HttpJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-http.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""http"": {
          ""properties"": {
            ""request"": {
              ""properties"": {
                ""body"": {
                  ""properties"": {
                    ""bytes"": {
                      ""type"": ""long""
                    },
                    ""content"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""type"": ""wildcard""
                    }
                  }
                },
                ""bytes"": {
                  ""type"": ""long""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""method"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""mime_type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""referrer"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""response"": {
              ""properties"": {
                ""body"": {
                  ""properties"": {
                    ""bytes"": {
                      ""type"": ""long""
                    },
                    ""content"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""type"": ""wildcard""
                    }
                  }
                },
                ""bytes"": {
                  ""type"": ""long""
                },
                ""mime_type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""status_code"": {
                  ""type"": ""long""
                }
              }
            },
            ""version"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 LogJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string LogJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-log.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""log"": {
          ""properties"": {
            ""file"": {
              ""properties"": {
                ""path"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""level"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""logger"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""origin"": {
              ""properties"": {
                ""file"": {
                  ""properties"": {
                    ""line"": {
                      ""type"": ""long""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""function"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""syslog"": {
              ""properties"": {
                ""appname"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""facility"": {
                  ""properties"": {
                    ""code"": {
                      ""type"": ""long""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""hostname"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""msgid"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""priority"": {
                  ""type"": ""long""
                },
                ""procid"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""severity"": {
                  ""properties"": {
                    ""code"": {
                      ""type"": ""long""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""structured_data"": {
                  ""type"": ""flattened""
                },
                ""version"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              },
              ""type"": ""object""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 NetworkJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string NetworkJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-network.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""network"": {
          ""properties"": {
            ""application"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""bytes"": {
              ""type"": ""long""
            },
            ""community_id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""direction"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""forwarded_ip"": {
              ""type"": ""ip""
            },
            ""iana_number"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""inner"": {
              ""properties"": {
                ""vlan"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                }
              },
              ""type"": ""object""
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""packets"": {
              ""type"": ""long""
            },
            ""protocol"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""transport"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""vlan"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 ObserverJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string ObserverJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-observer.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""observer"": {
          ""properties"": {
            ""egress"": {
              ""properties"": {
                ""interface"": {
                  ""properties"": {
                    ""alias"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""vlan"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""zone"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              },
              ""type"": ""object""
            },
            ""geo"": {
              ""properties"": {
                ""city_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""continent_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""continent_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""country_iso_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""country_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""location"": {
                  ""type"": ""geo_point""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""postal_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region_iso_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""timezone"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""hostname"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""ingress"": {
              ""properties"": {
                ""interface"": {
                  ""properties"": {
                    ""alias"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""vlan"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""zone"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              },
              ""type"": ""object""
            },
            ""ip"": {
              ""type"": ""ip""
            },
            ""mac"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""os"": {
              ""properties"": {
                ""family"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""full"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""kernel"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""platform"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""version"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""product"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""serial_number"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""vendor"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""version"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 OrchestratorJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string OrchestratorJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-orchestrator.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""orchestrator"": {
          ""properties"": {
            ""api_version"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""cluster"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""url"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""version"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""namespace"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""organization"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""resource"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""ip"": {
                  ""type"": ""ip""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""parent"": {
                  ""properties"": {
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 OrganizationJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string OrganizationJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-organization.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""organization"": {
          ""properties"": {
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""name"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 PackageJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string PackageJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-package.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""package"": {
          ""properties"": {
            ""architecture"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""build_version"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""checksum"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""description"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""install_scope"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""installed"": {
              ""type"": ""date""
            },
            ""license"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""path"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""reference"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""size"": {
              ""type"": ""long""
            },
            ""type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""version"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 ProcessJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string ProcessJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-process.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""process"": {
          ""properties"": {
            ""args"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""args_count"": {
              ""type"": ""long""
            },
            ""code_signature"": {
              ""properties"": {
                ""digest_algorithm"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""exists"": {
                  ""type"": ""boolean""
                },
                ""signing_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""status"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""subject_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""team_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""timestamp"": {
                  ""type"": ""date""
                },
                ""trusted"": {
                  ""type"": ""boolean""
                },
                ""valid"": {
                  ""type"": ""boolean""
                }
              }
            },
            ""command_line"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""type"": ""wildcard""
            },
            ""elf"": {
              ""properties"": {
                ""architecture"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""byte_order"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""cpu_type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""creation_date"": {
                  ""type"": ""date""
                },
                ""exports"": {
                  ""type"": ""flattened""
                },
                ""header"": {
                  ""properties"": {
                    ""abi_version"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""class"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""data"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""entrypoint"": {
                      ""type"": ""long""
                    },
                    ""object_version"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""os_abi"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""version"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""imports"": {
                  ""type"": ""flattened""
                },
                ""sections"": {
                  ""properties"": {
                    ""chi2"": {
                      ""type"": ""long""
                    },
                    ""entropy"": {
                      ""type"": ""long""
                    },
                    ""flags"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""physical_offset"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""physical_size"": {
                      ""type"": ""long""
                    },
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""virtual_address"": {
                      ""type"": ""long""
                    },
                    ""virtual_size"": {
                      ""type"": ""long""
                    }
                  },
                  ""type"": ""nested""
                },
                ""segments"": {
                  ""properties"": {
                    ""sections"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  },
                  ""type"": ""nested""
                },
                ""shared_libraries"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""telfhash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""end"": {
              ""type"": ""date""
            },
            ""entity_id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""entry_leader"": {
              ""properties"": {
                ""args"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""args_count"": {
                  ""type"": ""long""
                },
                ""command_line"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""type"": ""wildcard""
                },
                ""entity_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""entry_meta"": {
                  ""properties"": {
                    ""source"": {
                      ""properties"": {
                        ""ip"": {
                          ""type"": ""ip""
                        }
                      }
                    },
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""executable"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""group"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""interactive"": {
                  ""type"": ""boolean""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""parent"": {
                  ""properties"": {
                    ""entity_id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""pid"": {
                      ""type"": ""long""
                    },
                    ""session_leader"": {
                      ""properties"": {
                        ""entity_id"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""pid"": {
                          ""type"": ""long""
                        },
                        ""start"": {
                          ""type"": ""date""
                        }
                      }
                    },
                    ""start"": {
                      ""type"": ""date""
                    }
                  }
                },
                ""pid"": {
                  ""type"": ""long""
                },
                ""real_group"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""real_user"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""same_as_process"": {
                  ""type"": ""boolean""
                },
                ""saved_group"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""saved_user"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""start"": {
                  ""type"": ""date""
                },
                ""supplemental_groups"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""tty"": {
                  ""properties"": {
                    ""char_device"": {
                      ""properties"": {
                        ""major"": {
                          ""type"": ""long""
                        },
                        ""minor"": {
                          ""type"": ""long""
                        }
                      }
                    }
                  },
                  ""type"": ""object""
                },
                ""user"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""working_directory"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""env_vars"": {
              ""type"": ""object""
            },
            ""executable"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""exit_code"": {
              ""type"": ""long""
            },
            ""group_leader"": {
              ""properties"": {
                ""args"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""args_count"": {
                  ""type"": ""long""
                },
                ""command_line"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""type"": ""wildcard""
                },
                ""entity_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""executable"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""group"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""interactive"": {
                  ""type"": ""boolean""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""pid"": {
                  ""type"": ""long""
                },
                ""real_group"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""real_user"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""same_as_process"": {
                  ""type"": ""boolean""
                },
                ""saved_group"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""saved_user"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""start"": {
                  ""type"": ""date""
                },
                ""supplemental_groups"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""tty"": {
                  ""properties"": {
                    ""char_device"": {
                      ""properties"": {
                        ""major"": {
                          ""type"": ""long""
                        },
                        ""minor"": {
                          ""type"": ""long""
                        }
                      }
                    }
                  },
                  ""type"": ""object""
                },
                ""user"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""working_directory"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""hash"": {
              ""properties"": {
                ""md5"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""sha1"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""sha256"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""sha384"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""sha512"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""ssdeep"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""tlsh"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""interactive"": {
              ""type"": ""boolean""
            },
            ""name"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""parent"": {
              ""properties"": {
                ""args"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""args_count"": {
                  ""type"": ""long""
                },
                ""code_signature"": {
                  ""properties"": {
                    ""digest_algorithm"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""exists"": {
                      ""type"": ""boolean""
                    },
                    ""signing_id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""status"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""subject_name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""team_id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""timestamp"": {
                      ""type"": ""date""
                    },
                    ""trusted"": {
                      ""type"": ""boolean""
                    },
                    ""valid"": {
                      ""type"": ""boolean""
                    }
                  }
                },
                ""command_line"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""type"": ""wildcard""
                },
                ""elf"": {
                  ""properties"": {
                    ""architecture"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""byte_order"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""cpu_type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""creation_date"": {
                      ""type"": ""date""
                    },
                    ""exports"": {
                      ""type"": ""flattened""
                    },
                    ""header"": {
                      ""properties"": {
                        ""abi_version"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""class"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""data"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""entrypoint"": {
                          ""type"": ""long""
                        },
                        ""object_version"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""os_abi"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""type"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""version"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""imports"": {
                      ""type"": ""flattened""
                    },
                    ""sections"": {
                      ""properties"": {
                        ""chi2"": {
                          ""type"": ""long""
                        },
                        ""entropy"": {
                          ""type"": ""long""
                        },
                        ""flags"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""physical_offset"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""physical_size"": {
                          ""type"": ""long""
                        },
                        ""type"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""virtual_address"": {
                          ""type"": ""long""
                        },
                        ""virtual_size"": {
                          ""type"": ""long""
                        }
                      },
                      ""type"": ""nested""
                    },
                    ""segments"": {
                      ""properties"": {
                        ""sections"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""type"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      },
                      ""type"": ""nested""
                    },
                    ""shared_libraries"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""telfhash"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""end"": {
                  ""type"": ""date""
                },
                ""entity_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""executable"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""exit_code"": {
                  ""type"": ""long""
                },
                ""group"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""group_leader"": {
                  ""properties"": {
                    ""entity_id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""pid"": {
                      ""type"": ""long""
                    },
                    ""start"": {
                      ""type"": ""date""
                    }
                  }
                },
                ""hash"": {
                  ""properties"": {
                    ""md5"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""sha1"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""sha256"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""sha384"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""sha512"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""ssdeep"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""tlsh"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""interactive"": {
                  ""type"": ""boolean""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""pe"": {
                  ""properties"": {
                    ""architecture"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""company"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""description"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""file_version"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""imphash"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""original_file_name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""pehash"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""product"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""pgid"": {
                  ""type"": ""long""
                },
                ""pid"": {
                  ""type"": ""long""
                },
                ""real_group"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""real_user"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""saved_group"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""saved_user"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""start"": {
                  ""type"": ""date""
                },
                ""supplemental_groups"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""thread"": {
                  ""properties"": {
                    ""id"": {
                      ""type"": ""long""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""title"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""tty"": {
                  ""properties"": {
                    ""char_device"": {
                      ""properties"": {
                        ""major"": {
                          ""type"": ""long""
                        },
                        ""minor"": {
                          ""type"": ""long""
                        }
                      }
                    }
                  },
                  ""type"": ""object""
                },
                ""uptime"": {
                  ""type"": ""long""
                },
                ""user"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""working_directory"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""pe"": {
              ""properties"": {
                ""architecture"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""company"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""description"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""file_version"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""imphash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""original_file_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""pehash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""product"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""pgid"": {
              ""type"": ""long""
            },
            ""pid"": {
              ""type"": ""long""
            },
            ""previous"": {
              ""properties"": {
                ""args"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""args_count"": {
                  ""type"": ""long""
                },
                ""executable"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""real_group"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""real_user"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""saved_group"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""saved_user"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""session_leader"": {
              ""properties"": {
                ""args"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""args_count"": {
                  ""type"": ""long""
                },
                ""command_line"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""type"": ""wildcard""
                },
                ""entity_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""executable"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""group"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""interactive"": {
                  ""type"": ""boolean""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""parent"": {
                  ""properties"": {
                    ""entity_id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""pid"": {
                      ""type"": ""long""
                    },
                    ""session_leader"": {
                      ""properties"": {
                        ""entity_id"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""pid"": {
                          ""type"": ""long""
                        },
                        ""start"": {
                          ""type"": ""date""
                        }
                      }
                    },
                    ""start"": {
                      ""type"": ""date""
                    }
                  }
                },
                ""pid"": {
                  ""type"": ""long""
                },
                ""real_group"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""real_user"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""same_as_process"": {
                  ""type"": ""boolean""
                },
                ""saved_group"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""saved_user"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""start"": {
                  ""type"": ""date""
                },
                ""supplemental_groups"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""tty"": {
                  ""properties"": {
                    ""char_device"": {
                      ""properties"": {
                        ""major"": {
                          ""type"": ""long""
                        },
                        ""minor"": {
                          ""type"": ""long""
                        }
                      }
                    }
                  },
                  ""type"": ""object""
                },
                ""user"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""working_directory"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""start"": {
              ""type"": ""date""
            },
            ""supplemental_groups"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""thread"": {
              ""properties"": {
                ""id"": {
                  ""type"": ""long""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""title"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""tty"": {
              ""properties"": {
                ""char_device"": {
                  ""properties"": {
                    ""major"": {
                      ""type"": ""long""
                    },
                    ""minor"": {
                      ""type"": ""long""
                    }
                  }
                }
              },
              ""type"": ""object""
            },
            ""uptime"": {
              ""type"": ""long""
            },
            ""user"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""working_directory"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 RegistryJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string RegistryJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-registry.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""registry"": {
          ""properties"": {
            ""data"": {
              ""properties"": {
                ""bytes"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""strings"": {
                  ""type"": ""wildcard""
                },
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""hive"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""key"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""path"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""value"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 RelatedJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string RelatedJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-related.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""related"": {
          ""properties"": {
            ""hash"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""hosts"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""ip"": {
              ""type"": ""ip""
            },
            ""user"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 RuleJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string RuleJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-rule.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""rule"": {
          ""properties"": {
            ""author"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""category"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""description"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""license"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""reference"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""ruleset"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""uuid"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""version"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 ServerJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string ServerJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-server.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""server"": {
          ""properties"": {
            ""address"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""as"": {
              ""properties"": {
                ""number"": {
                  ""type"": ""long""
                },
                ""organization"": {
                  ""properties"": {
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                }
              }
            },
            ""bytes"": {
              ""type"": ""long""
            },
            ""domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""geo"": {
              ""properties"": {
                ""city_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""continent_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""continent_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""country_iso_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""country_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""location"": {
                  ""type"": ""geo_point""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""postal_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region_iso_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""timezone"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""ip"": {
              ""type"": ""ip""
            },
            ""mac"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""nat"": {
              ""properties"": {
                ""ip"": {
                  ""type"": ""ip""
                },
                ""port"": {
                  ""type"": ""long""
                }
              }
            },
            ""packets"": {
              ""type"": ""long""
            },
            ""port"": {
              ""type"": ""long""
            },
            ""registered_domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""subdomain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""top_level_domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""user"": {
              ""properties"": {
                ""domain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""email"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""full_name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""group"": {
                  ""properties"": {
                    ""domain"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""hash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""roles"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 ServiceJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string ServiceJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-service.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""service"": {
          ""properties"": {
            ""address"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""environment"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""ephemeral_id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""node"": {
              ""properties"": {
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""role"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""origin"": {
              ""properties"": {
                ""address"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""environment"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""ephemeral_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""node"": {
                  ""properties"": {
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""role"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""state"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""version"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""state"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""target"": {
              ""properties"": {
                ""address"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""environment"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""ephemeral_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""node"": {
                  ""properties"": {
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""role"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""state"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""version"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""type"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""version"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 SourceJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string SourceJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-source.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""source"": {
          ""properties"": {
            ""address"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""as"": {
              ""properties"": {
                ""number"": {
                  ""type"": ""long""
                },
                ""organization"": {
                  ""properties"": {
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                }
              }
            },
            ""bytes"": {
              ""type"": ""long""
            },
            ""domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""geo"": {
              ""properties"": {
                ""city_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""continent_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""continent_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""country_iso_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""country_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""location"": {
                  ""type"": ""geo_point""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""postal_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region_iso_code"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""region_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""timezone"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""ip"": {
              ""type"": ""ip""
            },
            ""mac"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""nat"": {
              ""properties"": {
                ""ip"": {
                  ""type"": ""ip""
                },
                ""port"": {
                  ""type"": ""long""
                }
              }
            },
            ""packets"": {
              ""type"": ""long""
            },
            ""port"": {
              ""type"": ""long""
            },
            ""registered_domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""subdomain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""top_level_domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""user"": {
              ""properties"": {
                ""domain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""email"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""full_name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""group"": {
                  ""properties"": {
                    ""domain"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""hash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""roles"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 ThreatJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string ThreatJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-threat.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""threat"": {
          ""properties"": {
            ""enrichments"": {
              ""properties"": {
                ""indicator"": {
                  ""properties"": {
                    ""as"": {
                      ""properties"": {
                        ""number"": {
                          ""type"": ""long""
                        },
                        ""organization"": {
                          ""properties"": {
                            ""name"": {
                              ""fields"": {
                                ""text"": {
                                  ""type"": ""match_only_text""
                                }
                              },
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            }
                          }
                        }
                      }
                    },
                    ""confidence"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""description"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""email"": {
                      ""properties"": {
                        ""address"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""file"": {
                      ""properties"": {
                        ""accessed"": {
                          ""type"": ""date""
                        },
                        ""attributes"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""code_signature"": {
                          ""properties"": {
                            ""digest_algorithm"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""exists"": {
                              ""type"": ""boolean""
                            },
                            ""signing_id"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""status"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""subject_name"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""team_id"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""timestamp"": {
                              ""type"": ""date""
                            },
                            ""trusted"": {
                              ""type"": ""boolean""
                            },
                            ""valid"": {
                              ""type"": ""boolean""
                            }
                          }
                        },
                        ""created"": {
                          ""type"": ""date""
                        },
                        ""ctime"": {
                          ""type"": ""date""
                        },
                        ""device"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""directory"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""drive_letter"": {
                          ""ignore_above"": 1,
                          ""type"": ""keyword""
                        },
                        ""elf"": {
                          ""properties"": {
                            ""architecture"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""byte_order"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""cpu_type"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""creation_date"": {
                              ""type"": ""date""
                            },
                            ""exports"": {
                              ""type"": ""flattened""
                            },
                            ""header"": {
                              ""properties"": {
                                ""abi_version"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""class"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""data"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""entrypoint"": {
                                  ""type"": ""long""
                                },
                                ""object_version"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""os_abi"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""type"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""version"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                }
                              }
                            },
                            ""imports"": {
                              ""type"": ""flattened""
                            },
                            ""sections"": {
                              ""properties"": {
                                ""chi2"": {
                                  ""type"": ""long""
                                },
                                ""entropy"": {
                                  ""type"": ""long""
                                },
                                ""flags"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""name"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""physical_offset"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""physical_size"": {
                                  ""type"": ""long""
                                },
                                ""type"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""virtual_address"": {
                                  ""type"": ""long""
                                },
                                ""virtual_size"": {
                                  ""type"": ""long""
                                }
                              },
                              ""type"": ""nested""
                            },
                            ""segments"": {
                              ""properties"": {
                                ""sections"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""type"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                }
                              },
                              ""type"": ""nested""
                            },
                            ""shared_libraries"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""telfhash"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            }
                          }
                        },
                        ""extension"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""fork_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""gid"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""group"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""hash"": {
                          ""properties"": {
                            ""md5"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""sha1"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""sha256"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""sha384"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""sha512"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""ssdeep"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""tlsh"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            }
                          }
                        },
                        ""inode"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""mime_type"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""mode"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""mtime"": {
                          ""type"": ""date""
                        },
                        ""name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""owner"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""path"": {
                          ""fields"": {
                            ""text"": {
                              ""type"": ""match_only_text""
                            }
                          },
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""pe"": {
                          ""properties"": {
                            ""architecture"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""company"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""description"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""file_version"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""imphash"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""original_file_name"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""pehash"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""product"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            }
                          }
                        },
                        ""size"": {
                          ""type"": ""long""
                        },
                        ""target_path"": {
                          ""fields"": {
                            ""text"": {
                              ""type"": ""match_only_text""
                            }
                          },
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""type"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""uid"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""x509"": {
                          ""properties"": {
                            ""alternative_names"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""issuer"": {
                              ""properties"": {
                                ""common_name"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""country"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""distinguished_name"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""locality"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""organization"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""organizational_unit"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""state_or_province"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                }
                              }
                            },
                            ""not_after"": {
                              ""type"": ""date""
                            },
                            ""not_before"": {
                              ""type"": ""date""
                            },
                            ""public_key_algorithm"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""public_key_curve"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""public_key_exponent"": {
                              ""doc_values"": false,
                              ""index"": false,
                              ""type"": ""long""
                            },
                            ""public_key_size"": {
                              ""type"": ""long""
                            },
                            ""serial_number"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""signature_algorithm"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""subject"": {
                              ""properties"": {
                                ""common_name"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""country"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""distinguished_name"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""locality"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""organization"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""organizational_unit"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                },
                                ""state_or_province"": {
                                  ""ignore_above"": 1024,
                                  ""type"": ""keyword""
                                }
                              }
                            },
                            ""version_number"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            }
                          }
                        }
                      }
                    },
                    ""first_seen"": {
                      ""type"": ""date""
                    },
                    ""geo"": {
                      ""properties"": {
                        ""city_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""continent_code"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""continent_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""country_iso_code"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""country_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""location"": {
                          ""type"": ""geo_point""
                        },
                        ""name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""postal_code"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""region_iso_code"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""region_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""timezone"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""ip"": {
                      ""type"": ""ip""
                    },
                    ""last_seen"": {
                      ""type"": ""date""
                    },
                    ""marking"": {
                      ""properties"": {
                        ""tlp"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""modified_at"": {
                      ""type"": ""date""
                    },
                    ""port"": {
                      ""type"": ""long""
                    },
                    ""provider"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""reference"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""registry"": {
                      ""properties"": {
                        ""data"": {
                          ""properties"": {
                            ""bytes"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""strings"": {
                              ""type"": ""wildcard""
                            },
                            ""type"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            }
                          }
                        },
                        ""hive"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""key"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""path"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""value"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""scanner_stats"": {
                      ""type"": ""long""
                    },
                    ""sightings"": {
                      ""type"": ""long""
                    },
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""url"": {
                      ""properties"": {
                        ""domain"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""extension"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""fragment"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""full"": {
                          ""fields"": {
                            ""text"": {
                              ""type"": ""match_only_text""
                            }
                          },
                          ""type"": ""wildcard""
                        },
                        ""original"": {
                          ""fields"": {
                            ""text"": {
                              ""type"": ""match_only_text""
                            }
                          },
                          ""type"": ""wildcard""
                        },
                        ""password"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""path"": {
                          ""type"": ""wildcard""
                        },
                        ""port"": {
                          ""type"": ""long""
                        },
                        ""query"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""registered_domain"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""scheme"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""subdomain"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""top_level_domain"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""username"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""x509"": {
                      ""properties"": {
                        ""alternative_names"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""issuer"": {
                          ""properties"": {
                            ""common_name"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""country"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""distinguished_name"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""locality"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""organization"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""organizational_unit"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""state_or_province"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            }
                          }
                        },
                        ""not_after"": {
                          ""type"": ""date""
                        },
                        ""not_before"": {
                          ""type"": ""date""
                        },
                        ""public_key_algorithm"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""public_key_curve"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""public_key_exponent"": {
                          ""doc_values"": false,
                          ""index"": false,
                          ""type"": ""long""
                        },
                        ""public_key_size"": {
                          ""type"": ""long""
                        },
                        ""serial_number"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""signature_algorithm"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""subject"": {
                          ""properties"": {
                            ""common_name"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""country"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""distinguished_name"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""locality"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""organization"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""organizational_unit"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""state_or_province"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            }
                          }
                        },
                        ""version_number"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    }
                  },
                  ""type"": ""object""
                },
                ""matched"": {
                  ""properties"": {
                    ""atomic"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""field"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""index"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""occurred"": {
                      ""type"": ""date""
                    },
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                }
              },
              ""type"": ""nested""
            },
            ""feed"": {
              ""properties"": {
                ""dashboard_id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""description"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""reference"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""framework"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""group"": {
              ""properties"": {
                ""alias"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""reference"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""indicator"": {
              ""properties"": {
                ""as"": {
                  ""properties"": {
                    ""number"": {
                      ""type"": ""long""
                    },
                    ""organization"": {
                      ""properties"": {
                        ""name"": {
                          ""fields"": {
                            ""text"": {
                              ""type"": ""match_only_text""
                            }
                          },
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    }
                  }
                },
                ""confidence"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""description"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""email"": {
                  ""properties"": {
                    ""address"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""file"": {
                  ""properties"": {
                    ""accessed"": {
                      ""type"": ""date""
                    },
                    ""attributes"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""code_signature"": {
                      ""properties"": {
                        ""digest_algorithm"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""exists"": {
                          ""type"": ""boolean""
                        },
                        ""signing_id"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""status"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""subject_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""team_id"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""timestamp"": {
                          ""type"": ""date""
                        },
                        ""trusted"": {
                          ""type"": ""boolean""
                        },
                        ""valid"": {
                          ""type"": ""boolean""
                        }
                      }
                    },
                    ""created"": {
                      ""type"": ""date""
                    },
                    ""ctime"": {
                      ""type"": ""date""
                    },
                    ""device"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""directory"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""drive_letter"": {
                      ""ignore_above"": 1,
                      ""type"": ""keyword""
                    },
                    ""elf"": {
                      ""properties"": {
                        ""architecture"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""byte_order"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""cpu_type"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""creation_date"": {
                          ""type"": ""date""
                        },
                        ""exports"": {
                          ""type"": ""flattened""
                        },
                        ""header"": {
                          ""properties"": {
                            ""abi_version"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""class"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""data"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""entrypoint"": {
                              ""type"": ""long""
                            },
                            ""object_version"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""os_abi"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""type"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""version"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            }
                          }
                        },
                        ""imports"": {
                          ""type"": ""flattened""
                        },
                        ""sections"": {
                          ""properties"": {
                            ""chi2"": {
                              ""type"": ""long""
                            },
                            ""entropy"": {
                              ""type"": ""long""
                            },
                            ""flags"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""name"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""physical_offset"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""physical_size"": {
                              ""type"": ""long""
                            },
                            ""type"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""virtual_address"": {
                              ""type"": ""long""
                            },
                            ""virtual_size"": {
                              ""type"": ""long""
                            }
                          },
                          ""type"": ""nested""
                        },
                        ""segments"": {
                          ""properties"": {
                            ""sections"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""type"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            }
                          },
                          ""type"": ""nested""
                        },
                        ""shared_libraries"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""telfhash"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""extension"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""fork_name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""gid"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""group"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""hash"": {
                      ""properties"": {
                        ""md5"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""sha1"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""sha256"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""sha384"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""sha512"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""ssdeep"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""tlsh"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""inode"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""mime_type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""mode"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""mtime"": {
                      ""type"": ""date""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""owner"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""path"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""pe"": {
                      ""properties"": {
                        ""architecture"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""company"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""description"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""file_version"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""imphash"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""original_file_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""pehash"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""product"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""size"": {
                      ""type"": ""long""
                    },
                    ""target_path"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""type"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""uid"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""x509"": {
                      ""properties"": {
                        ""alternative_names"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""issuer"": {
                          ""properties"": {
                            ""common_name"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""country"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""distinguished_name"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""locality"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""organization"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""organizational_unit"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""state_or_province"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            }
                          }
                        },
                        ""not_after"": {
                          ""type"": ""date""
                        },
                        ""not_before"": {
                          ""type"": ""date""
                        },
                        ""public_key_algorithm"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""public_key_curve"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""public_key_exponent"": {
                          ""doc_values"": false,
                          ""index"": false,
                          ""type"": ""long""
                        },
                        ""public_key_size"": {
                          ""type"": ""long""
                        },
                        ""serial_number"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""signature_algorithm"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""subject"": {
                          ""properties"": {
                            ""common_name"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""country"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""distinguished_name"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""locality"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""organization"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""organizational_unit"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            },
                            ""state_or_province"": {
                              ""ignore_above"": 1024,
                              ""type"": ""keyword""
                            }
                          }
                        },
                        ""version_number"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    }
                  }
                },
                ""first_seen"": {
                  ""type"": ""date""
                },
                ""geo"": {
                  ""properties"": {
                    ""city_name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""continent_code"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""continent_name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""country_iso_code"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""country_name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""location"": {
                      ""type"": ""geo_point""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""postal_code"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""region_iso_code"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""region_name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""timezone"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""ip"": {
                  ""type"": ""ip""
                },
                ""last_seen"": {
                  ""type"": ""date""
                },
                ""marking"": {
                  ""properties"": {
                    ""tlp"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""modified_at"": {
                  ""type"": ""date""
                },
                ""port"": {
                  ""type"": ""long""
                },
                ""provider"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""reference"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""registry"": {
                  ""properties"": {
                    ""data"": {
                      ""properties"": {
                        ""bytes"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""strings"": {
                          ""type"": ""wildcard""
                        },
                        ""type"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""hive"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""key"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""path"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""value"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""scanner_stats"": {
                  ""type"": ""long""
                },
                ""sightings"": {
                  ""type"": ""long""
                },
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""url"": {
                  ""properties"": {
                    ""domain"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""extension"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""fragment"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""full"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""type"": ""wildcard""
                    },
                    ""original"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""type"": ""wildcard""
                    },
                    ""password"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""path"": {
                      ""type"": ""wildcard""
                    },
                    ""port"": {
                      ""type"": ""long""
                    },
                    ""query"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""registered_domain"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""scheme"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""subdomain"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""top_level_domain"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""username"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""x509"": {
                  ""properties"": {
                    ""alternative_names"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""issuer"": {
                      ""properties"": {
                        ""common_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""country"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""distinguished_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""locality"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""organization"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""organizational_unit"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""state_or_province"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""not_after"": {
                      ""type"": ""date""
                    },
                    ""not_before"": {
                      ""type"": ""date""
                    },
                    ""public_key_algorithm"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""public_key_curve"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""public_key_exponent"": {
                      ""doc_values"": false,
                      ""index"": false,
                      ""type"": ""long""
                    },
                    ""public_key_size"": {
                      ""type"": ""long""
                    },
                    ""serial_number"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""signature_algorithm"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""subject"": {
                      ""properties"": {
                        ""common_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""country"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""distinguished_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""locality"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""organization"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""organizational_unit"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""state_or_province"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""version_number"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                }
              }
            },
            ""software"": {
              ""properties"": {
                ""alias"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""platforms"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""reference"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""tactic"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""reference"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""technique"": {
              ""properties"": {
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""reference"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""subtechnique"": {
                  ""properties"": {
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""fields"": {
                        ""text"": {
                          ""type"": ""match_only_text""
                        }
                      },
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""reference"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 TlsJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string TlsJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-tls.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""tls"": {
          ""properties"": {
            ""cipher"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""client"": {
              ""properties"": {
                ""certificate"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""certificate_chain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""hash"": {
                  ""properties"": {
                    ""md5"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""sha1"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""sha256"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""issuer"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""ja3"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""not_after"": {
                  ""type"": ""date""
                },
                ""not_before"": {
                  ""type"": ""date""
                },
                ""server_name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""subject"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""supported_ciphers"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""x509"": {
                  ""properties"": {
                    ""alternative_names"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""issuer"": {
                      ""properties"": {
                        ""common_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""country"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""distinguished_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""locality"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""organization"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""organizational_unit"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""state_or_province"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""not_after"": {
                      ""type"": ""date""
                    },
                    ""not_before"": {
                      ""type"": ""date""
                    },
                    ""public_key_algorithm"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""public_key_curve"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""public_key_exponent"": {
                      ""doc_values"": false,
                      ""index"": false,
                      ""type"": ""long""
                    },
                    ""public_key_size"": {
                      ""type"": ""long""
                    },
                    ""serial_number"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""signature_algorithm"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""subject"": {
                      ""properties"": {
                        ""common_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""country"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""distinguished_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""locality"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""organization"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""organizational_unit"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""state_or_province"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""version_number"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                }
              }
            },
            ""curve"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""established"": {
              ""type"": ""boolean""
            },
            ""next_protocol"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""resumed"": {
              ""type"": ""boolean""
            },
            ""server"": {
              ""properties"": {
                ""certificate"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""certificate_chain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""hash"": {
                  ""properties"": {
                    ""md5"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""sha1"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""sha256"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""issuer"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""ja3s"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""not_after"": {
                  ""type"": ""date""
                },
                ""not_before"": {
                  ""type"": ""date""
                },
                ""subject"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""x509"": {
                  ""properties"": {
                    ""alternative_names"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""issuer"": {
                      ""properties"": {
                        ""common_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""country"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""distinguished_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""locality"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""organization"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""organizational_unit"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""state_or_province"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""not_after"": {
                      ""type"": ""date""
                    },
                    ""not_before"": {
                      ""type"": ""date""
                    },
                    ""public_key_algorithm"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""public_key_curve"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""public_key_exponent"": {
                      ""doc_values"": false,
                      ""index"": false,
                      ""type"": ""long""
                    },
                    ""public_key_size"": {
                      ""type"": ""long""
                    },
                    ""serial_number"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""signature_algorithm"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""subject"": {
                      ""properties"": {
                        ""common_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""country"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""distinguished_name"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""locality"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""organization"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""organizational_unit"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        },
                        ""state_or_province"": {
                          ""ignore_above"": 1024,
                          ""type"": ""keyword""
                        }
                      }
                    },
                    ""version_number"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                }
              }
            },
            ""version"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""version_protocol"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 TracingJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string TracingJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-tracing.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""span"": {
          ""properties"": {
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        },
        ""trace"": {
          ""properties"": {
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        },
        ""transaction"": {
          ""properties"": {
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 UrlJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string UrlJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-url.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""url"": {
          ""properties"": {
            ""domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""extension"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""fragment"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""full"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""type"": ""wildcard""
            },
            ""original"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""type"": ""wildcard""
            },
            ""password"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""path"": {
              ""type"": ""wildcard""
            },
            ""port"": {
              ""type"": ""long""
            },
            ""query"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""registered_domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""scheme"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""subdomain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""top_level_domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""username"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 UserAgentJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string UserAgentJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-user_agent.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""user_agent"": {
          ""properties"": {
            ""device"": {
              ""properties"": {
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""name"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""original"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""os"": {
              ""properties"": {
                ""family"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""full"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""kernel"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""platform"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""type"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""version"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""version"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 UserJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string UserJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-user.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""user"": {
          ""properties"": {
            ""changes"": {
              ""properties"": {
                ""domain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""email"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""full_name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""group"": {
                  ""properties"": {
                    ""domain"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""hash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""roles"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""domain"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""effective"": {
              ""properties"": {
                ""domain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""email"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""full_name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""group"": {
                  ""properties"": {
                    ""domain"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""hash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""roles"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""email"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""full_name"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""group"": {
              ""properties"": {
                ""domain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""hash"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""name"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""roles"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""target"": {
              ""properties"": {
                ""domain"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""email"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""full_name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""group"": {
                  ""properties"": {
                    ""domain"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""id"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    },
                    ""name"": {
                      ""ignore_above"": 1024,
                      ""type"": ""keyword""
                    }
                  }
                },
                ""hash"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""id"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""name"": {
                  ""fields"": {
                    ""text"": {
                      ""type"": ""match_only_text""
                    }
                  },
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                },
                ""roles"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            }
          }
        }
      }
    }
  }
}
";

		/// <summary>
		/// Elastic Common Schema version v8.3.1 VulnerabilityJson component template  
		/// </summary>
		/// <returns>Index template string that can be used with the Put Index Template API.</returns>
		public static string VulnerabilityJson => 
			@"{
  ""_meta"": {
    ""documentation"": ""https://www.elastic.co/guide/en/ecs/current/ecs-vulnerability.html"",
    ""ecs_version"": ""8.3.1""
  },
  ""template"": {
    ""mappings"": {
      ""properties"": {
        ""vulnerability"": {
          ""properties"": {
            ""category"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""classification"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""description"": {
              ""fields"": {
                ""text"": {
                  ""type"": ""match_only_text""
                }
              },
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""enumeration"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""reference"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""report_id"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            },
            ""scanner"": {
              ""properties"": {
                ""vendor"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""score"": {
              ""properties"": {
                ""base"": {
                  ""type"": ""float""
                },
                ""environmental"": {
                  ""type"": ""float""
                },
                ""temporal"": {
                  ""type"": ""float""
                },
                ""version"": {
                  ""ignore_above"": 1024,
                  ""type"": ""keyword""
                }
              }
            },
            ""severity"": {
              ""ignore_above"": 1024,
              ""type"": ""keyword""
            }
          }
        }
      }
    }
  }
}
";

	}
}
