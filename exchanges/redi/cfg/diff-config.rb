module DiffConfig
  ROM_ignore_per_message_type = {
    "All" => [1,71],
    "S"   => [2,3,6,10,11,15,40,45,46,48,60,61,67,75],
  }

  FIX_ignore_per_message_type = {
    "All" => [8,9,10,11,34,49,52,56,58,60,167,204],
    "G"   => [37,41],
    "F"   => [37,41],
    "8"   => [41],
  }
end
