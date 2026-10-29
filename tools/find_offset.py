import struct

# Let's inspect GameAssembly.dll around 0x182131d8e
with open(r"C:\Program Files (x86)\Steam\steamapps\common\Suikoden I and II HD Remaster\Suikoden 2 HD\GameAssembly.dll", "rb") as f:
    dll = f.read()

# Base address is 0x180001000? Let's check PE header
pe_offset = struct.unpack_from("<I", dll, 0x3C)[0]
image_base = struct.unpack_from("<Q", dll, pe_offset + 0x30)[0]
print(f"ImageBase: {hex(image_base)}")

def va_to_offset(va):
    # Standard section mapping or direct if section headers known
    # Let's read section headers
    num_sections = struct.unpack_from("<H", dll, pe_offset + 0x6)[0]
    opt_header_size = struct.unpack_from("<H", dll, pe_offset + 0x14)[0]
    sec_table = pe_offset + 0x18 + opt_header_size
    for i in range(num_sections):
        sec = dll[sec_table + i*40 : sec_table + (i+1)*40]
        name = sec[:8].rstrip(b'\x00').decode('ascii', errors='ignore')
        vsize, va_sec, rsize, rptr = struct.unpack_from("<IIII", sec, 8)
        sec_start = image_base + va_sec
        sec_end = sec_start + max(vsize, rsize)
        if sec_start <= va < sec_end:
            return rptr + (va - sec_start)
    return None

print("VA 0x1821316f0 -> offset:", hex(va_to_offset(0x1821316f0)))

